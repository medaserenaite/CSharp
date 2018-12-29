using WeddingPlanner3.Models;

namespace WeddingPlanner3.Models
{
    public class Guest
    {
        public int GuestID { get; set; }
        public int UserID { get; set; }
        public User Attending { get; set; }
        public int WeddingID { get; set; }
        public Wedding Wedding { get; set; }
    }
}