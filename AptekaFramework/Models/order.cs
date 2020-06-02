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
        [Key]
        public int ID_order { get; set; }

        public int customers_ID { get; set; }

        public DateTime order_time { get; set; }

        public int payment_ID { get; set; }

        public int delivery_ID { get; set; }

        public virtual customer customer { get; set; }

        public virtual delivery delivery { get; set; }

        public virtual payment payment { get; set; }
    }
}
