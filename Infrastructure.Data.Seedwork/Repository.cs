// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Repository.cs" company="">
//   
// </copyright>
// <summary>
//   Repository base class
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Infrastructure.Data.Seedwork
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using Phoenix.PhoenixApp.Domain.Seedwork;
    using Phoenix.PhoenixApp.Domain.Seedwork.Specification;
    using Phoenix.PhoenixApp.Infrastructure.Crosscutting.Logging;
    using Phoenix.PhoenixApp.Infrastructure.Data.Seedwork.Resources;

    /// <summary>
    /// Repository base class
    /// </summary>
    /// <typeparam name="TEntity">
    /// The type of underlying entity in this repository
    /// </typeparam>
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        #region Fields

        /// <summary>
        /// The _ unit of work.
        /// </summary>
        private readonly IQueryableUnitOfWork _UnitOfWork;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class. 
        /// Create a new instance of repository
        /// </summary>
        /// <param name="unitOfWork">
        /// Associated Unit Of Work
        /// </param>
        public Repository(IQueryableUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

            this._UnitOfWork = unitOfWork;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </summary>
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return this._UnitOfWork;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </summary>
        /// <param name="item">
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </param>
        public virtual void Add(TEntity item)
        {
            if (item != null)
            {
                this.GetSet().Add(item); // add new item in this set
            }
            else
            {
                LoggerFactory.CreateLog().LogInfo(Messages.info_CannotAddNullEntity, typeof(TEntity).ToString());
            }
        }

        /// <summary>
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </summary>
        /// <param name="specification">
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public virtual IEnumerable<TEntity> AllMatching(ISpecification<TEntity> specification)
        {
            return this.GetSet().Where(specification.SatisfiedBy());
        }

        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            if (this._UnitOfWork != null)
            {
                this._UnitOfWork.Dispose();
            }
        }

        /// <summary>
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </summary>
        /// <param name="id">
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        public virtual TEntity Get(Guid id)
        {
            if (id != Guid.Empty)
            {
                return this.GetSet().Find(id);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.GetSet();
        }

        /// <summary>
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </summary>
        /// <param name="filter">
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public virtual IEnumerable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter)
        {
            return this.GetSet().Where(filter);
        }

        /// <summary>
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </summary>
        /// <typeparam name="S">
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </typeparam>
        /// <param name="pageIndex">
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </param>
        /// <param name="pageCount">
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </param>
        /// <param name="orderByExpression">
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </param>
        /// <param name="ascending">
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public virtual IEnumerable<TEntity> GetPaged<KProperty>(
            int pageIndex, int pageCount, Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending)
        {
            IDbSet<TEntity> set = this.GetSet();

            if (ascending)
            {
                return set.OrderBy(orderByExpression).Skip(pageCount * pageIndex).Take(pageCount);
            }
            else
            {
                return set.OrderByDescending(orderByExpression).Skip(pageCount * pageIndex).Take(pageCount);
            }
        }

        /// <summary>
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </summary>
        /// <param name="persisted">
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </param>
        /// <param name="current">
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </param>
        public virtual void Merge(TEntity persisted, TEntity current)
        {
            this._UnitOfWork.ApplyCurrentValues(persisted, current);
        }

        /// <summary>
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </summary>
        /// <param name="item">
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </param>
        public virtual void Modify(TEntity item)
        {
            if (item != null)
            {
                this._UnitOfWork.SetModified(item);
            }
            else
            {
                LoggerFactory.CreateLog().LogInfo(Messages.info_CannotRemoveNullEntity, typeof(TEntity).ToString());
            }
        }

        /// <summary>
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </summary>
        /// <param name="item">
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </param>
        public virtual void Remove(TEntity item)
        {
            if (item != null)
            {
                // attach item if not exist
                this._UnitOfWork.Attach(item);

                // set as "removed"
                this.GetSet().Remove(item);
            }
            else
            {
                LoggerFactory.CreateLog().LogInfo(Messages.info_CannotRemoveNullEntity, typeof(TEntity).ToString());
            }
        }

        /// <summary>
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </summary>
        /// <param name="item">
        /// <see cref="Phoenix.PhoenixApp.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </param>
        public virtual void TrackItem(TEntity item)
        {
            if (item != null)
            {
                this._UnitOfWork.Attach(item);
            }
            else
            {
                LoggerFactory.CreateLog().LogInfo(Messages.info_CannotRemoveNullEntity, typeof(TEntity).ToString());
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The get set.
        /// </summary>
        /// <returns>
        /// The <see cref="IDbSet"/>.
        /// </returns>
        private IDbSet<TEntity> GetSet()
        {
            return this._UnitOfWork.CreateSet<TEntity>();
        }

        #endregion
    }
}