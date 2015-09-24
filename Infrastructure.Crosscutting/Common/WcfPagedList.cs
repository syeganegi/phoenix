// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Class1.cs" company="">
//   
// </copyright>
// <summary>
//   The paged list.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Infrastructure.Crosscutting.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>The paged list.</summary>
    /// <typeparam name="T"></typeparam>
    public class PagedList<T> : PagedListMetaData
    {
        #region Constructors and Destructors
        public PagedList()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="PagedList{T}"/> class.</summary>
        /// <param name="source">The source.</param>
        /// <param name="pageNumber">The page index.</param>
        /// <param name="pageSize">The page size.</param>
        public PagedList(IEnumerable<T> source, int pageNumber, int pageSize)
            : this(source == null ? new List<T>().AsQueryable() : source.AsQueryable(), pageNumber, pageSize)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="PagedList{T}"/> class.</summary>
        /// <param name="source">The source.</param>
        /// <param name="pageNumber">The page index.</param>
        /// <param name="pageSize">The page size.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private PagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
            {
                throw new ArgumentOutOfRangeException("pageNumber", pageNumber, "PageNumber cannot be below 1.");
            }

            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException("pageSize", pageSize, "PageSize cannot be less than 1.");
            }

            // set source to blank list if source is null to prevent exceptions
            this.TotalItemCount = source == null ? 0 : source.Count();
            this.PageSize = pageSize;
            this.PageNumber = pageNumber;
            this.PageCount = this.TotalItemCount > 0
                                 ? (int)Math.Ceiling(this.TotalItemCount / (double)this.PageSize)
                                 : 0;
            this.HasPreviousPage = this.PageNumber > 1;
            this.HasNextPage = this.PageNumber < this.PageCount;
            this.IsFirstPage = this.PageNumber == 1;
            this.IsLastPage = this.PageNumber >= this.PageCount;
            this.FirstItemOnPage = (this.PageNumber - 1) * this.PageSize + 1;
            int numberOfLastItemOnPage = this.FirstItemOnPage + this.PageSize - 1;
            this.LastItemOnPage = numberOfLastItemOnPage > this.TotalItemCount
                                      ? this.TotalItemCount
                                      : numberOfLastItemOnPage;

            // add items to internal list
            if (source != null && this.TotalItemCount > 0)
            {
                this.Data = pageNumber == 0
                                ? source.Take(pageSize).ToList()
                                : source.Skip((pageNumber -1) * pageSize).Take(pageSize).ToList();
            }

            this.MetaData = new PagedListMetaData(this);
        }

        #endregion

        #region Public Properties

        /// <summary>Gets or sets the data.</summary>
        public IEnumerable<T> Data { get; set; }

        /// <summary>Gets the meta data.</summary>
        public IPagedList MetaData { get; set; }

        #endregion
    }

    /// <summary>The paged list extensions.</summary>
    public static class PagedListExtensions
    {
        #region Public Methods and Operators

        /// <summary>The to paged list.</summary>
        /// <param name="source">The source.</param>
        /// <param name="pageIndex">The page index.</param>
        /// <param name="pageSize">The page size.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>The <see cref="PagedList"/>.</returns>
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, int pageIndex, int pageSize)
        {
            return new PagedList<T>(source, pageIndex, pageSize);
        }

        #endregion
    }

    /// <summary>The PagedList interface.</summary>
    public interface IPagedList
    {
        #region Public Properties

        /// <summary>
        ///     One-based index of the first item in the paged subset.
        /// </summary>
        /// <value>
        ///     One-based index of the first item in the paged subset.
        /// </value>
        int FirstItemOnPage { get; }

        /// <summary>
        ///     Returns true if this is NOT the last subset within the source.
        /// </summary>
        /// <value>
        ///     Returns true if this is NOT the last subset within the source.
        /// </value>
        bool HasNextPage { get; }

        /// <summary>
        ///     Returns true if this is NOT the first subset within the source.
        /// </summary>
        /// <value>
        ///     Returns true if this is NOT the first subset within the source.
        /// </value>
        bool HasPreviousPage { get; }

        /// <summary>
        ///     Returns true if this is the first subset within the source.
        /// </summary>
        /// <value>
        ///     Returns true if this is the first subset within the source.
        /// </value>
        bool IsFirstPage { get; }

        /// <summary>
        ///     Returns true if this is the last subset within the source.
        /// </summary>
        /// <value>
        ///     Returns true if this is the last subset within the source.
        /// </value>
        bool IsLastPage { get; }

        /// <summary>
        ///     One-based index of the last item in the paged subset.
        /// </summary>
        /// <value>
        ///     One-based index of the last item in the paged subset.
        /// </value>
        int LastItemOnPage { get; }

        /// <summary>
        ///     Total number of subsets within the source.
        /// </summary>
        /// <value>
        ///     Total number of subsets within the source.
        /// </value>
        int PageCount { get; }

        /// <summary>
        ///     One-based index of this subset within the source.
        /// </summary>
        /// <value>
        ///     One-based index of this subset within the source.
        /// </value>
        int PageNumber { get; }

        /// <summary>
        ///     Maximum size any individual subset.
        /// </summary>
        /// <value>
        ///     Maximum size any individual subset.
        /// </value>
        int PageSize { get; }

        /// <summary>
        ///     Total number of objects contained within the source.
        /// </summary>
        /// <value>
        ///     Total number of objects contained within the source.
        /// </value>
        int TotalItemCount { get; }

        #endregion
    }

    /// <summary>The paged list meta data.</summary>
    public class PagedListMetaData : IPagedList
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="PagedListMetaData"/> class. Non-enumerable version of the PagedList class.</summary>
        /// <param name="pagedList">A PagedList (likely enumerable) to copy metadata from.</param>
        public PagedListMetaData(IPagedList pagedList)
        {
            this.PageCount = pagedList.PageCount;
            this.TotalItemCount = pagedList.TotalItemCount;
            this.PageNumber = pagedList.PageNumber;
            this.PageSize = pagedList.PageSize;
            this.HasPreviousPage = pagedList.HasPreviousPage;
            this.HasNextPage = pagedList.HasNextPage;
            this.IsFirstPage = pagedList.IsFirstPage;
            this.IsLastPage = pagedList.IsLastPage;
            this.FirstItemOnPage = pagedList.FirstItemOnPage;
            this.LastItemOnPage = pagedList.LastItemOnPage;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PagedListMetaData" /> class.
        ///     Protected constructor that allows for instantiation without passing in a separate list.
        /// </summary>
        protected PagedListMetaData()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     One-based index of the first item in the paged subset.
        /// </summary>
        /// <value>
        ///     One-based index of the first item in the paged subset.
        /// </value>
        public int FirstItemOnPage { get; protected set; }

        /// <summary>
        ///     Returns true if this is NOT the last subset within the source.
        /// </summary>
        /// <value>
        ///     Returns true if this is NOT the last subset within the source.
        /// </value>
        public bool HasNextPage { get; protected set; }

        /// <summary>
        ///     Returns true if this is NOT the first subset within the source.
        /// </summary>
        /// <value>
        ///     Returns true if this is NOT the first subset within the source.
        /// </value>
        public bool HasPreviousPage { get; protected set; }

        /// <summary>
        ///     Returns true if this is the first subset within the source.
        /// </summary>
        /// <value>
        ///     Returns true if this is the first subset within the source.
        /// </value>
        public bool IsFirstPage { get; protected set; }

        /// <summary>
        ///     Returns true if this is the last subset within the source.
        /// </summary>
        /// <value>
        ///     Returns true if this is the last subset within the source.
        /// </value>
        public bool IsLastPage { get; protected set; }

        /// <summary>
        ///     One-based index of the last item in the paged subset.
        /// </summary>
        /// <value>
        ///     One-based index of the last item in the paged subset.
        /// </value>
        public int LastItemOnPage { get; protected set; }

        /// <summary>
        ///     Total number of subsets within the source.
        /// </summary>
        /// <value>
        ///     Total number of subsets within the source.
        /// </value>
        public int PageCount { get; protected set; }

        /// <summary>
        ///     One-based index of this subset within the source.
        /// </summary>
        /// <value>
        ///     One-based index of this subset within the source.
        /// </value>
        public int PageNumber { get; protected set; }

        /// <summary>
        ///     Maximum size any individual subset.
        /// </summary>
        /// <value>
        ///     Maximum size any individual subset.
        /// </value>
        public int PageSize { get; protected set; }

        /// <summary>
        ///     Total number of objects contained within the source.
        /// </summary>
        /// <value>
        ///     Total number of objects contained within the source.
        /// </value>
        public int TotalItemCount { get; protected set; }

        #endregion
    }
}