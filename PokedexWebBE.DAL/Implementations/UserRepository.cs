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
    public class UserRepository : IUserRepository
    {
        public PokedexWebContext context { get; set; }
        public UserRepository(PokedexWebContext context)
        {
            this.context = context;
        }

        public GenericAPIResponse<bool> Create(User user)
        {
            try
            {
                using (MySqlConnection conn = context.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(null, conn);
                    cmd.CommandText = "INSERT INTO users(Username,Password,IsAdmin) VALUES(?username,?password, 0)";
                    cmd.Parameters.Add("?username", MySqlDbType.VarChar).Value = user.Username;
                    cmd.Parameters.Add("?password", MySqlDbType.VarChar).Value = user.Password;
                    cmd.ExecuteNonQuery();
                    return new GenericAPIResponse<bool>(true);
                }
            }
            catch(MySqlException ex)
            {
                if (ex.Number == (int) MySqlErrorCode.DuplicateKeyEntry)
                {
                    return new GenericAPIResponse<bool>(new Exception("DuplicateUser"));
                }
                else
                {
                    return new GenericAPIResponse<bool>(ex);
                }
            }
            catch(Exception ex)
            {
                return new GenericAPIResponse<bool>(ex);
            }
        }
    }
}
