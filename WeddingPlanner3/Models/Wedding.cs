using System;
using System.Collections.Generic;

namespace WeddingPlanner3.Models
{
    public class Wedding
    {
        public int WeddingID { get; set; }
        public string WedderOne { get; set; }
        public string WedderTwo { get; set; }
        public DateTime Date { get; set; }
        public int UserID { get; set; }
        public User Planner { get; set; }
        public List<Guest> Guests { get; set; }
    }
}