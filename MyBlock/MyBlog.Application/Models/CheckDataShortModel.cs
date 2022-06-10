using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Models
{
    public class CheckDataShortModel
    {
        /// <summary>
        /// id модели
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название записи
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ссылка на картинку/видео на YouTube
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Проверка фото/видео записи
        /// </summary>
        public bool IsCheckedVideoUrl { get; set; }

        /// <summary>
        /// Описание записи
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Автор записи
        /// </summary>
        public string CheckAuthor { get; set; }

        /// <summary>
        /// Теги записи
        /// </summary>
        public string[] Tags { get; set; }
    }
}