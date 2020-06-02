namespace AptekaFramework.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class order_med
    {
        [Key]
        public int ID_order_med { get; set; }

        public int medicines_ID { get; set; }

        public int quantity { get; set; }

        public virtual medicine medicine { get; set; }
    }
}
