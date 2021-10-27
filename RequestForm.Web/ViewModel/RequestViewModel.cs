using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestForm.Web.ViewModel
{
    /// <summary>
    /// Необходимые данные для создания заявки
    /// </summary>
    public class RequestViewModel
    {
        /// <summary>
        ///     Имя 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Фамилия
        /// </summary>
        public string SerName { get; set; }

        /// <summary>
        ///     Должность
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        ///     Email
        /// </summary>
        public string Email { get; set; }
    }
}
