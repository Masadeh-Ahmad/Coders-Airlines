using System;
using System.Collections.Generic;

namespace Coders_Airlines.Models
{
    public enum Class
    {
        Economy,
        Bussiness,
        FirstClass
    }
    public enum Luggage
    {
        One,
        Two,
        Three
    }
    public class Flight
    {
        public int ID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        // New Property!!!
        public int SeatsLeft { get; set; }
        public Luggage NumOfBags { get; set; }
        public Class ClassType { get; set; }
        public double Price { get; set; }
        public List<FlightImg> ImgURLs { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}