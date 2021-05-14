using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokedexWebBE.BL.Contracts;
using PokedexWebBE.BL.Implementations;
using PokedexWebBE.Core.Common;
using PokedexWebBE.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokedexWebBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserBL UserBL { get; set; }

        public UserController(IUserBL userBL)
        {
            this.UserBL = userBL;
        }

        [HttpPost]
        public GenericAPIResponse<bool> Create(UserDTO userDTO) 
        {
            return UserBL.Create(userDTO);
        }
    }
}
