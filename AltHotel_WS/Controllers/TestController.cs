using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using AltHotel_WS;

namespace AltHotel_WS.Controllers
{
    public class TestController : ApiController
    {
        private ViewsContext db = new ViewsContext();

        // GET: api/Guestlists
        [System.Web.Http.Route("api/Test/GetGuestlists")]
        [System.Web.Http.HttpGet]
        public IQueryable<Guestlist> GetGuestlists()
        {
            return db.Guestlist;
        }


        // GET: api/api/guestlists/2011-2-3
        [ResponseType(typeof(GuestListDTO))]
        public IQueryable<GuestListDTO> GetGuestList(DateTime id)
        {
            var guestlist = from Guest in db.Guestlist
                            where (Guest.Date_From <= id) && (Guest.Date_To >= id)
                            select new GuestListDTO
                            {
                                GuestName = Guest.GuestName,
                                HotelName = Guest.HotelName,
                                RoomNo = Guest.Room_No
                            };
            return guestlist;
        }

        // GET: api/Test
        [System.Web.Http.ActionName("DefaultAction")]
        [System.Web.Http.HttpGet]
        public IEnumerable<string> Foo1()
        {
            return new string[] { "Foo1", "value1" };
        }

        // GET: api/Test/Foo2
        [System.Web.Http.Route("api/Test/Foo2")]
        [System.Web.Http.HttpGet]
        public IEnumerable<string> Foo2()
        {
            return new string[] { "Foo2", "value2" };
        }

        // GET: api/Test/Foo3
        [System.Web.Http.Route("api/Test/Foo3")]
        [System.Web.Http.HttpGet]
        public IEnumerable<string> Foo3()
        {
            return new string[] { "Foo3", "value3" };
        }


        //[System.Web.Http.Route("api/Guests/{GuestNo:int}/{room_no:int}/Bookings")]
        //[System.Web.HttpGet]
        //public IEnumerable<Booking> GivMigBookingByGuestNo(int GuestNo, int roomno)
        //{
        //    return db.Booking.Where(x => x.Guest_No == GuestNo);
        //}



        // GET: api/Test/1
        [System.Web.Http.ActionName("DefaultAction")]
        public string Get(int id)
        {
            return "value";
        }

    }
}
