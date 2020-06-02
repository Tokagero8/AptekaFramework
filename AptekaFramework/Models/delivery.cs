namespace AptekaFramework.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("delivery")]
    public partial class delivery
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public delivery()
        {
            orders = new HashSet<order>();
        }

        [Key]
        public int delivery_ID { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string delivery_method { get; set; }

        [Column(TypeName = "text")]
        public string delivery_track_number { get; set; }

        [Column(TypeName = "text")]
        public string delivery_status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }
    }
}
