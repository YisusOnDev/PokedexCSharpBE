using MySql.Data.MySqlClient;
using PokedexWebBE.Core.Common;
using PokedexWebBE.DAL.Contracts;
using PokedexWebBE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexWebBE.DAL.Implementations
{
    public class PokemonRepository : IPokemonRepository
    {
        public List<Pokemon> pokeList;
        public PokedexWebContext context { get; set; }
        public PokemonRepository(PokedexWebContext context)
        {
            this.context = context;
        }

        public GenericAPIResponse<List<Pokemon>> GetAllPokemon()
        {
            using (MySqlConnection conn = context.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM pokemon", conn);
                pokeList = new List<Pokemon>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pokemon pokeToAdd = new Pokemon(reader.GetInt32("Numero"),reader.GetString("Nombre"), reader.GetString("Descripcion"), reader.GetFloat("Altura"), reader.GetFloat("Peso"), reader.GetString("Habilidad"), reader.GetString("Categoria"), reader.GetString("ImagenURL"), reader.GetString("SonidoURL"), getPokemonTypes(reader.GetString("Nombre")));
                        pokeList.Add(pokeToAdd);
                       
                    }
                    return new GenericAPIResponse<List<Pokemon>>(pokeList); 
                }
            }

            return null;
        }

        public String getPokemonTypes(String pokeName)
        {
            using (MySqlConnection conn = context.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT p.numero, t.tipo from tipos t INNER JOIN pokemon_tipos pt ON pt.codigotipo = t.codTipo INNER JOIN pokemon p ON p.numero = pt.numero WHERE p.Nombre = '" + pokeName + "'", conn);
                List<String> pokeTypes = new List<String>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pokeTypes.Add(reader.GetString("tipo"));
                    }

                    String toReturnTypes = "";
                    foreach (String type in pokeTypes)
                    {
                      toReturnTypes += " " + type + " ";
                    }

                    return toReturnTypes;
                }
            }
            return null;
        }

        public GenericAPIResponse<bool> DeletePokemon(int pokemonId)
        {
            try
            {
                using (MySqlConnection conn = context.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(null, conn);
                    cmd.CommandText = "DELETE FROM pokemon WHERE Numero = ?pokemonId";
                    cmd.Parameters.Add("?pokemonId", MySqlDbType.Int32).Value = pokemonId;
                    cmd.ExecuteNonQuery();
                    return new GenericAPIResponse<bool>(true);
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == (int)MySqlErrorCode.ParseError)
                {
                    return new GenericAPIResponse<bool>(new Exception("IdNotExist"));
                }
                else
                {
                    return new GenericAPIResponse<bool>(ex);
                }
            }
            catch (Exception ex)
            {
                return new GenericAPIResponse<bool>(ex);
            }
            return new GenericAPIResponse<bool>(false);
        }

    }
}
