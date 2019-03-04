
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_SalesDatabase.Data.Models
{
    [Table("Stores")]
    public class Store
    {
        public Store()
        {
            this.Sales = new HashSet<Sale>();
        }

        public int StoreId { get; set; }

        [Column(TypeName = "NVARCHAR(80)")]
        public string Name { get; set; }

        public ICollection<Sale> Sales{ get; set; }
    }
}
