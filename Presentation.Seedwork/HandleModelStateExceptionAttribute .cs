namespace Phoenix.PhoenixApp.Presentation.Seedwork
{
    using System;
    using System.Text;
    using System.Web.Mvc;

    using FilterAttribute = System.Web.Http.Filters.FilterAttribute;
    using IExceptionFilter = System.Web.Http.Filters.IExceptionFilter;

    /// <summary>
    /// Represents errors that occur due to invalid application model state.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public sealed class HandleModelStateExceptionAttribute : FilterAttribute, IExceptionFilter
    {
        /// <summary>
        /// Called when an exception occurs and processes <see cref="ModelStateException"/> object.
        /// </summary>
        /// <param name="filterContext">Filter context.</param>
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            // handle modelStateException
            if (filterContext.Exception != null && typeof(ModelStateException).IsInstanceOfType(filterContext.Exception) && !filterContext.ExceptionHandled)
            {
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
                filterContext.HttpContext.Response.ContentEncoding = Encoding.UTF8;
                filterContext.HttpContext.Response.HeaderEncoding = Encoding.UTF8;
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                filterContext.HttpContext.Response.StatusCode = 400;
                filterContext.Result = new ContentResult
                {
                    Content = (filterContext.Exception as ModelStateException).Message,
                    ContentEncoding = Encoding.UTF8,
                };
            }
        }

        public System.Threading.Tasks.Task ExecuteExceptionFilterAsync(System.Web.Http.Filters.HttpActionExecutedContext actionExecutedContext, System.Threading.CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}