using PokedexWebBE.BL.Contracts;
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
    public class RegisterBL : IRegisterBL
    {
        public IRegisterRepository RegisterRepository { get; set; }
        public RegisterBL(IRegisterRepository RegisterRepository)
        {
            this.RegisterRepository = RegisterRepository;
        }

        public bool Register(RegisterDTO registerDTO)
        {
            var user = new User
            {
                Username = registerDTO.Username,
                Password = registerDTO.Password
            };
            return RegisterRepository.Register(user);
        }
    }
}
