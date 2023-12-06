using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.err_Models;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tools;

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
                IQueryable<TEntity> avatar = _dbSet;
                return avatar.ToList();

            }
            catch (Exception ex)
            {
                CustomException exx = new CustomException("Ocurrio un error al obtener toda la lista", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                throw exx;
            }
        }
        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            try
            {
                IQueryable<TEntity> query = _dbSet;
                return await query.ToListAsync();

            }
            catch (Exception ex)
            {
                CustomException exx = new CustomException("Ocurrio un error al obtener toda la lista Async", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                throw exx;
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
                CustomException exx = new CustomException("Ocurrio un error al buscar el registro por id", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                throw exx;
            }
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                CustomException exx = new CustomException("Ocurrio un error al buscar el registro por id Async", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                throw exx;
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
                CustomException exx = new CustomException("Error al registrar", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                throw exx;
            }
        }
        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _db.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                CustomException exx = new CustomException("Error al registrar Async", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                throw exx;
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
                CustomException exx = new CustomException("Error al actualizar", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                throw exx;
            }
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            try
            {
                _dbSet.Update(entity);
                await _db.SaveChangesAsync();
                return entity;

            }
            catch (Exception ex)
            {
                CustomException exx = new CustomException("Error al actualizar Async", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                throw exx;
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
                CustomException exx = new CustomException("Error al eliminar", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                throw exx;
            }
        }

        public virtual async Task<int> DeleteAsync(object id)
        {
            try
            {
                TEntity entityToDelete = await _dbSet.FindAsync(id);
                _dbSet.Remove(entityToDelete);
                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                CustomException exx = new CustomException("Error al eliminar", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                throw exx;
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
                CustomException exx = new CustomException("Error al actualizar multiple items", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                throw exx;
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
                CustomException exx = new CustomException("Error al eliminar multiple items", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                throw exx;
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
                CustomException exx = new CustomException("Error al insertar multiple", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                throw exx;
            }
        }
        public virtual async Task<List<TEntity>> insertMultipleAsyc(List<TEntity> lista)
        {
            try
            {
                await _dbSet.AddRangeAsync(lista);
                await _db.SaveChangesAsync();
                return lista;
            }
            catch (Exception ex)
            {
                CustomException exx = new CustomException("Error al insertar multiple Async", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                throw exx;
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
                CustomException exx = new CustomException("Error al actualizar multiple", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                throw exx;
            }
        }
        public virtual async Task<List<TEntity>> updateMultipleAsync(List<TEntity> lista)
        {
            try
            {
                _dbSet.UpdateRange(lista);
                await _db.SaveChangesAsync();
                return lista;
            }
            catch (Exception ex)
            {
                CustomException exx = new CustomException("Error al actualizar multiple Async: ", (int)HttpStatusCode.InternalServerError, 500, "No Controlado", ex);
                throw exx;
            }
        }
    }
}
