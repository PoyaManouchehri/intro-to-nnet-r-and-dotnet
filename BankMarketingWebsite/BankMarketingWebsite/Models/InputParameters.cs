// ReSharper disable InconsistentNaming

using System.Linq;
using System.Web.Mvc;

namespace BankMarketingWebsite.Models
{
    public class InputParameters
    {
        public InputParameters()
        {
            JobOptions = ToSelectList("admin.", "blue-collar", "entrepreneur", "housemaid", "management", "retired", "self-employed", "services", "student", "technician", "unemployed", "unknown");
            MaritalOptions = ToSelectList("divorced", "married", "single", "unknown");
            EducationOptions = ToSelectList("basic.4y", "basic.6y", "basic.9y", "high.school", "illiterate", "professional.course", "university.degree", "unknown");
            DefaultOptions = ToSelectList("no", "yes", "unknown");
            HousingOptions = ToSelectList("no", "yes", "unknown");
            LoanOptions = ToSelectList("no", "yes", "unknown");
            ContactOptions = ToSelectList("cellular", "telephone");
            MonthOptions = ToSelectList("mar", "apr", "may", "jun", "jul", "aug", "sep", "oct", "nov", "dev");
            DayOfWeekOptions = ToSelectList("mon", "tue", "wed", "thu", "fri");
            POutcomeOptions = ToSelectList("failure", "nonexistent", "success");
        }

        public int Age { get; set; }
        public string Job { get; set; }
        public string Marital { get; set; }
        public string Education { get; set; }
        public string Default { get; set; }
        public string Housing { get; set; }
        public string Loan { get; set; }
        public string Contact { get; set; }
        public string Month { get; set; }
        public string DayOfWeek { get; set; }
        public int Campaign { get; set; }
        public int PDays { get; set; }
        public int Previous { get; set; }
        public string POutcome { get; set; }
        public double EmpVarRate { get; set; }
        public double ConsPriceIdx { get; set; }
        public double ConsConfIdx { get; set; }
        public double Euribor3m { get; set; }
        public double NrEmployed { get; set; }

        public SelectListItem[] JobOptions { get; private set; }
        public SelectListItem[] MaritalOptions { get; private set; }
        public SelectListItem[] EducationOptions { get; private set; }
        public SelectListItem[] DefaultOptions { get; private set; }
        public SelectListItem[] HousingOptions { get; private set; }
        public SelectListItem[] LoanOptions { get; private set; }
        public SelectListItem[] ContactOptions { get; private set; }
        public SelectListItem[] MonthOptions { get; private set; }
        public SelectListItem[] DayOfWeekOptions { get; private set; }
        public SelectListItem[] POutcomeOptions { get; private set; }

        SelectListItem[] ToSelectList(params string[] items)
        {
            return items.Select(x => new SelectListItem { Text = x, Value = x }).ToArray();
        }
    }
}