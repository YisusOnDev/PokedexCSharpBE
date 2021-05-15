using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexWebBE.Core.DTO
{
    public class PokemonDTO
    {
        public int id { get; set; }
        public String name { get; set; }
        public String description { get; set; }
        public float height { get; set; }
        public float weight { get; set; }
        public String ability { get; set; }
        public String category { get; set; }
        public String imageUrl { get; set; }
        public String soundUrl { get; set; }
        public String Types { get; set; }
    }
}
