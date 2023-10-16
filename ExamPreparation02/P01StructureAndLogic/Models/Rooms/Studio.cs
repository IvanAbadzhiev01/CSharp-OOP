namespace BookingApp.Models.Rooms
{
    public class Studio : Room
    {
        const int Studio_DEFALTCAPACITY = 4;
        public Studio() : base(Studio_DEFALTCAPACITY)
        {
        }
    }
}
