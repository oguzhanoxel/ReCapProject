﻿using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarNameInvalid = "Car name length must be more than two charaters";
        public static string CarAdded = "Car Added";
        public static string CarDeleted = "Car Deleted";
        public static string CarUpdated = "Car Updated";
        public static string ColorAdded = "Color Added";
        public static string ColorDeleted = "Color Deleted";
        public static string ColorUpdated = "Color Updated";
        public static string BrandAdded = "Brand Added";
        public static string BrandDelete = "Brand Deleted";
        public static string BrandUpdated = "Brand Updated";
        public static string UserAdded = "User Added";
        public static string UserDeleted = "User Deleted";
        public static string UserUpdated = "User Updated";
        public static string CustomerAdded = "Customer Added";
        public static string CustomerDeleted = "Customer Deleted";
        public static string CustomerUpdated = "Customer Updated";
        public static string RentalAdded = "Rental Added";
        public static string RentalDeleted = "Rental Deleted";
        public static string RentalUpdated = "Rental Updated";
        public static string RentalReturnDateError = "Rental return date is empty !";
        public static string CarImageAdded = "Car Image Added";
        public static string CarImageDeleted = "Car Image Deleted";
        public static string CarImageUpdated = "Car Image Updated";
        public static string CarImageCountError = "Image count less than 5";
        public static string RegisterSuccess = "Register success";
        public static string UserNotFound = "User not found";
        public static string PasswordWrong = "Password wrong";
        public static string LoginSuccess = "Login success";
        public static string UserExists = "User exists";
        public static string TokenCreated = "Token created";
        public static string AuthorizationDenied = "Authorization denied";
    }
}
