namespace BookingApp.Models.Rooms
{
    public class Apartment : Room
    {
        const int Apartment_DEFALTCAPACITY = 6;
        public Apartment() : base(Apartment_DEFALTCAPACITY)
        {
        }
    }
}
