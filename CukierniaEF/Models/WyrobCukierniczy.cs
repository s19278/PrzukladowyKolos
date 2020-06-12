using System;
using System.Collections.Generic;

namespace CukierniaEF.Models
{
    public partial class WyrobCukierniczy
    {
        public int IdWyrobuCukierniczego { get; set; }
        public string Nazwa { get; set; }
        public float CenaZaSzt { get; set; }
        public string Typ { get; set; }
    }
}
