﻿using PokedexWebBE.BL.Contracts;
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
    public class LoginBL : ILoginBL
    {
        public ILoginRepository LoginRepository { get; set; }
        public LoginBL(ILoginRepository LoginRepository)
        {
            this.LoginRepository = LoginRepository;
        }

        public bool Login(LoginDTO loginDTO)
        {
            var usuario = new User
            {
                Username = loginDTO.Username,
                Password = loginDTO.Password
            };
            return LoginRepository.Login(usuario);
        }
    }
}
