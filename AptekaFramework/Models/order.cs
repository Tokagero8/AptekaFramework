namespace AptekaFramework.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("order")]
    public partial class order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public order()
        {
            order_med = new HashSet<order_med>();
        }

        [Key]
        public int order_ID { get; set; }

        public int customers_ID { get; set; }

        public DateTime? order_time { get; set; }

        public int? payment_ID { get; set; }

        public int? delivery_ID { get; set; }

        public bool completed { get; set; }

        public virtual customer customer { get; set; }

        public virtual delivery delivery { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_med> order_med { get; set; }

        public virtual payment payment { get; set; }
    }
}
