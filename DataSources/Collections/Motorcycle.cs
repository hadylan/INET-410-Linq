using System;
using System.Collections.Generic;
using System.Text;

namespace DataSources
{
    public class Motorcycle
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Constructor { get; set; }
        public int MotorPower { get; set; }

        public Motorcycle(int id, string model, string constructor, int motorPower)
        {
            Id = id;
            Model = model;
            Constructor = constructor;
            MotorPower = motorPower;
        }
    }
}