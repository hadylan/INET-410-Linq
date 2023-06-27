﻿using System;
using DataSources;
using System.Linq;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace LinqExercicePresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            // check if at least one arg is given
            if (args.Length > 0)
            {
                // get first arg
                string argument = args[0];

                // check first arg value and call appropriate function
                switch (argument)
                {
                    case "getAll":
                        bool isPowerful = false;
                        bool sort = false;

                        if (args.Contains("-isPowerful")) {
                            isPowerful = true;
                        }

                        if (args.Contains("-sort")) {
                            sort = true;
                        }

                        Functions.getAll(isPowerful, sort);
                    break;

                    case "getAllJson":
                        Functions.getAllJson();
                    break;

                    case "search":
                        if (args.Length > 3)
                        {
                            Functions.search(args[1], args[2], int.Parse(args[3]));
                        } else
                        {
                            throw new NullReferenceException("Please give at least fourth args, ex : constructor(string) model(string) motorPower(integer)");
                        }
                    break;

                    default:
                        Console.WriteLine("Argument non pris en charge.");
                    break;
                }
            }
        }
    }
}