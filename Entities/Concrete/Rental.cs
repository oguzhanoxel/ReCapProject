using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Rental:IEntity
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        public int UserID { get; set; }
        public DateTime RentDate { get; set; }
        public Nullable<DateTime> ReturnDate { get; set; }
    }
}
