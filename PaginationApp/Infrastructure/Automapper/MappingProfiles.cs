using AutoMapper;
using PaginationApp.Models.Paging;

namespace PaginationApp.Infrastructure.Automapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap(typeof(PagedResult<>), typeof(PagedResult<>));
        }
    }
}
