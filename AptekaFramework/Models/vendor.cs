namespace AptekaFramework.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vendor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public vendor()
        {
            medicines = new HashSet<medicine>();
        }

        [Key]
        public int vend_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string vend_name { get; set; }

        [Required]
        [StringLength(50)]
        public string vend_adress { get; set; }

        public int vend_phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<medicine> medicines { get; set; }
    }
}
