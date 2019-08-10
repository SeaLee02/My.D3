using AutoMapper;
using Microsoft.EntityFrameworkCore;
using My.D3.DataAccess.Framework;
using My.D3.Entity.Framework.Entity;
using My.D3.Util.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace My.D3.Application.Repositories
{
    public class EfCoreRepositoryBase<TEntity, TPrimaryKey>  //一个类用来继承IRepositories
          where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly MyDbContext _db;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbContext"></param>
        public EfCoreRepositoryBase(MyDbContext dbContext)
        {
            _db = dbContext;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        //public EfCoreRepositoryBase(MyDbContext db)
        //{
        //    this._db = db;
        //}

        public virtual DbSet<TEntity> Table => _db.Set<TEntity>();

        /// <summary>
        /// 获取该表的所有数据
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetAll()
        {
            return this.GetAllIncluding(Array.Empty<Expression<Func<TEntity, object>>>());
        }

        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            IQueryable<TEntity> queryable = ((IEnumerable<TEntity>)Table).AsQueryable();
            if (!CollectionEx.IsNullOrEmpty<Expression<Func<TEntity, object>>>(propertySelectors))
            {
                foreach (Expression<Func<TEntity, object>> expression in propertySelectors)
                {
                    queryable = queryable.Include<TEntity, object>(expression);
                }
            }
            return queryable;
        }

        public async Task<List<TEntity>> GetAllListAsync()
        {
            // return await GetAll().ToListAsync();
            return await EntityFrameworkQueryableExtensions.ToListAsync<TEntity>(this.GetAll(), default(CancellationToken));
        }

        public async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            // return await GetAll().Where(predicate).ToListAsync();
            return await EntityFrameworkQueryableExtensions.ToListAsync<TEntity>(this.GetAll().Where(predicate), default(CancellationToken));
        }


        public virtual async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            TEntity obj = await FirstOrDefaultAsync(id);
            return obj;
        }

        public virtual TEntity FirstOrDefault(TPrimaryKey id)
        {
            return GetAll().FirstOrDefault(CreateEqualityExpressionForId(id));
        }


        public async Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            //return await GetAll().FirstOrDefaultAsync(CreateEqualityExpressionForId(id));
            return await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync<TEntity>(this.GetAll(), this.CreateEqualityExpressionForId(id), default(CancellationToken));
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            //return await GetAll().FirstOrDefaultAsync(predicate);
            return await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync<TEntity>(this.GetAll(), predicate, default(CancellationToken));
        }
        public TEntity Insert(TEntity entity)
        {
            return Table.Add(entity).Entity;
        }

        public Task<TEntity> InsertAsync(TEntity entity)
        {
            return Task.FromResult(Insert(entity));
        }

        public TEntity Update(TEntity entity)
        {
            AttachIfNot(entity);
            _db.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            entity = Update(entity);
            return Task.FromResult(entity);
        }


        protected virtual void AttachIfNot(TEntity entity)
        {
            var entry = _db.ChangeTracker.Entries().FirstOrDefault(ent => ent.Entity == entity);
            if (entry != null)
            {
                return;
            }

            Table.Attach(entity);
        }


        public void Delete(TEntity entity)
        {
            AttachIfNot(entity);
            Table.Remove(entity);
        }


        public void Delete(TPrimaryKey id)
        {
            var entity = GetFromChangeTrackerOrNull(id);
            if (entity != null)
            {
                Delete(entity);
                return;
            }

            entity = FirstOrDefault(id);
            if (entity != null)
            {
                Delete(entity);
                return;
            }
        }


        public virtual Task DeleteAsync(TEntity entity)
        {
            Delete(entity);
            return Task.FromResult(0);
        }


        public virtual Task DeleteAsync(TPrimaryKey id)
        {
            Delete(id);
            return Task.FromResult(0);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            foreach (TEntity item in GetAll().Where(predicate).ToList())
            {
                Delete(item);
            }
        }

        public virtual Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            Delete(predicate);
            return Task.FromResult(0);
        }


        private TEntity GetFromChangeTrackerOrNull(TPrimaryKey id)
        {
            var entry = _db.ChangeTracker.Entries()
                .FirstOrDefault(
                    ent =>
                        ent.Entity is TEntity &&
                        EqualityComparer<TPrimaryKey>.Default.Equals(id, (ent.Entity as TEntity).Id)
                );

            return entry?.Entity as TEntity;
        }






        /// <summary>
        /// 根据主键查询构建lambdaParam参数
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        private Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
        {
            ParameterExpression lambdaParam = Expression.Parameter(typeof(TEntity));
            BinaryExpression lambdaBody = Expression.Equal(Expression.PropertyOrField(lambdaParam, "Id"), Expression.Constant(id, typeof(TPrimaryKey)));
            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }
    }
}
