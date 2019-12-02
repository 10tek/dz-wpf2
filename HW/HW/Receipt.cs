using System;
using System.Collections.Generic;
using System.Text;

namespace HW
{
    public class Receipt
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string IIN { get; set; }
        public string Street { get; set; }
        public string HouseNum { get; set; }
        public string FlatNum { get; set; }
        public string PhoneNum { get; set; }
        public string Type { get; set; }
        public int Sum { get; set; }
    }
}
