using System;
using System.Collections.Generic;

namespace CukierniaEF.Models
{
    public partial class Zamowienie
    {
        public int IdZamowienia { get; set; }
        public DateTime DataPrzyjecia { get; set; }
        public DateTime? DataRealizacji { get; set; }
        public string Uwagi { get; set; }
        public int IdKlient { get; set; }
        public int IdPracownik { get; set; }

        public virtual Klient IdKlientNavigation { get; set; }
        public virtual Pracownik IdPracownikNavigation { get; set; }
    }
}
