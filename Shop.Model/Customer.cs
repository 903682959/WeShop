namespace Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            ShopCart = new HashSet<ShopCart>();
        }

        [Key]
        [StringLength(50)]
        public string cid { get; set; }

        [Required]
        [StringLength(50)]
        public string openid { get; set; }

        [StringLength(50)]
        public string nickname { get; set; }

        [StringLength(11)]
        public string tel { get; set; }

        [StringLength(30)]
        public string address { get; set; }

        [StringLength(20)]
        public string image { get; set; }

        public virtual OrderBillFath OrderBillFath { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShopCart> ShopCart { get; set; }
    }
}
