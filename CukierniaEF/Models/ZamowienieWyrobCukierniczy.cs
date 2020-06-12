using System;
using System.Collections.Generic;

namespace CukierniaEF.Models
{
    public partial class ZamowienieWyrobCukierniczy
    {
        public int IdZamowienia { get; set; }
        public int IdWyrobuCukierniczego { get; set; }
        public int Ilosc { get; set; }
        public string Uwagi { get; set; }

        public virtual WyrobCukierniczy IdWyrobuCukierniczegoNavigation { get; set; }
        public virtual Zamowienie IdZamowieniaNavigation { get; set; }
    }
}
