using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AltHotel_WS;

namespace AltHotel_WS.Controllers
{
    public class Guestlists1Controller : ApiController
    {
        private ViewsContext db = new ViewsContext();

        // GET: api/Guestlists1
        public IQueryable<Guestlist> GetGuestlist()
        {
            return db.Guestlist;
        }

        // GET: api/Guestlists1/5
        [ResponseType(typeof(Guestlist))]
        public IQueryable<GuestListDTO> GetGuestlist(DateTime id)
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


        // GET: api/Guestlists1/GetGuestlistHotel/5
        [ResponseType(typeof(Guestlist))]
        [HttpGet]
        [System.Web.Http.ActionName("GetGuestlistHotel")]
        public IQueryable<GuestListDTO> GetGuestlistHotel(int id)
        {
            var guestlist = from Guest in db.Guestlist
                            where Guest.Room_No==id
                            select new GuestListDTO
                            {
                                GuestName = Guest.GuestName,
                                HotelName = Guest.HotelName,
                                RoomNo = Guest.Room_No
                            };
            return guestlist;
        }

        // PUT: api/Guestlists1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGuestlist(string id, Guestlist guestlist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != guestlist.HotelName)
            {
                return BadRequest();
            }

            db.Entry(guestlist).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestlistExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Guestlists1
        [ResponseType(typeof(Guestlist))]
        public IHttpActionResult PostGuestlist(Guestlist guestlist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Guestlist.Add(guestlist);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GuestlistExists(guestlist.HotelName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = guestlist.HotelName }, guestlist);
        }

        // DELETE: api/Guestlists1/5
        [ResponseType(typeof(Guestlist))]
        public IHttpActionResult DeleteGuestlist(string id)
        {
            Guestlist guestlist = db.Guestlist.Find(id);
            if (guestlist == null)
            {
                return NotFound();
            }

            db.Guestlist.Remove(guestlist);
            db.SaveChanges();

            return Ok(guestlist);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GuestlistExists(string id)
        {
            return db.Guestlist.Count(e => e.HotelName == id) > 0;
        }
    }
}