using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AltHotel_WS.Controllers
{
    public class GuestlistsController : ApiController
    {
        private ViewsContext db = new ViewsContext();

        // GET: api/GuestLists
        public IQueryable<Guestlist> GetGuestLists()
        {
            return db.Guestlist;
        }

        // GET: api/guestlists/2011-2-3
        [ResponseType(typeof (GuestListDTO))]
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
    }
}
