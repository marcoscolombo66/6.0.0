using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
namespace Futbol3.Equipos
{
    //public class EquiposAppService : CrudAppService<Equipo, EquipoDto>
    public class EquiposAppService : CrudAppService<Equipo, EquipoDto>
    {
        public EquiposAppService(IRepository<Equipo, int> repository) : base(repository)
        { }
    }
}
