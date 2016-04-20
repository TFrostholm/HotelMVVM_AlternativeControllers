using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltHotel_WS
{
    public class GuestListDTO
    {
        public string HotelName { get; set; }
        public string GuestName { get; set; }
        public int RoomNo { get; set; }

        public override string ToString()
        {
            return string.Format("HotelName: {0}, GuestName: {1}, RoomNo: {2}", HotelName, GuestName, RoomNo);
        }
    }
}