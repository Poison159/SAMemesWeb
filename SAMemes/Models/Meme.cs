using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAMemes.Models
{
    public class Meme
    {
        Meme() {
            comments = new List<Comment>();
            date = DateTime.Now;
        }
        public int id { get; set; }
        [Required]
        public string imgPath { get; set; }
        public int likes { get; set; }
        public DateTime date { get; set; }
        public List<Comment> comments { get; set; }
        
    }
}