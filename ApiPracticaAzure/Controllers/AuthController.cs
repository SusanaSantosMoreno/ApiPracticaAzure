using ApiPracticaAzure.Helpers;
using ApiPracticaAzure.Models;
using ApiPracticaAzure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiPracticaAzure.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {

        RepositorySeries repository;
        HelperToken helperToken;

        public AuthController (RepositorySeries repo, HelperToken helperToken) {
            this.repository = repo;
            this.helperToken = helperToken;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login (UsuariosAzure model) {
            UsuariosAzure usuario = this.repository.ExisteUsuario(model.Email, model.Pass);
            if (usuario == null) {
                return Unauthorized();
            } else {
                String usuarioJson = JsonConvert.SerializeObject(usuario);
                Claim[] claims = new[] {
                    new Claim("UserData", usuarioJson)
                };

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: this.helperToken.Issuer,
                    audience: this.helperToken.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    notBefore: DateTime.UtcNow,
                    signingCredentials:
                        new SigningCredentials(this.helperToken.GetKeyToken(),
                        SecurityAlgorithms.HmacSha256)
                 );

                return Ok(
                    new {
                        response = new JwtSecurityTokenHandler().WriteToken(token)
                    });
            }
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public ActionResult<UsuariosAzure> PerfilUsuario () {
            List<Claim> claims = HttpContext.User.Claims.ToList();
            String jsonUsuario = claims.SingleOrDefault(x => x.Type == "UserData").Value;
            UsuariosAzure usuario = JsonConvert.DeserializeObject<UsuariosAzure>(jsonUsuario);
            return usuario;
        }

    }
}
