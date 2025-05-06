using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ProvaA2_Bruno_Do_Nascimento_Guilherme_Romero.Data;
using ProvaA2_Bruno_Do_Nascimento_Guilherme_Romero.Models;
using ProvaA2_Bruno_Do_Nascimento_Guilherme_Romero.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProvaA2_Bruno_Do_Nascimento_Guilherme_Romero.Controllers;

[ApiController]
[Route("/usuarios")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioRepository usuarioRepositorio;
    private readonly IConfiguration config;
    public UsuarioController(UsuarioRepository usuarioRepository,
        IConfiguration configuration)
    {
        usuarioRepositorio = usuarioRepository;
        config = configuration;
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar([FromBody] Usuario usuario)
    {
        usuarioRepositorio.Cadastrar(usuario);
        return Created("", usuario);
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] Usuario usuario)
    {
        Usuario? user = usuarioRepositorio
            .BuscarUsuarioPorEmailSenha(usuario.email, usuario.senha);

        if (user == null)
        {
            return Unauthorized(new { mensagem = "Usuário ou senha inválidos!" });
        }

        string token = gerarToken(user);
        return Ok(token);
    }

    [HttpGet("listar")]
    [Authorize]
    public IActionResult Listar()
    {
        return Ok(usuarioRepositorio.Listar());
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public string gerarToken(Usuario usuario)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, usuario.email),
        };

        var chave = Encoding.UTF8.GetBytes(config["JwtSettings:SecretKey"]!);
        
        var credencial = new SigningCredentials(
            new SymmetricSecurityKey(chave),
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddSeconds(120),
            signingCredentials: credencial
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }


}