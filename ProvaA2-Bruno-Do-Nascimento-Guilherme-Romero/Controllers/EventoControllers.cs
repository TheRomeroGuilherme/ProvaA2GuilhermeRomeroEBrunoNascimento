using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProvaA2_Bruno_Do_Nascimento_Guilherme_Romero.Data;
using ProvaA2_Bruno_Do_Nascimento_Guilherme_Romero.Models;
using ProvaA2_Bruno_Do_Nascimento_Guilherme_Romero.Repositories;
using Microsoft.AspNetCore.Authorization;
namespace ProvaA2_Bruno_Do_Nascimento_Guilherme_Romero.Controllers
{
    [Route("/eventos")]
    public class EventoControllers : ControllerBase
    {
    public ApplicationDbContext banco;
    private readonly EventoRepository eventoRepositorio;
    private readonly IConfiguration config;
    public EventoControllers(EventoRepository eventoRepository,
        IConfiguration configuration)
    {
        eventoRepositorio = eventoRepository;
        config = configuration;
    }

    [HttpPost("cadastrar")]
    [Authorize]
    public IActionResult Cadastrar([FromBody] Evento evento)
    {
        eventoRepositorio.Cadastrar(evento);
        return Created("", evento);
    }

    

    [HttpGet("listar")]
    public IActionResult Listar()
    {
        return Ok(eventoRepositorio.Listar());
    }
    }
} 
