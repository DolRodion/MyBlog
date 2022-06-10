using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.Entities
{
    public class Comment : BaseEntities
    {
        /// <summary>
        /// Текст комментария
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Имя автора
        /// </summary>
        public string AvtorName { get; set; }

        /// <summary>
        /// Дата создания коммента
        /// </summary>
        public DateTime CommentDate { get; set; }

        /// <summary>
        /// Id записи
        /// </summary>
        public int? CheckId { get; set; }

        public Check Check { get; set; }
    }
}
