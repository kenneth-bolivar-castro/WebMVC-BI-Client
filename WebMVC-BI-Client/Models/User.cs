using System.ComponentModel.DataAnnotations;

namespace WebMVC_BI_Client.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }
    }
}