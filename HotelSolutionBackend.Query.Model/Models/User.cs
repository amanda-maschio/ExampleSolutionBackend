using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSolutionBackend.Query.Model.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("email", TypeName = "varchar(255)")]
        public string Email { get; set; }

        [Column("password", TypeName = "varchar(255)")]
        public string Password { get; set; }

        [Column("session_token", TypeName = "varchar(255)")]
        public string SessionToken { get; set; }

        [Column("register", TypeName = "timestamp")]
        public DateTime Register { get; set; }
    }
}
