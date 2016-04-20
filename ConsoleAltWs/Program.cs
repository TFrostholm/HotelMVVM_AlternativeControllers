using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AltHotel_WS;

namespace ConsoleAltWs
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ServerUrl = "http://localhost:50011";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    
                    var roomNumber = 33;
                    var hotelNumber = 3;
                    string deleteUrl = "api/oneroom/" + hotelNumber + "/" + roomNumber;
                    var response = client.DeleteAsync(deleteUrl).Result;
                    if (response.IsSuccessStatusCode)
                    {
                       Console.WriteLine("Room # " + roomNumber + " has been deleted.");
                    }
                    
                    //Console.WriteLine("api/hotels");
                    //var responseHotels = client.GetAsync("api/hotels").Result;
                    //if (responseHotels.IsSuccessStatusCode)
                    //{
                    //    IEnumerable<Hotel> hotels = responseHotels.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;
                    //    foreach (var hotel in hotels)
                    //    {
                    //        Console.WriteLine(hotel);
                    //    }
                    //}
                    //1. Testing an standard controller
                    // Create a new controller for the booking class/table and
                    // list all the bookings.
                    //Console.WriteLine("api/bookings");
                    //var responseBooking = client.GetAsync("api/bookings").Result;
                    //if (responseBooking.IsSuccessStatusCode)
                    //{
                    //    IEnumerable<Booking> bookings = responseBooking.Content.ReadAsAsync<IEnumerable<Booking>>().Result;
                    //    foreach (var booking in bookings)
                    //    {
                    //        Console.WriteLine(booking);
                    //    }
                    //}
                    //Console.WriteLine();

                        // Testing a Guestlist view
                        //Console.WriteLine("api/guestlists");
                        //var responseGuestList = client.GetAsync("api/guestlists").Result;
                        //if (responseGuestList.IsSuccessStatusCode)
                        //{
                        //    IEnumerable<Guestlist> guestlists = responseGuestList.Content.ReadAsAsync<IEnumerable<Guestlist>>().Result;
                        //    foreach (var guestlist in guestlists)
                        //    {
                        //        Console.WriteLine(guestlist);
                        //    }
                        //}

                        //2. Testing a standard controller based on a View
                        // Create a view in the Database that can select hotelno, name, room_no, price
                        // Add a New Item to the project and select a new ADO.NET Entity Datamodel (CodeFirst model)
                        // Generate a controller
                        // Discuss: how could you generate a hotelroom list without using a view
                        // what are the pro and cons for the 2 solutions listing the hotelrooms
                        //Console.WriteLine("api/hotelrooms");
                        //var responseHotelrooms = client.GetAsync("api/hotelrooms").Result;
                        //if (responseHotelrooms.IsSuccessStatusCode)
                        //{
                        //    IEnumerable<HotelRoom> hotelrooms = responseHotelrooms.Content.ReadAsAsync<IEnumerable<HotelRoom>>().Result;
                        //    foreach (var hotelroom in hotelrooms)
                        //    {
                        //        Console.WriteLine(hotelroom);
                        //    }
                        //}

                        //3. Testing the custom TestController
                        //Console.WriteLine("TestController");
                        //Console.WriteLine("api/Test");
                        //var responseTest1 = client.GetAsync("api/Test").Result;
                        //if (responseTest1.IsSuccessStatusCode)
                        //{
                        //    IEnumerable<string> test1 = responseTest1.Content.ReadAsAsync<IEnumerable<string>>().Result;
                        //    foreach (var t in test1)
                        //    {
                        //        Console.WriteLine(t);
                        //    }
                        //}
                        //Console.WriteLine();
                        //Console.WriteLine("api/Test/Foo2");
                        //var responseTest2 = client.GetAsync("api/Test/Foo2").Result;
                        //if (responseTest2.IsSuccessStatusCode)
                        //{
                        //    IEnumerable<string> test2 = responseTest2.Content.ReadAsAsync<IEnumerable<string>>().Result;
                        //    foreach (var t in test2)
                        //    {
                        //        Console.WriteLine(t);
                        //    }
                        //}

                        //Console.WriteLine();
                        //Console.WriteLine("api/Test/Foo3");
                        //var responseTest3 = client.GetAsync("api/Test/Foo3").Result;
                        //if (responseTest3.IsSuccessStatusCode)
                        //{
                        //    IEnumerable<string> test3 = responseTest3.Content.ReadAsAsync<IEnumerable<string>>().Result;
                        //    foreach (var t in test3)
                        //    {
                        //        Console.WriteLine(t);
                        //    }
                        //}

                        //Console.WriteLine();
                        //Console.WriteLine("api/Test/1");
                        //var responseTest4 = client.GetAsync("api/Test/1").Result;
                        //if (responseTest4.IsSuccessStatusCode)
                        //{
                        //    string test4 = responseTest4.Content.ReadAsAsync<string>().Result;
                        //    Console.WriteLine(test4);
                        //}

                        // Testing a Guestlist2 
                        //Console.WriteLine("api/guestlists2");
                        //var responseGuestList = client.GetAsync("api/guestlists2").Result;
                        //if (responseGuestList.IsSuccessStatusCode)
                        //{
                        //    IEnumerable<Guestlist> guestlists = responseGuestList.Content.ReadAsAsync<IEnumerable<Guestlist>>().Result;
                        //    foreach (var guestlist in guestlists)
                        //    {
                        //        Console.WriteLine(guestlist);
                        //    }
                        //}

                        //Console.WriteLine("api/guestlists2/2011-2-3");
                        //DateTime dateTime = new DateTime(2011, 3,2);
                        //var responseGuestList = client.GetAsync("api/guestlists2/" + dateTime.ToShortDateString()).Result;
                        //if (responseGuestList.IsSuccessStatusCode)
                        //{
                        //    IEnumerable<GuestListDTO> guestlistsDTO = responseGuestList.Content.ReadAsAsync<IEnumerable<GuestListDTO>>().Result;
                        //    foreach (var guestlistDTO in guestlistsDTO)
                        //    {
                        //        Console.WriteLine(guestlistDTO);
                        //    }
                        //}

                        //Console.WriteLine("api/HotelRooms/5");
                        //var responseHotelRoomsList = client.GetAsync("api/HotelRooms/5").Result;
                        //if (responseHotelRoomsList.IsSuccessStatusCode)
                        //{
                        //    IEnumerable<HotelRooms> hotelRoomsList = responseHotelRoomsList.Content.ReadAsAsync<IEnumerable<HotelRooms>>().Result;
                        //    foreach (var hotelRoom in hotelRoomsList)
                        //    {
                        //        Console.WriteLine(hotelRoom);
                        //    }
                        //}

                    }
                catch (Exception)
                {
                    throw;
                }
                Console.ReadLine();
            }
        }
    }
}
