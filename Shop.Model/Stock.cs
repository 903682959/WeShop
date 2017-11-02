namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stock")]
    public partial class Stock
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? num { get; set; }

        public int? sale { get; set; }
        [Key]
        [StringLength(50)]
        public string pcode { get; set; }

        [Required]
        [StringLength(50)]
        public string billcode { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime time { get; set; }

        public virtual Product Product { get; set; }
    }
}
