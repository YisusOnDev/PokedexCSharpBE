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
    public class RegisterRepository : IRegisterRepository
    {
        public PokedexWebContext context { get; set; }
        public RegisterRepository(PokedexWebContext context)
        {
            this.context = context;
        }

        public GenericAPIResponse<bool> Register(User user)
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
                    var result = cmd.ExecuteNonQuery();
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
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new GenericAPIResponse<bool>(ex);
            }
            return new GenericAPIResponse<bool>(false);
        }
    }
}
