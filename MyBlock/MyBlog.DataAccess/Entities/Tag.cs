using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.DataAccess.Entities
{
    public class Tag : BaseEntities
    {
        /// <summary>
        /// Название тега
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Записи с этим тэгом
        /// </summary>
        public ICollection<Check> Checks { get; set; }

        public Tag(string name)
        {
            Name = name;
            Checks = new List<Check>();
        }
    }
}
