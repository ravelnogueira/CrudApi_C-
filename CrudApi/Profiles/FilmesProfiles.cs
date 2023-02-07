using AluraAPI.Data.Dtos;
using AluraAPI.Migrations;
using AutoMapper;

namespace AluraAPI.Profiles
{
    public class FilmesProfiles : Profile
    {
        public FilmesProfiles() 
        {
            CreateMap<CreateFilme, Filme>();
            CreateMap<UpdateFilme, Filme>();

        }
    }
}
