using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InformacionPersonal.Models
{
    public class Persona
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string CURP { get; set; }
    }

    public class PersonasList
    {
        public virtual Persona Filtro { get; set; }
        ///<summary>
        /// Personas
        ///</summary>
        public virtual List<Persona> Personas { get; set; }

        ///<summary>
        /// CurrentPageIndex.
        ///</summary>
        public virtual int CurrentPageIndex { get; set; }

        ///<summary>
        /// PageCount.
        ///</summary>
        public virtual int PageCount { get; set; }
    }
}