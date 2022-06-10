using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Params
{
    public class FormAddCheckParams
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
        /// Проверка фото/видео записи
        /// </summary>
        public bool? IsCheckedVideoUrl { get; set; }

        /// <summary>
        /// Ссылка на картинку/видео на YouTube
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Описание записи
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Теги записи
        /// </summary>
        public string[] Tags { get; set; }
    }
}
