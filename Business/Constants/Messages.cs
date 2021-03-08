using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

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

        public static string ImageUpdated = "Image Updated!";
        public static string ImageFound = "Image Found!";
        public static string ImagesListed = "All Images are below...";
        public static string ImageDeleted = "This image deleted forever :((";
        public static string CarImageAdded = "Image added to db!!!";

        public static string ReturnDate = "Return Date...";
        public static string BrandFound = "Here is your brand you search";
        public static string BrandsListed = "You can find all brands from list below";

        public static string ResultDeleted = "You deleted the Result";
        public static string ResultAdded = "You added new result <3";
        public static string ResultUpdated = "Result updated...";

        public static string ColorDeleted = "Goodbye, litte color...";
        public static string ColorsListed = "Woaw, there are a lot of colors!";
        public static string ColorAdded = "This looks nice!";
        public static string ColorFound = "What a beatiful choice...";
        public static string ColorUpdated = "This looks nicer?";

        public static string LimitExceed = "Limit exceed!!!";
        public static string AuthorizationDenied = "You have not a access to this area !!!";

        public static string ClaimsListed = "Claims listed!!!";
        public static string UserCreated = "User you want to add was added...";
        public static string UserAlreadyExists = "Boom, user already exist. You can use login page...";
        public static string PasswordIncorrect = "Password Incorrect. Are you sure that you wrote correctly?";

        public static string TokenCreated { get; internal set; }
    }
}
