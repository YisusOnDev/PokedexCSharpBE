using MySql.Data.MySqlClient;
using PokedexWebBE.DAL.Contracts;
using PokedexWebBE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexWebBE.DAL.Implementations
{
    public class RegisterRepository : IRegisterRepository
    {
        public PokedexWebContext context { get; set; }
        public RegisterRepository(PokedexWebContext context)
        {
            this.context = context;
        }

        public bool Register(String username, String password)
        {
            using (MySqlConnection conn = context.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(String.Format("INSERT INTO users VALUES({0}, {1}, 0)", username, password), conn);
                cmd.ExecuteNonQuery();

                /*using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return true;
                    }
                }*/
            }

            return true;
        }
    }
}
