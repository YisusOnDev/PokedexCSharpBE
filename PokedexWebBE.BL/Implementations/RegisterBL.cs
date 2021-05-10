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
            Console.WriteLine(registerDTO.Username, registerDTO.Password);
            return RegisterRepository.Register(registerDTO.Username, registerDTO.Password);
        }
    }
}
