using AutoMapper;
using ChallengeAlkemy.Dtos;
using ChallengeAlkemy.Models;
using ChallengeAlkemy.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ChallengeAlkemy.Controllers
{
    
    [Route("api/auth")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _userRepo;
        public readonly string _secret;
        private readonly IConfiguration _config;

        public UsuarioController(IUsuarioRepository userRepo,IConfiguration config)
        {
            _userRepo = userRepo;
            _config = config;
            _secret = config["Jwt:Key"];
        }
        [HttpPost("Register")]
        public IActionResult Register(UsuarioAuthDto userRequest)
        {
            userRequest.UserName = userRequest.UserName.ToLower();
            
            var userCreated = _userRepo.Register(userRequest);
            return Ok(userCreated);

        }
        
        [HttpPost("Login")]
        public IActionResult Login(UsuarioAuthLoginDto usuarioAuthLoginDto)
        {            
            var usuarioDesdeRepo = _userRepo.Login(usuarioAuthLoginDto.UserName.ToLower(), usuarioAuthLoginDto.Password);

            if (usuarioDesdeRepo == null)
            {
                return Unauthorized();
            }
            
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuarioDesdeRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, usuarioDesdeRepo.UserName.ToString())
                };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var expDate = DateTime.UtcNow.AddMinutes(120);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expDate,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                Token = tokenHandler.WriteToken(token),
                Expires = expDate
            });
           
        }
    }
}
