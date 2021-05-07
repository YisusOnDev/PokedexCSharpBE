using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokedexWebBE.BL.Contracts;
using PokedexWebBE.BL.Implementations;
using PokedexWebBE.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexWebBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public ILoginBL LoginBL { get; set; }

        public LoginController(ILoginBL loginBL)
        {
            this.LoginBL = loginBL;
        }

        [HttpPost]
        public bool Login(LoginDTO loginDTO) 
        {
            return LoginBL.Login(loginDTO);
        }
    }
}
