using AutoMapper;
using Boia.API.Data.DTO;
using Boia.API.Models;
using System.Linq;

namespace Boia.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDTO>()
                .ForMember(property => property.PhotoUrl, options => options.MapFrom(
                    source => source.Photos.FirstOrDefault(photo => photo.IsMain).Url))
                .ForMember(property => property.Age, options => options.MapFrom(
                    source => source.DateOfBirth.CalculateAge()));

            CreateMap<User, UserForDetailedDTO>()
                .ForMember(property => property.PhotoUrl, options => options.MapFrom(
                    source => source.Photos.FirstOrDefault(photo => photo.IsMain).Url))
                .ForMember(property => property.Age, options => options.MapFrom(
                    source => source.DateOfBirth.CalculateAge()));

            CreateMap<Photo, PhotosForDetailedDTO>();
        }
    }
}
