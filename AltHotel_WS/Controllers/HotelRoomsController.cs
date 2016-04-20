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
    public class HotelRoomsController : ApiController
    {
        private ViewsContext db = new ViewsContext();

        // GET: api/HotelRooms
        public IQueryable<HotelRooms> GetHotelRooms()
        {
            return db.HotelRooms;
        }

        // GET: api/HotelRooms/5
        [ResponseType(typeof(HotelRooms))]
        public IQueryable<HotelRooms> GetHotelRooms(int id)
        {
            //HotelRooms hotelRooms = db.HotelRooms.Find(id);
            //if (hotelRooms == null)
            //{
            //    return NotFound();
            //}

            //return Ok(hotelRooms);
            var hotelRoomsList = from hotelrooms in db.HotelRooms
                where hotelrooms.Hotel_No == id
                select hotelrooms;
            return hotelRoomsList;
        }

        // PUT: api/HotelRooms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHotelRooms(int id, HotelRooms hotelRooms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hotelRooms.Hotel_No)
            {
                return BadRequest();
            }

            db.Entry(hotelRooms).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelRoomsExists(id))
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

        // POST: api/HotelRooms
        [ResponseType(typeof(HotelRooms))]
        public IHttpActionResult PostHotelRooms(HotelRooms hotelRooms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HotelRooms.Add(hotelRooms);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HotelRoomsExists(hotelRooms.Hotel_No))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hotelRooms.Hotel_No }, hotelRooms);
        }

        // DELETE: api/HotelRooms/5
        [ResponseType(typeof(HotelRooms))]
        public IHttpActionResult DeleteHotelRooms(int id)
        {
            HotelRooms hotelRooms = db.HotelRooms.Find(id);
            if (hotelRooms == null)
            {
                return NotFound();
            }

            db.HotelRooms.Remove(hotelRooms);
            db.SaveChanges();

            return Ok(hotelRooms);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HotelRoomsExists(int id)
        {
            return db.HotelRooms.Count(e => e.Hotel_No == id) > 0;
        }
    }
}