﻿using System.ComponentModel.DataAnnotations.Schema;

namespace EventEaseApp.Models
{
    [Table("Venue_")]
    public class Venue
    {
        public int VenueID { get; set; }

        public string? VenueName { get; set; }

        public string? Location { get; set; }

        public int Capacity { get; set; }

        public string? ImageURL { get; set; }

        //Navigation property to Event
        //public ICollection<Event>? Event { get; set;  }
    }
}
