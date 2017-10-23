namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShopCart")]
    public partial class ShopCart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cid { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Cusid { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ProCode { get; set; }

        public int? num { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateTime { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Product Product { get; set; }
    }
}
