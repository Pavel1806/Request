using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RequestForm.Web.ViewModel
{
    /// <summary>
    /// Необходимые данные для корректировки заявки
    /// </summary>
    public class ModelEditRequest
    {
        /// <summary>
        /// Номер заявки
        /// </summary>
        /// 
        [Required]
        public int Number { get; set; }
        /// <summary>
        /// Дата создания заявки
        /// </summary>
        /// 
        [Required]
        public DateTime DateTime { get; set; }
        /// <summary>
        /// Имя 
        /// </summary>
        /// 
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        [Required]
        [StringLength(20, ErrorMessage = "Максимальная длина 20 символов")]
        public string SerName { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        /// 
        [Required]
        public string Position { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        /// 
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
    }
}
