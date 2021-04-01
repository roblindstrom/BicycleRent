﻿using BicycleRent.Shared;

namespace BicycleRent.Api.Resources
{
    public class SaveBicycleResource
    {
        public double BicycleId { get; set; }

        public double PricePerDay { get; set; }

        public BicycleBrand BicycleBrand { get; set; }

        public BicycleSize BicycleSize { get; set; }
    }
}
