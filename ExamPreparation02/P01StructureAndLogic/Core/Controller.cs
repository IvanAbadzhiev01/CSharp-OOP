using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private IRepository<IHotel> hotels;
        private string[] roomTypes = new string[]
        {
            "DoubleBed",
            "Studio",
            "Apartment"
        };
        public Controller()
        {
            hotels = new HotelRepository();
        }
        public string AddHotel(string hotelName, int category)
        {

            IHotel hotel = hotels.Select(hotelName);

            if (hotel != null)
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            hotel = new Hotel(hotelName, category);
            hotels.AddNew(hotel);

            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);

        }
        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = hotels.Select(hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            IRoom room = hotel.Rooms.Select(roomTypeName);
            if (room != null)
            {
                return OutputMessages.RoomTypeAlreadyCreated;
            }

            switch (roomTypeName)
            {
                case "DoubleBed":
                    room = new DoubleBed();
                    break;
                case "Studio":
                    room = new Studio();
                    break;
                case "Apartment":
                    room = new Apartment();
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);

            }

            hotel.Rooms.AddNew(room);

            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);

        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = hotels.Select(hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            if (!roomTypes.Contains(roomTypeName))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }
            IRoom room = hotel.Rooms.Select(roomTypeName);
            if (room == null)
            {
                return OutputMessages.RoomTypeNotCreated;
            }

            if (room.PricePerNight > 0)
            {
                throw new ArgumentException(ExceptionMessages.PriceAlreadySet);
            }

            room.SetPrice(price);

            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);



        }
        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            //hotels.All().OrderBy(n => n.FullName).Where(h => h.Rooms.All().Where(r=> r.PricePerNight > 0 ))

            if (hotels.All().FirstOrDefault(h => h.Category == category) == null)
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }
            IOrderedEnumerable<IHotel> orderdHotels = hotels
                .All()
                .Where(h => h.Category == category)
                .OrderBy(h => h.FullName);

            foreach (var hotel in orderdHotels)
            {
                IRoom room = hotel.Rooms
                    .All()
                    .Where(r => r.PricePerNight > 0)
                    .OrderBy(r => r.BedCapacity)
                    .FirstOrDefault(r => r.BedCapacity >= adults + children);

                if (room != null)
                {
                    int bookingNumber = hotel.Bookings.All().Count() + 1;
                    IBooking booking = new Booking(room, duration, adults, children, bookingNumber);

                    hotel.Bookings.AddNew(booking);
                    return string.Format(OutputMessages.BookingSuccessful, bookingNumber, hotel.FullName);
                }
            }
            return OutputMessages.RoomNotAppropriate;




        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotels.Select(hotelName);
            StringBuilder sb = new();
            sb.AppendLine($"Hotel name: {hotel.FullName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();

            var booking = hotel.Bookings.All().Count > 0;
            if (booking)
            {
                foreach (var book in hotel.Bookings.All())
                {
                    sb.AppendLine(book.BookingSummary());
                    sb.AppendLine();
                    //sb.AppendLine($"Booking number: {book.BookingNumber}");
                    //sb.AppendLine($"Room type: {book.Room}");
                    //sb.AppendLine($"Adults: {book.AdultsCount} Children: {book.ChildrenCount}");
                    //sb.AppendLine($"Total amount paid: {book.Room.PricePerNight * book.ResidenceDuration} $");
                }
            }
            else
            {
                sb.AppendLine("none");
            }


            return sb.ToString().TrimEnd();
        }


    }
}
