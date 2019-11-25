using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }


        public Car(string model, double fuelAmount, double fuelConsimption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsimption;

            this.TravelledDistance = 0;
        }

        public void Drive(double amountOfKm)
        {
            double consumption = amountOfKm * FuelConsumptionPerKilometer;

            if (consumption <= FuelAmount)
            {
                FuelAmount -= consumption;
                TravelledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
        
        public override string ToString()
        {
              return  $"{Model} {FuelAmount:f2} {TravelledDistance}";
            
        }
    }
}
