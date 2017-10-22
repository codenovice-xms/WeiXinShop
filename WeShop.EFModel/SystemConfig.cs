namespace WeShop.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SystemConfig")]
    public partial class SystemConfig
    {
        [Key]
        [StringLength(50)]
        public string Paramter { get; set; }

        [Required]
        [StringLength(50)]
        public string Value { get; set; }
    }
}
