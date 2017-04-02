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

        /////<summary>
        ///// Gets or sets Personas.
        /////</summary>
        //public virtual List<Persona> Personas { get; set; }

        /////<summary>
        ///// Gets or sets CurrentPageIndex.
        /////</summary>
        //public virtual int CurrentPageIndex { get; set; }

        /////<summary>
        ///// Gets or sets PageCount.
        /////</summary>
        //public virtual int PageCount { get; set; }
    }

    public class PersonasListViewmodel
    {
        ///<summary>
        /// Gets or sets Personas.
        ///</summary>
        public virtual List<Persona> Personas { get; set; }

        ///<summary>
        /// Gets or sets CurrentPageIndex.
        ///</summary>
        public virtual int CurrentPageIndex { get; set; }

        ///<summary>
        /// Gets or sets PageCount.
        ///</summary>
        public virtual int PageCount { get; set; }
    }
}