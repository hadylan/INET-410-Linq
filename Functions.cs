using System;
using DataSources;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Functions
{

    public static void getAll(bool isPowerful, bool sort)
    {
        // init dataSource
        var dataSource = ListMotorcyclesData.ListMotorcycles;

        // request
        var motorCyclesToShow = from motorCycle in dataSource
            where !isPowerful || motorCycle.MotorPower > 100
            orderby sort ? motorCycle.Constructor : "" // sort if sort param is true
            select $"{motorCycle.Constructor} - {motorCycle.Model} ({motorCycle.MotorPower} kW)";

        // render request result
        foreach (var motorCycleString in motorCyclesToShow)
        {
            Console.WriteLine(motorCycleString);
        }
    }

    public static void getAllJson()
    {
        // init dataSource
        var dataSource = ListMotorcyclesData.ListMotorcycles;

        // request
        var motorCyclesToShow = from motorCycle in dataSource
            select $"{motorCycle.Constructor} - {motorCycle.Model} ({motorCycle.MotorPower} kW)";

        // render request result converted in json
        Console.WriteLine(JsonConvert.SerializeObject(motorCyclesToShow));
    }

    public static void search(string constructor, string model, int motorPower)
    {
        // init dataSource
        var dataSource = ListMotorcyclesData.ListMotorcycles;

        // request
        var motorCyclesToShow = from motorCycle in dataSource
            let motorCycleToReturn = $"{motorCycle.Constructor} - {motorCycle.Model} ({motorCycle.MotorPower} kW)"
            where motorCycle.Constructor.Contains(constructor, StringComparison.InvariantCultureIgnoreCase)
                && motorCycle.Model.Contains(model, StringComparison.InvariantCultureIgnoreCase)
                && motorCycle.MotorPower == motorPower
            select motorCycleToReturn;

        // render request result
        foreach (var motorCycleString in motorCyclesToShow)
        {
            Console.WriteLine(motorCycleString);
        }
    }
}