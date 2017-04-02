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
}