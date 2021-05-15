using PokedexWebBE.Core.Common;
using PokedexWebBE.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexWebBE.BL.Contracts
{
    public interface IPokemonBL
    {
        public GenericAPIResponse<List<Pokemon>> GetAllPokemon();
        public GenericAPIResponse<bool> DeletePokemon(PokemonDTO pokemonDTO);
        public GenericAPIResponse<bool> UpdatePokemon(PokemonDTO pokemonDTO);
        public GenericAPIResponse<bool> InsertPokemon(PokemonDTO pokemonDTO);
    }
}
