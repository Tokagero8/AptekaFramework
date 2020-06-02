namespace AptekaFramework.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class employee
    {
        [Key]
        public int ID_empl { get; set; }

        [Required]
        [StringLength(50)]
        public string empl_name { get; set; }

        [Required]
        [StringLength(50)]
        public string empl_surname { get; set; }

        public int empl_phone { get; set; }

        [Required]
        [StringLength(50)]
        public string empl_mail { get; set; }

        [Required]
        [StringLength(50)]
        public string empl_login { get; set; }

        [Required]
        [StringLength(50)]
        public string empl_passwd { get; set; }

        [Required]
        [StringLength(50)]
        public string empl_title { get; set; }

        [StringLength(1)]
        public string empl_head { get; set; }
    }
}
