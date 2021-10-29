using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForm.BLL.DTO
{
    /// <summary>
    /// Информация о заявке
    /// </summary>
    public class RequestDTO
    {
        public int Number { get; set; }
        public string DateTime { get; set; }
        public string Name { get; set; }
        public string SerName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
    }
}
