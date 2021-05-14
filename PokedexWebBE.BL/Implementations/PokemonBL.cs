using PokedexWebBE.BL.Contracts;
using PokedexWebBE.Core.Common;
using PokedexWebBE.Core.DTO;
using PokedexWebBE.DAL.Contracts;
using PokedexWebBE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexWebBE.BL.Implementations
{
    public class PokemonBL : IPokemonBL
    {
        public IPokemonRepository PokemonRepository { get; set; }
        public PokemonBL(IPokemonRepository PokemonRepository)
        {
            this.PokemonRepository = PokemonRepository;
        }

        public GenericAPIResponse<List<Pokemon>> GetAllPokemon()
        {
            return PokemonRepository.GetAllPokemon();
        }
        public GenericAPIResponse<bool> DeletePokemon(PokemonDTO pokemonDTO)
        {
            return PokemonRepository.DeletePokemon(pokemonDTO.Id);
        }
    }
}
