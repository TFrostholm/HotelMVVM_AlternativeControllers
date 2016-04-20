using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AltHotel_WS.Controllers
{
    public class OneRoomController : ApiController
    {

        private HotelContext db = new HotelContext();


        /// <summary>
        /// Get one room, given a hotelnumber and roomnumber as the primary key is a composite of those two parameters.
        /// example call: "api/oneroom/3/2
        /// </summary>
        /// <param name="hotelNumber"></param>
        /// <param name="roomNumber"></param>
        /// <returns></returns>
        [Route("api/oneroom/{hotelNumber:int}/{roomNumber:int}")]
        [HttpGet]
        [ResponseType(typeof(Room))]
        public IHttpActionResult GetRoom(int hotelNumber, int roomNumber)
        {
            Room room = new Room();
            IQueryable<Room> allRooms = db.Rooms;
            var roomQuery = from r in allRooms
                            where r.Hotel_No == hotelNumber && r.Room_No == roomNumber
                            select r;
            room= roomQuery.FirstOrDefault();
            //foreach (Room room1 in roomQuery)
            //{
            //    room = room1;
            //}
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }


        [Route("api/oneroom/{hotelNumber:int}/{roomNumber:int}")]
        [HttpDelete]
        [ResponseType(typeof(Room))]
        public IHttpActionResult DeleteRoom(int hotelNumber, int roomNumber)
        {

           

            var roomQuery = from r in db.Rooms
                            where r.Hotel_No == hotelNumber && r.Room_No == roomNumber
                            select r
                           
                            ;

            Room room = roomQuery.FirstOrDefault();
          
            if (room!= null)
            {
                db.Rooms.Remove(room);
                db.SaveChanges();
            }
            return Ok(room);
           

        }
    }

}

