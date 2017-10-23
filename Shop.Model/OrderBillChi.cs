namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderBillChi")]
    public partial class OrderBillChi
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Code { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string procode { get; set; }

        public int? num { get; set; }

        [Column(TypeName = "money")]
        public decimal? price { get; set; }

        [StringLength(50)]
        public string cid { get; set; }

        public virtual OrderBillFath OrderBillFath { get; set; }

        public virtual Product Product { get; set; }
    }
}
