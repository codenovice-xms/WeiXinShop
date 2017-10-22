namespace WeShop.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProReview")]
    public partial class ProReview
    {
        public int Id { get; set; }

        [Required]
        [StringLength(16)]
        public string ProCode { get; set; }

        public int CusId { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Body { get; set; }

        public bool State { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Rate { get; set; }

        public DateTime CreateTime { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Product Product { get; set; }
    }
}
