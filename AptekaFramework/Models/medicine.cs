namespace AptekaFramework.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class medicine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public medicine()
        {
            order_med = new HashSet<order_med>();
        }

        [Key]
        public int med_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string med_name { get; set; }

        public int med_int { get; set; }

        [Required]
        [StringLength(50)]
        public string med_desc { get; set; }

        public decimal med_price { get; set; }

        public int vendors_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string med_cat { get; set; }

        public int med_quant { get; set; }

        public bool med_receipt { get; set; }

        public virtual vendor vendor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_med> order_med { get; set; }
    }
}
