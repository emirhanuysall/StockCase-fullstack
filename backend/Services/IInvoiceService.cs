using Backend.Models;
using System.Collections.Generic;

namespace Backend.Services
{
    public interface IInvoiceService
    {
        List<Invoice> GetAllInvoices();
        Invoice GetInvoiceById(int id);
        void CreateInvoice(Invoice invoice);
        Invoice UpdateInvoice(Invoice invoice);
        bool DeleteInvoice(int id);
        bool ApproveInvoice(int id);
    }
}

