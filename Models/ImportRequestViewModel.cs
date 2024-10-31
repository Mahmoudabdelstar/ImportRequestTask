namespace Task.Models
{
    public class ImportRequestViewModel
    {
        public string ImporterName { get; set; }
        public string ImporterEmail { get; set; }
        public string ImporterMobile { get; set; }
        public string ExportCountry { get; set; }
        public string ExportCity { get; set; }
        public DateTime ImportDate { get; set; }
    }
}
