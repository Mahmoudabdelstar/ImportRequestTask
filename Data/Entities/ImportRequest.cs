using System.ComponentModel.DataAnnotations;
using Task.Utilities;

namespace Task.Data.Entities
{
    public class ImportRequest
    {
        [Key]
        public int Id { get; set; }
        public string ImporterName { get; set; }
        public string ImporterEmail { get; set; }
        public string ImporterMobile { get; set; }
        public string ExportCountry { get; set; }
        public string ExportCity { get; set; }
        public DateTime ImportDate { get; set; }
        public RequestStatusEnum Status { get; set; }

        public ICollection<ImportItem> ImportItems { get; set; }
    }
}
