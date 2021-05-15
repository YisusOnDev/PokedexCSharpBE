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
            return PokemonRepository.DeletePokemon(pokemonDTO.id);
        }

        public GenericAPIResponse<bool> UpdatePokemon(PokemonDTO pokemonDTO)
        {
            var pokemon = new Pokemon
            (
                pokemonDTO.id,
                pokemonDTO.name,
                pokemonDTO.description,
                pokemonDTO.height,
                pokemonDTO.weight,
                pokemonDTO.ability,
                pokemonDTO.category,
                pokemonDTO.imageUrl,
                pokemonDTO.soundUrl,
                pokemonDTO.Types
            );
            return PokemonRepository.UpdatePokemon(pokemon);
        }
        public GenericAPIResponse<bool> InsertPokemon(PokemonDTO pokemonDTO)
        {
            var pokemon = new Pokemon
            (
                pokemonDTO.name,
                pokemonDTO.description,
                pokemonDTO.height,
                pokemonDTO.weight,
                pokemonDTO.ability,
                pokemonDTO.category,
                pokemonDTO.imageUrl,
                pokemonDTO.soundUrl,
                pokemonDTO.Types
            );
            return PokemonRepository.InsertPokemon(pokemon);
        }
    }
}
