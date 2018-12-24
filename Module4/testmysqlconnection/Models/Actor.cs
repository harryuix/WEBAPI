
using System.ComponentModel.DataAnnotations;

namespace WebServer.Models
{
public class Actor
    {
        [Key]
        public int Actor_ID { get; set; }
        public string first_name {get; set; }
        public string last_name {get; set; }
        public string last_update {get; set; }
    }
}