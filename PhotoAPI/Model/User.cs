using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAPI.Model
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [Column("user_login")]
        public string UserLogin { get; set; }

        [Required]
        [Column("user_password")]
        public string UserPassword { get; set; }
    }
}
