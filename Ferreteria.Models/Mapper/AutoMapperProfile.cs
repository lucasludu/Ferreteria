using Ferreteria.Models.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Ferreteria.Models.Mapper
{
    public static class AutoMapperProfile
    {

        #region Local --> LocalDto

        public static LocalDto LocalToLocalDto(Local local)
        {
            return new LocalDto(
                    local.Nombre,
                    local.Direccion,
                    local.Telefono
                );
        }

        public static List<LocalDto> ListLocalToListLocalDto(List<Local> list)
        {
            return list.Select(a => LocalToLocalDto(a)).ToList();
        }

        #endregion

        #region LocalDto --> Local

        public static Local LocalDtoToLocal(LocalDto localDto)
        {
            return new Local(
                    localDto.Nombre,
                    localDto.Direccion,
                    localDto.Telefono
                );
        }

        public static List<Local> ListLocalDtoToListLocal(List<LocalDto> listDto)
        {
            return listDto.Select(a => LocalDtoToLocal(a)).ToList();
        }

        #endregion

    }
}
