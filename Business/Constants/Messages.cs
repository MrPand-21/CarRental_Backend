using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Constants
{
    public static class Messages
    {

        public static string CarFound = "Here is your car <3";
        public static string CarsListed = "These are your cars but you listed them, do not discriminate!";
        public static string CarUpdated = "Car updated to db";
        public static string CarsDetailsListed = "Here is the details of some cars!";
        public static string CarDeleted = "Unfortunately, We lost a car...";
        public static string CarAdded = "Your Car Added to our db!";
        public static string CarNotAdded = "Your car's price must more than 0$ and Your car's description must be min. 2 letters!!!";
        public static string MaintenanceTime = "Our App/Program in the Maintance now...";

        public static string CustomerAdded = "New Customer Added to our db <3";
        public static string CustomerDeleted = "Good bye old Customer friend...";
        public static string CustomerUpdated = "Customer updated!!!";
        public static string CustomersListed = "You can see all of the Customers above";
        public static string CustomerFound = "Yeah, intelligent Program Found the Customer you searched!";

        public static string RentalAdded = "Thank you for choosing us!";
        public static string RentalDeleted = "Okay, That's enough";
        public static string RentalsListed = "You can see all Rentals above...";
        public static string RentalFound = "Did you search this ?";
        public static string RentalUpdated = "Woaw, new update to db...";

        public static string UserDeleted = "Heey,Why?!!";
        public static string UserAdded = "Hello, my dear friend";
        public static string UserUpdated = "You are a new person now!";
        public static string UsersListed = "Look at the above!";
        public static string UserFound = "Here it is :))";

        public static string ReturnDate { get; internal set; }
        public static string BrandFound { get; internal set; }
        public static string BrandsListed { get; internal set; }
        public static string ResultDeleted { get; internal set; }
        public static string ResultAdded { get; internal set; }
        public static string ResultUpdated { get; internal set; }
        public static string ColorDeleted { get; internal set; }
        public static string ColorsListed { get; internal set; }
        public static string ColorAdded { get; internal set; }
        public static string ColorFound { get; internal set; }
        public static string ColorUpdated { get; internal set; }
    }
}
