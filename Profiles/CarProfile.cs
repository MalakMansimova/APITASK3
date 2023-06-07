using AutoMapper;
using WEB_API.Entities;
using WEB_API.Entities.Dtos.Cars;

namespace WEB_API.Profiles
{
    public class CarProfile:Profile
    {
        public CarProfile()
        {
            CreateMap<Car,GetCarDto>();
            CreateMap<CreateCarDto,Car>();
            CreateMap<UpdateCarDto, Car>();

        }

    }
}
