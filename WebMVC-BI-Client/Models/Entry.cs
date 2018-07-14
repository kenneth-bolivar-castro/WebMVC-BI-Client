using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebMVC_BI_Client.Models
{

    public enum EntryStatus
    {
        Solicitud,
        Cancelado,
        VentaConcretada,
        FueraInventario
    }

    public class Entry
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string Comments { get; set; }
        [Required]
        public string Item { get; set; }
        [Required]
        public Client Client { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public EntryStatus Status { get; set; }
    }
}