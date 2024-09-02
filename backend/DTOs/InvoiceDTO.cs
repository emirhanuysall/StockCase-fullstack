using System;
using System.Collections.Generic;

namespace Backend.DTO
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public string Series { get; set; }
        public bool IsDraft { get; set; }
        public List<InvoiceDetailDTO> InvoiceDetails { get; set; }
    }

    public class InvoiceDetailDTO
    {
        public int StockId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}

