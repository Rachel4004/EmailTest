using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.StateHelpers
{
    public interface IStateManager
    {
        public EmailDataToResponse GetCorrectResponse(string email);

        public int GetStatusCode();
    }
}
