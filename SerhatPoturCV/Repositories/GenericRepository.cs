using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SerhatPoturCV.Models.Entity;

namespace SerhatPoturCV.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class, new()
    {
        //SerhatPoturCVEntities context = new SerhatPoturCVEntities();
        protected readonly SerhatPoturCVEntities _context;
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository(SerhatPoturCVEntities context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public List<TEntity> GetList()
        {
            return _dbSet.ToList();
        }
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();

        }
        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
           

        }
        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }
    }
}