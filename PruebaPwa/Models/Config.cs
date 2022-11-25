using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaPwa.Models
{
    public class Config
    {
        public  string _Host { get; set; }
        public  string Clave { get; set; }
        public  string Usuario { get; set; }
        public  string Source { get; set; }

        public Config()
        {
            _Host = "https://localhost:44391/";
            Clave = "David1988";
            Usuario = "sa";
            Source = "yaneth";
        }



    }
}