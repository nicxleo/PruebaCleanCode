using System;
using System.Collections.Generic;
using System.Xml;

namespace Masiv.PruebaCleanCode.Entities
{
    public sealed class Constant
    {
        public const string Opened = "abierta";
        public const string Closed = "cerrada";
        public const string Created = "creada";
        public const string Successful = "exitosa";
        public const string Denied = "denegada";
        public const string Red = "rojo";
        public const string Black = "negro";
        public const int MinValue = 0;
        public const int MaxNumber = 36;
        public const int MaxAmount = 10000;
        public const double WinNumber = 5;
        public const double WinColor = 1.8;
        public const StringComparison IgnoreCase = StringComparison.InvariantCultureIgnoreCase;
        public static List<string> LstColor = new List<string>
        {
            Red,
            Black
        };
    }
}