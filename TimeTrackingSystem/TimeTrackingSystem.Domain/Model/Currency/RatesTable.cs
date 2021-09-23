using System.Collections.Generic;

namespace Grafik_Web.Models.Currency
{
    public class RatesTable
    {
        public string table { get; set; }
        public string no { get; set; }
        public string effectiveDate { get; set; }
        public List<Rate> rates { get; set; }
    }
}
