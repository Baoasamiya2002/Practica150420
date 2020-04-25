using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiRest.Models;
using ApiRest.Utilities;

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

        [HttpGet]
        [Route("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var cuenta = cuentas.FirstOrDefault(a => a.Id == id);
            if (cuenta == null)
            {
                return NotFound();
            }
            return Ok(cuenta);
        }

        [HttpPost]
        [Route("crear")]
        public IActionResult Crear(Cuenta cuenta)
        {
            UtilidadContrasena utilidadContrasena = new UtilidadContrasena();
            var salt = utilidadContrasena.GetSalt();
            var contrasenaHash = utilidadContrasena.Hash(cuenta.Contrasena, salt);
            cuenta.Salt = salt.ToString();//////
            cuenta.Contrasena = contrasenaHash;
            _contexto.Cuentas.Add(cuenta);
            _contexto.SaveChanges();
            return CreatedAtAction(nameof(ObtenerPorId), new { cuenta.Id }, cuenta);
        }

        [HttpPost]
        [Route("iniciarSesion")]
        public IActionResult IniciarSesion(string usuario, string contrasena)
        {
            var cuentaExistente = _contexto.Cuentas.FirstOrDefault(cuenta => cuenta.Usuario == usuario);
            UtilidadContrasena utilidadContrasena = new UtilidadContrasena();
            var salt = utilidadContrasena.GetSalt();
            var contrasenaHash = utilidadContrasena.Hash(contrasena, salt);
            if (cuentaExistente == null)
            {
                return NotFound();
            }
            if (cuentaExistente.Acceso == false) {
                return BadRequest(); 
            }
            return Content(contrasenaHash/*"sesión iniciada"*/);
        }

        //

               

        //post crear cuenta
        //post iniciar sesion
        //put modificar cuenta
        //patch cambiar contraseña
        //delete cambiar bandera que define si tiene acceso
    }
}