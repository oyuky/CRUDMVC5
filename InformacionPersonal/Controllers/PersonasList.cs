using InformacionPersonal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InformacionPersonal.Controllers
{
    public class PersonasList
    {
        ///<summary>
        /// Gets or sets Personas.
        ///</summary>
        public List<Persona> Personas { get; set; }

        ///<summary>
        /// Gets or sets CurrentPageIndex.
        ///</summary>
        public int CurrentPageIndex { get; set; }

        ///<summary>
        /// Gets or sets PageCount.
        ///</summary>
        public int PageCount { get; set; }
    }
}