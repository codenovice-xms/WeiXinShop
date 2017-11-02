namespace WeShop.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProPhoto")]
    public partial class ProPhoto
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(16)]
        public string ProCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string No { get; set; }

        [Required]
        [StringLength(500)]
        public string ImgUrl { get; set; }

        public virtual Product Product { get; set; }
    }
}
