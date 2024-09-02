using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime Date { get; set; }
        public string Series { get; set; }
        public bool IsDraft { get; set; } = true;
        public List<InvoiceDetail> Details { get; set; }
    }
}

