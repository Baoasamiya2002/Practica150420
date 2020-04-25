using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Models
{
    public class GestionCuentasContext : DbContext
    {
        public GestionCuentasContext (DbContextOptions<GestionCuentasContext> opciones): base(opciones) { }
        public DbSet<Cuenta> Cuentas { set; get; }
    }
}