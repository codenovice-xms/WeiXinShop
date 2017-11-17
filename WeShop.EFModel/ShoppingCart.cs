namespace WeShop.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShoppingCart")]
    public partial class ShoppingCart
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CusId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(16)]
        public string ProCode { get; set; }

        public int Qty { get; set; }

        public DateTime? CreateTime { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Product Product { get; set; }

        public bool IsChecked { get; set; }
    }
}
