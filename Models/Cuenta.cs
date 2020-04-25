using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ApiRest.Models
{
    public class Cuenta
    {
        public int Id { set; get; }
        public string Usuario { set; get; }
        public string Contrasena { set; get; }
        public string Salt { set; get; }
        public string Nombre { set; get; }
        public bool Acceso { set; get; }
    }
}