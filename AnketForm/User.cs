using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnketForm
{
    public class User
    {
        public static int UserId { get; set; } = 0;
        public int Id { get; set; }
        public string Name { get; set; }

        public string FileName { get; set; }
        public string Surname { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public string Date { get; set; }

        public User()
        {
            Id = ++UserId;
        }

        public override string ToString()
        {
            return $"{Name}  {Surname}";
        }
    }
}
