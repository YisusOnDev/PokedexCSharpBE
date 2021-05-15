using PokedexWebBE.Core.Common;
using PokedexWebBE.Core.DTO;
using PokedexWebBE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexWebBE.DAL.Contracts
{
    public interface IPokemonRepository
    {
        public GenericAPIResponse<List<Pokemon>> GetAllPokemon();
        public GenericAPIResponse<bool> DeletePokemon(int id);
        public GenericAPIResponse<bool> UpdatePokemon(Pokemon pokemon);
        public GenericAPIResponse<bool> InsertPokemon(Pokemon pokemon);
    }
}
