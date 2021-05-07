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
    public class LoginRepository : ILoginRepository
    {
        public PokedexWebContext context { get; set; }
        public LoginRepository(PokedexWebContext context)
        {
            this.context = context;
        }

        public bool Login(User username)
        {
            using (MySqlConnection conn = context.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(String.Format("select * from users " +
                                                    "where username = '{0}' and" +
                                                    " password = '{1}'", username.Username, username.Password), conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
