using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.StateHelpers;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IStateManager stateManager;
        public ValuesController(IStateManager pStateManager)
        {
            stateManager = pStateManager;
        }
        [HttpGet]
        public int Get()
        {
            return 0;
        }
        
        [HttpPost("/Email")]
        public async Task<EmailDataToResponse> EmailAndDsteTime(RequestData requestData)
        {            
            EmailDataToResponse response = stateManager.GetCorrectResponse(requestData.Email);
            this.HttpContext.Response.StatusCode = stateManager.GetStatusCode();

            return  response;         
        }
    }
}
