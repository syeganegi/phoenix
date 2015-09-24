// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Birthday.cs" company="Phoenix Pty Ltd">
//   Copyright Phoenix Pty Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Phoenix.PhoenixApp.Presentation.MVC.Models.Account
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Phoenix.PhoenixApp.Presentation.MVC.Models.ModelBinders;
    using Phoenix.PhoenixApp.Presentation.MVC.Models.Resources;

    /// <summary>
    ///     The birthday.
    /// </summary>
    [ModelBinder(typeof(BirthdayModelBinder))]
    public class Birthday
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Birthday" /> class.
        /// </summary>
        public Birthday()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Birthday"/> class.</summary>
        /// <param name="date">The date.</param>
        public Birthday(DateTime date)
            : this(date.Year, date.Month, date.Day)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Birthday"/> class.</summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day.</param>
        public Birthday(int year, int month, int day)
        {
            DateTime birthday;
            try
            {
                // to throw an exception if the birthday is not valid
                birthday = new DateTime(year, month, day);
            }
            catch (Exception)
            {
                throw new ArgumentException(Messages.exception_TheBirthdayIsInvalidDate);
            }

            if (birthday > DateTime.Today)
            {
                throw new ArgumentException(Messages.exception_TheBirthdayCannotBeInTheFuture);
            }

            this.Year = year;
            this.Month = month;
            this.Day = day;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the day.
        /// </summary>
        [Range(1, 31)]
        public int Day { get; set; }

        /// <summary>
        ///     Gets or sets the month.
        /// </summary>
        [Range(1, 12)]
        public int Month { get; set; }

        /// <summary>
        ///     Gets or sets the year.
        /// </summary>
        [Range(1, 9999)]
        public int Year { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>The to age.</summary>
        /// <returns>The <see cref="int"/>.</returns>
        public int ToAge()
        {
            DateTime date = this.ToDate();
            DateTime now = DateTime.Now;
            int age = now.Year - date.Year;
            if (now < date.AddYears(age))
            {
                age--;
            }

            return age;
        }

        /// <summary>
        ///     The to date.
        /// </summary>
        /// <returns>
        ///     The <see cref="DateTime" />.
        /// </returns>
        public DateTime ToDate()
        {
            return new DateTime(this.Year, this.Month, this.Day);
        }

        /// <summary>The to string.</summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        public override string ToString()
        {
            return this.ToDate().ToShortDateString();
        }

        /// <summary>The validate.</summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (this.ToDate() > DateTime.Today)
            {
                validationResults.Add(
                    new ValidationResult(Messages.exception_TheBirthdayCannotBeInTheFuture, new[] { "Birthday" }));
            }

            return validationResults;
        }

        #endregion
    }
}