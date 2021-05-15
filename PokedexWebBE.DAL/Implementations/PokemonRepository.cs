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
                        Pokemon pokeToAdd = new Pokemon(reader.GetInt32("Numero"), reader.GetString("Nombre"), reader.GetString("Descripcion"), reader.GetFloat("Altura"), reader.GetFloat("Peso"), reader.GetString("Habilidad"), reader.GetString("Categoria"), reader.GetString("ImagenURL"), reader.GetString("SonidoURL"), reader.GetString("Tipos"));
                        pokeList.Add(pokeToAdd);

                    }
                    return new GenericAPIResponse<List<Pokemon>>(pokeList);
                }
            }
        }

        public GenericAPIResponse<bool> DeletePokemon(int pokemonId)
        {
            try
            {
                using (MySqlConnection conn = context.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(null, conn);
                    cmd.CommandText = "DELETE FROM pokemon WHERE Numero = ?pokemonId ;";
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
        }

        public GenericAPIResponse<bool> UpdatePokemon(Pokemon pokemon)
        {
            try
            {
                using (MySqlConnection conn = context.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(null, conn);
                    cmd.CommandText = "UPDATE pokemon SET Nombre = ?pokemonName, Descripcion = ?pokemonDesc, Altura = ?pokemonHeight, Peso = ?pokemonWeight, Categoria = ?pokemonCategory, Habilidad = ?pokemonAbility, Tipos = ?pokemonTypes, ImagenURL = ?pokemonImage, SonidoURL = ?pokemonSound  WHERE Numero = ?pokemonId;";
                    cmd.Parameters.Add("?pokemonId", MySqlDbType.Int32).Value = pokemon.id;
                    cmd.Parameters.Add("?pokemonName", MySqlDbType.String).Value = pokemon.name;
                    cmd.Parameters.Add("?pokemonDesc", MySqlDbType.String).Value = pokemon.description;
                    cmd.Parameters.Add("?pokemonHeight", MySqlDbType.Float).Value = pokemon.height;
                    cmd.Parameters.Add("?pokemonWeight", MySqlDbType.Float).Value = pokemon.weight;
                    cmd.Parameters.Add("?pokemonCategory", MySqlDbType.String).Value = pokemon.category;
                    cmd.Parameters.Add("?pokemonAbility", MySqlDbType.String).Value = pokemon.ability;
                    cmd.Parameters.Add("?pokemonTypes", MySqlDbType.String).Value = pokemon.Types;
                    cmd.Parameters.Add("?pokemonImage", MySqlDbType.String).Value = pokemon.imageUrl;
                    cmd.Parameters.Add("?pokemonSound", MySqlDbType.String).Value = pokemon.soundUrl;
                    cmd.ExecuteNonQuery();
                    return new GenericAPIResponse<bool>(true);
                }
            }
            catch (MySqlException ex)
            {
                return new GenericAPIResponse<bool>(ex);
            }
            catch (Exception ex)
            {
                return new GenericAPIResponse<bool>(ex);
            }
        }

        public GenericAPIResponse<bool> InsertPokemon(Pokemon pokemon)
        {
            try
            {
                using (MySqlConnection conn = context.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(null, conn);
                    cmd.CommandText = "INSERT INTO pokemon (`Nombre`, `Descripcion`, `Altura`, `Peso`, `Categoria`, `Habilidad`, `Tipos`, `ImagenURL`, `SonidoURL`) VALUES (?pokemonName, ?pokemonDesc, ?pokemonHeight, ?pokemonWeight, ?pokemonCategory, ?pokemonAbility, ?pokemonTypes, ?pokemonImage, ?pokemonSound);";
                    cmd.Parameters.Add("?pokemonName", MySqlDbType.String).Value = pokemon.name;
                    cmd.Parameters.Add("?pokemonDesc", MySqlDbType.String).Value = pokemon.description;
                    cmd.Parameters.Add("?pokemonHeight", MySqlDbType.Float).Value = pokemon.height;
                    cmd.Parameters.Add("?pokemonWeight", MySqlDbType.Float).Value = pokemon.weight;
                    cmd.Parameters.Add("?pokemonCategory", MySqlDbType.String).Value = pokemon.category;
                    cmd.Parameters.Add("?pokemonAbility", MySqlDbType.String).Value = pokemon.ability;
                    cmd.Parameters.Add("?pokemonTypes", MySqlDbType.String).Value = pokemon.Types;
                    cmd.Parameters.Add("?pokemonImage", MySqlDbType.String).Value = pokemon.imageUrl;
                    cmd.Parameters.Add("?pokemonSound", MySqlDbType.String).Value = pokemon.soundUrl;
                    cmd.ExecuteNonQuery();
                    return new GenericAPIResponse<bool>(true);
                }
            }
            catch (MySqlException ex)
            {
                return new GenericAPIResponse<bool>(ex);
            }
            catch (Exception ex)
            {
                return new GenericAPIResponse<bool>(ex);
            }
        }

    }
}
