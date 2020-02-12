using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace SaintSender
{
    class DataService
    {
        public static void SerializeUserData(string email, string password)
        {
            try
            {
                if (!Directory.Exists(@"AppData")) Directory.CreateDirectory(@"AppData");
                BinaryFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(@"AppData\login.dat", FileMode.Create, FileAccess.Write);

                formatter.Serialize(stream, new UserData(email, password));
                stream.Close();
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Access to folder denied.");
            }
        }

        public static UserData DeserializeUserData()
        {
            string input = @"AppData\login.dat";
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(input, FileMode.Open, FileAccess.Read);
            UserData userData = (UserData)formatter.Deserialize(stream);
            stream.Close();

            return userData;
        }

        public static bool IsValidMail(string email)
        {
            //return Regex.IsMatch(email, @"^\w+@(\w\.)+[a-z]{2,3}$");
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }
    }
}