using AutoMapper;

namespace CRUD_App.AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Models.Customer, ViewModels.Customer.CustomerIndexViewModel>();
        }
    }
}
