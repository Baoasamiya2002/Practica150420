using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiRest.Models;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly GestionCuentasContext _contexto;
        List<Cuenta> cuentas { set; get; }
        public CuentaController(GestionCuentasContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Obtener()
        {
            var cuentas = _contexto.Cuentas.ToList();
            return Ok(cuentas);
        }

        //post crear cuenta
        //post iniciar sesion
        //put modificar cuenta
        //patch cambiar contraseña
        //delete cambiar bandera que define si tiene acceso
    }
}