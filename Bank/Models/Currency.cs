using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Bank.Models
{
    public partial class Currency
    {
        public Currency()
        {
            Deposits = new HashSet<Deposit>();
        }

        [Display(Name = "Код валюты")]
        public long CurId { get; set; }
        [Display(Name = "Наименование")]
        public long Name { get; set; }
        [Display(Name = "Обменный курс")]
        public long ExchangeRate { get; set; }

        public virtual ICollection<Deposit> Deposits { get; set; }
    }
}
