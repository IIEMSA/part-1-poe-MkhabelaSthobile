using System.ComponentModel.DataAnnotations.Schema;

namespace EventEaseApp.Models
{
    [Table("Event")]
    public class Event
    {
        public int EventID { get; set; }
        //Navigation property
        public Venue? Venue { get; set; }
        public int VenueID { get; set; }
        public string? EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string? Description { get; set; }
    }
}
