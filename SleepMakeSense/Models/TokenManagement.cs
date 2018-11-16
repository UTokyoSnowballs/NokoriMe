using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// 20171023 Pandita: reimplement using EF
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace SleepMakeSense.Models
{

    public class TokenManagement
    {
        [Key]
        public Guid Id { get; set; }

        // Foreign key to AspNetUser
        [ForeignKey("AspNetUser")]
        public string AspNetUserId { get; set; }
        public AspNetUser AspNetUser { get; set; }

        public string Token { get; set; }
        public string TokenType { get; set; }
        public int ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
        public string UserId;
        public DateTime DateChanged { get; set; }
    }
}