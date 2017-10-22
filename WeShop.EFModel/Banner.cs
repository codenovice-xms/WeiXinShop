namespace WeShop.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Banner")]
    public partial class Banner
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Image { get; set; }

        [Required]
        [StringLength(200)]
        public string Link { get; set; }

        [StringLength(200)]
        public string Memo { get; set; }

        public int PostUserId { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}
