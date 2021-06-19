using System;
using System.ComponentModel.DataAnnotations;

namespace OKBlogODataService.Model
{
    public class Ticket
    {
        [Key] public Guid TicketId { get; set; }
        public Guid EventId { get; set; }
        public Guid KontaktId { get; set; }
        public string Ticketnummer { get; set; }
        public decimal Einzelpreis { get; set; }
    }
}
