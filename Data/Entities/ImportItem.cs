using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Data.Entities
{
    public class ImportItem
    {
        [Key]
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }

        [ForeignKey("RequestId")]
        public ImportRequest ImportRequest { get; set; }

        [ForeignKey("ItemId")]
        public Items Items { get; set; }
    }
}
