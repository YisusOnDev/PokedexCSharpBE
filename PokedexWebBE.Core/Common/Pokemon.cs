using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexWebBE.Core.Common
{
    public class Pokemon
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

        public Pokemon(int id, String name, String description, float height, float weight, String ability, String category, String imageUrl, String soundUrl, String types)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.height = height;
            this.weight = weight;
            this.ability = ability;
            this.category = category;
            this.imageUrl = imageUrl;
            this.soundUrl = soundUrl;
            this.Types = types;
        }
        public Pokemon(String name, String description, float height, float weight, String ability, String category, String imageUrl, String soundUrl, String types)
        {
            this.name = name;
            this.description = description;
            this.height = height;
            this.weight = weight;
            this.ability = ability;
            this.category = category;
            this.imageUrl = imageUrl;
            this.soundUrl = soundUrl;
            this.Types = types;
        }
    }
}
