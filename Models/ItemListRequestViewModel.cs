using System.ComponentModel.DataAnnotations;
using Task.Data.Entities;

namespace Task.Models
{
    public class ItemListRequestViewModel
    {
        public int ItemId { get; set; }
        public int RequestId { get; set; }
        public int ItemTypeId { get; set; }
        public int ItemCount { get; set; }
    }
}
