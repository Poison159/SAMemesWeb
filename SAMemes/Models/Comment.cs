using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAMemes.Models
{
    public class Comment
    {
        public Comment() {
            time = DateTime.Now.TimeOfDay;
        }
        public int id { get; set; }
        [Required]
        public int memeId { get; set; }
        [Required]
        public string comment { get; set; }
        [Required]
        public TimeSpan time { get; set; }
    }
}