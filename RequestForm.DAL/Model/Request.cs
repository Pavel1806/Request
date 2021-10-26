using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForm.DAL.Model
{
    public class Request
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        public string SerName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }

        public Request()
        { }
    }
}
