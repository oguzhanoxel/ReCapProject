using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarImageDetailDto:IDto
    {
        public int ID { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
