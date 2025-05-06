using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProvaA2_Bruno_Do_Nascimento_Guilherme_Romero.Data;
namespace ProvaA2_Bruno_Do_Nascimento_Guilherme_Romero.Models
{
    public class Evento
    {
     public int Id{get; set;}
     public string nome{get; set;} = string.Empty;
     public string local{get; set;} = string.Empty;
     public DateTime Data{get; set;}
     public DateTime CriadoEm{get; set;} = DateTime.Now;
     public int UsuarioId{get; set;}
     public Usuario? usuario{get; set;} = null;
    }
}