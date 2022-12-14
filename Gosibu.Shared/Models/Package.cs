﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gosibu.Shared.Models
{
    public class Package
    {
        public string Key { get; set; }
        public string PackageName { get; set; }
        public string Departure { get; set; }
        public string Destination1 { get; set; }
        public string Destination2 { get; set; }
        public string Destination3 { get; set; }
        public string Destination4 { get; set; }
        public string Duration { get; set; }
        public string PackagePrice { get; set; }
        public string PersonInCharge { get; set; }
        public string PICMobileumber { get; set; }
        public string Discription { get; set; }
        public string Attention { get; set; }

    }
}
