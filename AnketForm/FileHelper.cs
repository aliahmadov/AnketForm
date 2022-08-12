using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnketForm
{
    public class FileHelper
    {
        static public void SerializeDatabase(User user)
        {
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter($@"{user.FileName}.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;
                    serializer.Serialize(jw, user);
                }
            }

        }

        public static User DeserializeDatabase(User user)
        {
            var serializer = new JsonSerializer();

            using (var sr = new StreamReader($@"{user.FileName}.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    return serializer.Deserialize<User>(jr);
                }
            }



        }
    }
}
