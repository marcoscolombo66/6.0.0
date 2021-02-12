using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
namespace Futbol3.Equipos
{
   
    public class Equipo : Entity<int>
    {
           public string Nombre_equipo { get; set; }
        public string Categoria { get; set; }

        public string Campeonatos { get; set; }
    }
}
