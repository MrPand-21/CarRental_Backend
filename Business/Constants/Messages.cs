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
    }
}
