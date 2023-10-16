using BookingApp.IO.Contracts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private readonly List<IRoom> rooms;

        public RoomRepository()
        {
            rooms = new List<IRoom>();
        }


        public void AddNew(IRoom model) => rooms.Add(model);
        //{
        //    if (model is Studio)
        //    {
        //        rooms.Add(new Studio());
        //    }
        //    if (model is DoubleBed)
        //    {
        //        rooms.Add(new DoubleBed());
        //    }
        //    if (model is Apartment)
        //    {
        //        rooms.Add(new Apartment());
        //    }
        //}



        public IRoom Select(string criteria) => rooms.FirstOrDefault(r => r.GetType().Name == criteria);
        public IReadOnlyCollection<IRoom> All() => rooms.AsReadOnly();

    }
}
