using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender
{

    [Serializable]
    public class UserData
    {
        public string UserMail { get; set; }
        public string Password { get; set; }


        public UserData(string myMail, string myPass)
        {
            this.UserMail = myMail;
            this.Password = myPass;
        }
    }
}
