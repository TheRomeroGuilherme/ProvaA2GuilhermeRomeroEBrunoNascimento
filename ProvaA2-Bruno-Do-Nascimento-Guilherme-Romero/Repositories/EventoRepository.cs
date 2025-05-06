using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProvaA2_Bruno_Do_Nascimento_Guilherme_Romero.Models;
using ProvaA2_Bruno_Do_Nascimento_Guilherme_Romero.Data;
namespace ProvaA2_Bruno_Do_Nascimento_Guilherme_Romero.Repositories;


    public class EventoRepository
    {
        private readonly ApplicationDbContext _banco;
    public EventoRepository(ApplicationDbContext banco)
    {
        _banco = banco;
    }
    public void Cadastrar(Evento evento)
    {
        _banco.Eventos.Add(evento);
        _banco.SaveChanges();
    }
   
    public List<Evento> Listar()
    {
        return _banco.Eventos.ToList();
    }
    }
