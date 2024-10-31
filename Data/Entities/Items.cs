using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Data.Entities
{
    public class Items
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int  TypeId { get; set; }

        [ForeignKey("TypeId")]
        public ItemType ItemType { get; set; }
    }
}
