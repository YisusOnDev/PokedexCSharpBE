using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokedexWebBE.BL.Contracts;
using PokedexWebBE.BL.Implementations;
using PokedexWebBE.Core.Common;
using PokedexWebBE.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PokedexWebBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        public IPokemonBL PokemonBL { get; set; }

        public PokemonController(IPokemonBL pokemonBL)
        {
            this.PokemonBL = pokemonBL;
        }
        
        [HttpPost]
        [Route("getallpokemon")]
        public GenericAPIResponse<List<Pokemon>> GetAllPokemon()
        {
            return PokemonBL.GetAllPokemon();
        }

        [HttpDelete]
        [Route("deletepokemon")]
        public GenericAPIResponse<bool> DeletePokemon(PokemonDTO pokemonDTO)
        {
            return PokemonBL.DeletePokemon(pokemonDTO);
        }

        [HttpPut]
        [Route("updatepokemon")]
        public GenericAPIResponse<bool> UpdatePokemon(PokemonDTO pokemonDTO)
        {
            return PokemonBL.UpdatePokemon(pokemonDTO);
        }

        [HttpPost]
        [Route("insertpokemon")]
        public GenericAPIResponse<bool> InsertPokemon(PokemonDTO pokemonDTO)
        {
            return PokemonBL.InsertPokemon(pokemonDTO);
        }
    }

}
