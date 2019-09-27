using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.Temp;
using UnitTestsMail;
using UnitTestsMail.Entities;

namespace UnitTestProject1.Utils
{
    public class EntitiesManager
    {
        public static User GetUser()
        {
            User user = new User();
            user.Login = Config.LOGIN;
            user.Password = Config.PASSWORD;
            return user;
        }

        public static List<Recipient> GetRecipients()
        {
            List<Recipient> recipients = new List<Recipient>();
            foreach (string email in Config.Emails)
            {
                Recipient recipient = new Recipient();
                recipient.Email = email;
                recipients.Add(recipient);
            }

            return recipients;
        }
    }
}
