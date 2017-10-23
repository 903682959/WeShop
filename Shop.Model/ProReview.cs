namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProReview")]
    public partial class ProReview
    {
        [StringLength(50)]
        public string ID { get; set; }

        [StringLength(50)]
        public string Procode { get; set; }

        [StringLength(50)]
        public string cusid { get; set; }

        [StringLength(50)]
        public string contents { get; set; }

        [StringLength(20)]
        public string images { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime time { get; set; }

        public virtual Product Product { get; set; }
    }
}
