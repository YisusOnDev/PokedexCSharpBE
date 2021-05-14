using PokedexWebBE.BL.Contracts;
using PokedexWebBE.Core.Common;
using PokedexWebBE.Core.DTO;
using PokedexWebBE.DAL.Contracts;
using PokedexWebBE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexWebBE.BL.Implementations
{
    public class UserBL : IUserBL
    {
        public IUserRepository UserRepository { get; set; }
        public UserBL(IUserRepository UserRepository)
        {
            this.UserRepository = UserRepository;
        }

        public GenericAPIResponse<bool> Create(UserDTO userDTO)
        {
            var userToRegister = new User
            {
                Username = userDTO.Username,
                Password = userDTO.Password

            };
            return UserRepository.Create(userToRegister);
        }
    }
}
