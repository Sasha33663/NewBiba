using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Domain;

namespace Domain
{
    public class User
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Note> Notes { get; set; }
    }

}
