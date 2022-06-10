using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.DataAccess.Entities
{
    public class Check : BaseEntities
    {
        /// <summary>
        /// Дата создания записи
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Название записи
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ссылка на картинку/видео на YouTube
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Описание записи
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Проверка фото/видео записи
        /// </summary>
        public bool IsCheckedVideoUrl { get; set; }

        /// <summary>
        /// Автор записи
        /// </summary>
        public string CheckAuthor { get; set; }

        /// <summary>
        /// В архиве/нет
        /// </summary>
        public bool IsArhival { get; set; }

        /// <summary>
        /// Id пользователя записи
        /// </summary>
        public int? EmployeeId { get; set; }

        public Employee Employee { get; set; }

        /// <summary>
        /// Теги записи
        /// </summary>
        public ICollection<Tag> Tags { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public Check()
        {
            Tags = new List<Tag>();
            Comments = new List<Comment>();
        }
    }
}
