using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.genericRepository
{
    public class genericRepository<TEntity> where TEntity : class
    {
        internal _dbContext _db = new _dbContext();
        internal DbSet<TEntity> _dbSet;

        public genericRepository()
        {
            this._dbSet = _db.Set<TEntity>();
        }

        public virtual List<TEntity> GetAll()
        {
            try
            {
                IQueryable<TEntity> query = _dbSet;
                return query.ToList();

            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                //CustomException exx = new CustomException("Ocurrio un error al obtener toda la lista", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                //throw exx;
            }
        }

        public virtual TEntity GetById(object id)
        {
            try
            {
                return _dbSet.Find(id);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                //CustomException exx = new CustomException("Ocurrio un error al buscar el registro", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                //throw exx;
            }
        }

        public virtual TEntity Create(TEntity entity)
        {
            try
            {
                _dbSet.Add(entity);
                _db.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                //CustomException exx = new CustomException("Error al registrar", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                //throw exx;
            }
        }

        public virtual TEntity Update(TEntity entity)
        {
            try
            {
                _dbSet.Update(entity);
                _db.SaveChanges();
                return entity;

            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                //CustomException exx = new CustomException("Error al actualizar", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                //throw exx;
            }
        }

        public virtual int Delete(object id)
        {
            try
            {
                TEntity entityToDelete = _dbSet.Find(id);
                _dbSet.Remove(entityToDelete);
                return _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                //CustomException exx = new CustomException("Error al eliminar", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                //throw exx;
            }

        }

        public virtual int updateMultipleItems(List<TEntity> lista)
        {
            try
            {
                _dbSet.UpdateRange(lista);
                return _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                //CustomException exx = new CustomException("Error al actualizar multiple", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                //throw exx;
            }
        }

        public virtual int deleteMultipleItems(List<TEntity> lista)
        {
            try
            {
                _dbSet.RemoveRange(lista);
                return _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                //CustomException exx = new CustomException("Error al eliminar multiple", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                //throw exx;
            }

        }
        public virtual List<TEntity> insertMultiple(List<TEntity> lista)
        {
            try
            {
                _dbSet.AddRange(lista);
                _db.SaveChanges();
                return lista;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                //CustomException exx = new CustomException("Error al eliminar multiple", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                //throw exx;
            }
        }
        public virtual List<TEntity> updateMultiple(List<TEntity> lista)
        {
            try
            {
                _dbSet.UpdateRange(lista);
                _db.SaveChanges();
                return lista;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                //CustomException exx = new CustomException("Error al eliminar multiple", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                //throw exx;
            }
        }
    }
}
