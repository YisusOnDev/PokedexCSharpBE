using PokedexWebBE.Core.Common;
using PokedexWebBE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexWebBE.DAL.Contracts
{
    public interface IUserRepository
    {
        public GenericAPIResponse<bool> Create(User user);
    }
}
