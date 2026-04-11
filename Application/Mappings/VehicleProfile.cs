using AppCore.DTO_s;
using AutoMapper;
using Domain.Entities;

namespace AppCore.Mappings;

public class VehicleProfile : Profile
{
    public VehicleProfile()
    {
        CreateMap<Vehicle, VehicleDto>();
    }
}