﻿using SpaceMUD.Server;
using System;

namespace SpaceMUD
{
    public class MainClass
    {

        public static void Main(string[] args)
        {
            var port = 4000;
            using (var server = new TelnetSocketServer(null, port))
                Run(server);

        }

        private static void Run(TelnetSocketServer server)
        {
            server.StartServer();

            var input = Console.ReadLine();
            Console.WriteLine($"There are {server.Connections.Count} connections set up.");
            input = Console.ReadLine();

        }
    }
}
