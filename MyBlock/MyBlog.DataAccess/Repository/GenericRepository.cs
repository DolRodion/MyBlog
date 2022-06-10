using Microsoft.EntityFrameworkCore;
using Myblog.DataAccess.Interfaces;
using MyBlog.DataAccess;
using MyBlog.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myblog.DataAccess.Repository
{
    /// <summary>
    /// Нижний уроверь работы с бд через контекст данных
    /// </summary>
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntities
    {
        private readonly DbCheckContext _checkContext;

        public GenericRepository(DbCheckContext checkContext)
        {
            _checkContext = checkContext;
        }

        /// <summary>
        /// Получение сущности через AsQueryable
        /// </summary>
        public IQueryable<T> AsQueryable()  //?
        {
            return _checkContext.Set<T>().AsQueryable();
        }

        /// <summary>
        /// Запрос на удаление выбранной записи по ID
        /// </summary>
        public async Task DeleteAsync(int? id)
        {
            T entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _checkContext.Set<T>().Remove(entity);
                await _checkContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Запрос на добавление новой записи
        /// </summary>
        public async Task InsertAsync(T entity)
        {
            await _checkContext.AddAsync(entity);
        }

        /// <summary>
        /// Обновление БД
        /// </summary>
        public async Task SaveChangesAsync()
        {
            await _checkContext.SaveChangesAsync();
        }

        /// <summary>
        /// Получение выбранной записи по ключевому полю
        /// </summary>
        public async Task<T> GetByIdAsync(int? id)
        {
            return await _checkContext.Set<T>().FindAsync(id);
        }
    }
}
