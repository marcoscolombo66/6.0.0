using Abp.Application.Services.Dto;
using Abp.AutoMapper;
namespace Futbol3.Equipos
{
    [AutoMapFrom(typeof(Equipo))]
    public class EquipoDto : EntityDto<int> {
        public string Nombre_equipo { get; set; }
        public string Categoria { get; set; }

        public string Campeonatos { get; set; }
    }
}
