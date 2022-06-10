using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Application.Models
{
    public  class CheckDataModel
    {
        /// <summary>
        /// id модели
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата создания записи
        /// </summary>
        public string CreateDate { get; set; }

        /// <summary>
        /// Проверка фото/видео записи
        /// </summary>
        public bool IsCheckedVideoUrl { get; set; }

        /// <summary>
        /// Название записи
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество комментариев записи
        /// </summary>
        public int CommentCount { get; set; }

        /// <summary>
        /// Ссылка на картинку/видео на YouTube
        /// </summary>
        public string ImageUrl { get; set; }

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
