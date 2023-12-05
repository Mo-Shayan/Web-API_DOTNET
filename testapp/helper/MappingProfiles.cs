using AutoMapper;
using testapp.Dto;
using testapp.Model;
namespace testapp.helper
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
                CreateMap<Pokemon, PokemonDto> ();
        }
    }
}
