var ajaxCallEditURL = "/Personas/EditPartial";
var ajaxCallCreateURL = "/Personas/CreatePartial";
var ajaxCallDetailsURL = "/Personas/DetailsPartial";
var ajaxCallDeleteURL = "/Personas/DeletePartial";
//Abrir modals
$(function () {
    function PagerClick(index) {
        document.getElementById("hfCurrentPageIndex").value = index;
        document.forms[0].submit();
    }

    $(".crearPersona").click(function () {
        var $buttonClicked = $(this);
        var options = {
            "backdrop": "static",
            keyboard: true
        };
        $.ajax({
            type: "GET",
            url: ajaxCallCreateURL,
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            success: function (data) {
                //debugger;
                $("#divModalContent").html(data);
                $("#modal_title").html("<span>Crear Registro</span>");
                $("#divModal").modal(options);
                $("#divModal").modal("show");
            },
            error: function () {
                alert("Content load failed.");
            }
        });
    });

    $(".editarPersona").click(function () {
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr("data-id");
        var options = {
            "backdrop": "static",
            keyboard: true
        };
        $.ajax({
            type: "GET",
            url: ajaxCallEditURL,
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            data: { id: id },
            success: function (data) {
                //debugger;
                $("#divModalContent").html(data);
                $("#modal_title").html("<span>Editar Registro</span>");
                $("#divModal").modal(options);
                $("#divModal").modal("show");
            },
            error: function () {
                alert("Content load failed.");
            }
        });
    });

    $(".detallePersona").click(function () {
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr("data-id");
        var options = {
            "backdrop": "static",
            keyboard: true
        };
        $.ajax({
            type: "GET",
            url: ajaxCallDetailsURL,
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            data: { id: id },
            success: function (data) {
                //debugger;
                $("#divModalContent").html(data);
                $("#modal_title").html("<span>Detalle de Registro</span>");
                $("#divModal").modal(options);
                $("#divModal").modal("show");
            },
            error: function () {
                alert("Content load failed.");
            }
        });
    });

    $(".eliminarPersona").click(function () {
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr("data-id");
        var options = {
            "backdrop": "static",
            keyboard: true
        };
        $.ajax({
            type: "GET",
            url: ajaxCallDeleteURL,
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            data: { id: id },
            success: function (data) {
                $("#divModalContent").html(data);
                $("#modal_title").html("<span>Está a punto de borrar el siguiente registro. ¿Desea continuar?</span>");
                $("#divModal").modal(options);
                $("#divModal").modal("show");
            },
            error: function () {
                alert("Content load failed.");
            }
        });
    });

    $("#closbtn").click(function () {
        $("#divModal").modal("hide");
    });
});

function filtrar(pageindex) {
    var $buttonClicked = $(this);
    var options = {
        "backdrop": "static",
        keyboard: true
    };
    $.ajax({
        type: "POST",
        url: '/Personas/ListaPersonas',
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: JSON.stringify(
            {
                "currentPageIndex": pageindex,
                "Nombre":$('#Filtro_Nombre').val(),
                "ApellidoPaterno": $('#Filtro_ApellidoPaterno').val(),
                "ApellidoMaterno": $('#Filtro_ApellidoMaterno').val(),
                "CURP": $('#Filtro_CURP').val()
            }),
        success: function (data) {
            $("#listPersonas").html(data);
        },
        error: function (data) {
            alert(data.responseText);
        }
    });
}
function editar() {
    var $buttonClicked = $(this);
    var options = {
        "backdrop": "static",
        keyboard: true
    };
    $.ajax({
        type: "POST",
        url: '/Personas/Edit',
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: JSON.stringify({
            ID: $('#ID').val(),
            Nombre: $('#Model-Nombre').val(),
            ApellidoPaterno: $('#Model-ApellidoPaterno').val(),
            ApellidoMaterno: $('#Model-ApellidoMaterno').val(),
            CURP: $('#Model-CURP').val()
        }),
        success: function (data) {
            alert("Registro Guardado exitosamente.");
            $("#listPersonas").html(data);
            $("#divModal").modal("hide");
        },
        error: function (data) {
            $("#divModalContent").html(data.responseText);
            $("#modal_title").html("<span>Guardar</span>");
            $("#divModal").modal(options);
            $("#divModal").modal("show");
        }
    });
}
function eliminar() {
    var $buttonClicked = $(this);
    var options = {
        "backdrop": "static",
        keyboard: true
    };
    $.ajax({
        type: "POST",
        url: '/Personas/Delete',
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: JSON.stringify({
            ID: $('#ID').val(),
            Nombre: $('#Model-Nombre').val(),
            ApellidoPaterno: $('#Model-ApellidoPaterno').val(),
            ApellidoMaterno: $('#Model-ApellidoMaterno').val(),
            CURP: $('#Model-CURP').val()
        }),
        success: function (data) {
            alert("Registro Guardado exitosamente.");
            $("#listPersonas").html(data);
            $("#divModal").modal("hide");
        },
        error: function (data) {
            $("#divModalContent").html(data.responseText);
            $("#modal_title").html("<span>Guardar</span>");
            $("#divModal").modal(options);
            $("#divModal").modal("show");
        }
    });
}
function crear() {
    var $buttonClicked = $(this);
    var options = {
        "backdrop": "static",
        keyboard: true
    };
    $.ajax({
        type: "POST",
        url: '/Personas/Create',
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: JSON.stringify({
            Nombre: $('#Model-Nombre').val(),
            ApellidoPaterno: $('#Model-ApellidoPaterno').val(),
            ApellidoMaterno: $('#Model-ApellidoMaterno').val(),
            CURP: $('#Model-CURP').val()
        }),
        success: function (data) {
            alert("Registro Guardado exitosamente.");
            $("#divModal").modal("hide");
        },
        error: function (data) {
            $("#divModalContent").html(data.responseText);
            $("#modal_title").html("<span>Crear Registro</span>");
            $("#divModal").modal(options);
            $("#divModal").modal("show");
        }
    });
}