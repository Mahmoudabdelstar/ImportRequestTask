using System.ComponentModel.DataAnnotations;

namespace Task.Data.Entities
{
     
    public class ItemType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
