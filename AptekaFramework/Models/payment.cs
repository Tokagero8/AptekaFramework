namespace AptekaFramework.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("payment")]
    public partial class payment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public payment()
        {
            orders = new HashSet<order>();
        }

        [Key]
        public int ID_payment { get; set; }

        public double amount { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string payment_method { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string payment_status { get; set; }

        [Column(TypeName = "text")]
        public string payment_number { get; set; }

        public DateTime? payment_time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }
    }
}
