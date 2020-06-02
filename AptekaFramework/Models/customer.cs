namespace AptekaFramework.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customer()
        {
            orders = new HashSet<order>();
        }

        [Key]
        public int ID_cust { get; set; }

        [Required]
        [StringLength(50)]
        public string cust_name { get; set; }

        [Required]
        [StringLength(50)]
        public string cust_surname { get; set; }

        public int cust_phone { get; set; }

        [Required]
        [StringLength(50)]
        public string cust_mail { get; set; }

        [Required]
        [StringLength(50)]
        public string cust_login { get; set; }

        [Required]
        [StringLength(50)]
        public string cust_passwd { get; set; }

        [Required]
        [StringLength(50)]
        public string cust_adress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }
    }
}
