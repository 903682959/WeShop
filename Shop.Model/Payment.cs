namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        [Key]
        [StringLength(50)]
        public string code { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public virtual OrderBillFath OrderBillFath { get; set; }
    }
}
