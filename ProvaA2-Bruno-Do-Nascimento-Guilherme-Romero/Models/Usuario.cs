using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaA2_Bruno_Do_Nascimento_Guilherme_Romero.Models
{
    public class Usuario
    {
     public int Id{get; set;}
     public string email{get; set;} = string.Empty;
     public string senha{get; set;} = string.Empty;
     public DateTime CriadoEm = DateTime.Now;
    }
}