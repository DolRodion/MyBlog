using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.Entities
{
    public  class Employee : BaseEntities
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        ///  Имя пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///  Фамилия пользователя
        /// </summary>
        public string? MiddleName { get; set; }

        /// <summary>
        ///  Отчество пользователя
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        ///  Email пользователя
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Записи пользователя
        /// </summary>
        public ICollection<Check> Checks { get; set; }

        public Employee()
        {
            Checks = new List<Check>();
        }
    }
}
