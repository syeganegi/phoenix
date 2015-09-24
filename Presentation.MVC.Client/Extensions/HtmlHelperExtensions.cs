// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlHelperExtensions.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Client.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using System.Web.Routing;

    using Phoenix.PhoenixApp.Presentation.MVC.Client.Resources;
    using Phoenix.PhoenixApp.Presentation.MVC.Models.Account;

    /// <summary>
    ///     The html helper extensions.
    /// </summary>
    public static class HtmlHelperExtensions
    {
        #region Static Fields

        /// <summary>
        ///     The _months.
        /// </summary>
        private static readonly string[] _months =
            {
                "January", "February", "March", "April", "May", "June", "July", 
                "August", "September", "October", "November", "December"
            };

        #endregion

        #region Public Methods and Operators

        /// <summary>The day drop down list for.</summary>
        /// <param name="htmlHelper">The html helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectedDay">The selected day.</param>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <returns>The <see cref="MvcHtmlString"/>.</returns>
        public static MvcHtmlString DayDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int? selectedDay)
        {
            return htmlHelper.DropDownListFor(expression, GetDayListItems(selectedDay));
        }

        /// <summary>The edit link.</summary>
        /// <param name="htmlHelper">The html helper.</param>
        /// <param name="username">The username.</param>
        /// <param name="result">The result.</param>
        /// <param name="linktext">The linktext.</param>
        /// <returns>The <see cref="MvcHtmlString"/>.</returns>
        public static MvcHtmlString EditLink(
            this HtmlHelper htmlHelper, string username, ActionResult result, string linktext = "Edit")
        {
            if (HttpContext.Current.User.Identity.Name.Equals(username, StringComparison.OrdinalIgnoreCase))
            {
                return htmlHelper.ActionLink(linktext, result);
            }

            return MvcHtmlString.Empty;
        }

        /// <summary>The image for.</summary>
        /// <param name="htmlHelper">The html helper.</param>
        /// <param name="expression">The expression.</param>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <returns>The <see cref="MvcHtmlString"/>.</returns>
        public static MvcHtmlString ImageFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            TProperty imgUrl = expression.Compile()(htmlHelper.ViewData.Model);
            if (imgUrl != null)
            {
                return BuildImageTag(imgUrl.ToString(), null);
            }

            return null;
        }

        /// <summary>The image for.</summary>
        /// <param name="htmlHelper">The html helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The html attributes.</param>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <returns>The <see cref="MvcHtmlString"/>.</returns>
        public static MvcHtmlString ImageFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            TProperty imgUrl = expression.Compile()(htmlHelper.ViewData.Model);
            return BuildImageTag(imgUrl.ToString(), htmlAttributes);
        }

        /// <summary>The month drop down list for.</summary>
        /// <param name="htmlHelper">The html helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectedMonth">The selected month.</param>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <returns>The <see cref="MvcHtmlString"/>.</returns>
        public static MvcHtmlString MonthDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int? selectedMonth)
        {
            return htmlHelper.DropDownListFor(expression, GetMonthListItems(selectedMonth));
        }

        /// <summary>The profile info for.</summary>
        /// <param name="htmlHelper">The html helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="emptyValue">The empty value.</param>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <returns>The <see cref="MvcHtmlString"/>.</returns>
        public static MvcHtmlString ProfileInfoFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string emptyValue)
        {
            TProperty field = expression.Compile()(htmlHelper.ViewData.Model);
            if (field != null && field is string)
            {
                return new MvcHtmlString(field.ToString());
            }

            return htmlHelper.ActionLink(emptyValue, MVCT.Profile.Index());
        }

        /// <summary>The sex drop down list for.</summary>
        /// <param name="htmlHelper">The html helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectedSex">The selected sex.</param>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <returns>The <see cref="MvcHtmlString"/>.</returns>
        public static MvcHtmlString SexDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Sex selectedSex)
        {
            return htmlHelper.DropDownListFor(expression, GetSexListItems(selectedSex));
        }

        /// <summary>The to days ago.</summary>
        /// <param name="htmlHelper">The html helper.</param>
        /// <param name="dateUTC">The date UTC.</param>
        /// <returns>The <see cref="MvcHtmlString"/>.</returns>
        public static MvcHtmlString ToDaysAgo(this HtmlHelper htmlHelper, DateTime dateUTC)
        {
            DateTime date = dateUTC.ToLocalTime();
            if (date.Date == DateTime.Today)
            {
                return MvcHtmlString.Create("today");
            }

            if (date.Date == DateTime.Today.AddDays(-1))
            {
                return MvcHtmlString.Create("yesterday");
            }

            TimeSpan ts = DateTime.Today - date.Date;
            return MvcHtmlString.Create(string.Format("{0} days ago", ts.TotalDays));
        }

        /// <summary>The view counter for.</summary>
        /// <param name="htmlHelper">The html helper.</param>
        /// <param name="expression">The expression.</param>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <returns>The <see cref="MvcHtmlString"/>.</returns>
        public static MvcHtmlString ViewCounterFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string username)
        {
            TProperty counterModel = expression.Compile()(htmlHelper.ViewData.Model);
            int counter = Convert.ToInt32(counterModel);
            if (counter == 0)
            {
                return MvcHtmlString.Empty;
            }

            string view;
            if (counter == 1)
            {
                view = string.Format("{0} View", counter);
            }
            else
            {
                view = string.Format("{0} Views", counter);
            }

            return htmlHelper.ActionLink(view, MVCT.Profile.Stats(username));
        }

        /// <summary>The year drop down list for.</summary>
        /// <param name="htmlHelper">The html helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectedYear">The selected year.</param>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <returns>The <see cref="MvcHtmlString"/>.</returns>
        public static MvcHtmlString YearDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int? selectedYear)
        {
            return htmlHelper.DropDownListFor(expression, GetYearListItems(selectedYear));
        }

        #endregion

        #region Methods

        /// <summary>The build image tag.</summary>
        /// <param name="imgUrl">The img url.</param>
        /// <param name="htmlAttributes">The html attributes.</param>
        /// <returns>The <see cref="MvcHtmlString"/>.</returns>
        private static MvcHtmlString BuildImageTag(string imgUrl, object htmlAttributes)
        {
            var tag = new TagBuilder("img");

            tag.Attributes.Add("src", imgUrl);
            if (htmlAttributes != null)
            {
                tag.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            }

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }

        /// <summary>The get day list items.</summary>
        /// <param name="selectedDay">The selected day.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        private static IEnumerable<SelectListItem> GetDayListItems(int? selectedDay)
        {
            var dayList = new List<SelectListItem> { new SelectListItem { Text = "Day:", Value = "-1" } };

            for (int i = 1; i <= 31; i++)
            {
                dayList.Add(
                    new SelectListItem { Text = i.ToString(), Value = i.ToString(), Selected = selectedDay == i });
            }

            return dayList;
        }

        /// <summary>The get month list items.</summary>
        /// <param name="selectedMonth">The selected month.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        private static IEnumerable<SelectListItem> GetMonthListItems(int? selectedMonth)
        {
            var monthList = new List<SelectListItem> { new SelectListItem { Text = "Month:", Value = "-1" } };

            for (int i = 0; i < _months.Length; i++)
            {
                monthList.Add(
                    new SelectListItem
                        {
                            Text = _months[i], 
                            Value = (i + 1).ToString(), 
                            Selected = selectedMonth == (i + 1)
                        });
            }

            return monthList;
        }

        /// <summary>Gets the sex list items.</summary>
        /// <param name="selectedSex">The selected sex.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        private static IEnumerable<SelectListItem> GetSexListItems(Sex selectedSex)
        {
            var sexListItems = new List<SelectListItem>
                                   {
                                       new SelectListItem
                                           {
                                               Text = Strings.string_Sex, 
                                               Value = Sex.Unknown.ToString(), 
                                               Selected = selectedSex == Sex.Unknown
                                           }, 
                                       new SelectListItem
                                           {
                                               Text = Sex.Male.ToString(), 
                                               Value = Sex.Male.ToString(), 
                                               Selected = selectedSex == Sex.Male
                                           }, 
                                       new SelectListItem
                                           {
                                               Text = Sex.Female.ToString(), 
                                               Value = Sex.Female.ToString(), 
                                               Selected = selectedSex == Sex.Female
                                           }, 
                                   };

            return sexListItems;
        }

        /// <summary>The get year list items.</summary>
        /// <param name="selectedYear">The selected year.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        private static IEnumerable<SelectListItem> GetYearListItems(int? selectedYear)
        {
            var yearList = new List<SelectListItem> { new SelectListItem { Text = "Year:", Value = "-1" } };

            for (int i = DateTime.Now.Year; i > 1900; i--)
            {
                yearList.Add(
                    new SelectListItem { Text = i.ToString(), Value = i.ToString(), Selected = selectedYear == i });
            }

            return yearList;
        }

        #endregion
    }
}