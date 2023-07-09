using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.StateHelpers
{
    public class StateManager :IStateManager
    {
        public EmailDataToResponse LastData { get; set; }
        private int mStatus { get; set; }
        public StateManager()
        {
            LastData = new EmailDataToResponse() { Email = "", DateTime = new DateTime() };
           
        }
        public  EmailDataToResponse GetCorrectResponse(string email)
        {
            DateTime currentDate = DateTime.Now;
         
            double diff = (currentDate - LastData.DateTime).TotalSeconds;
            EmailDataToResponse theResponse;
            if (diff>=3)
            {
                 theResponse = new EmailDataToResponse() { DateTime = currentDate, Email = email };
                LastData = theResponse;
                mStatus = 200;
            }
            else
            {
                theResponse = LastData;
                mStatus = 497;
            }

            return theResponse;
        }

        public int GetStatusCode()
        {
            return mStatus;
        }
    }
}
