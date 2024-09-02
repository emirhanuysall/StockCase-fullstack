using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Models;
using Backend.Data;

namespace Backend.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly DataContext _context;

        public InvoiceService(DataContext context)
        {
            _context = context;
        }

        public List<Invoice> GetAllInvoices()
        {
            return _context.Invoices.ToList();
        }

        public Invoice GetInvoiceById(int id)
        {
            return _context.Invoices.Find(id);
        }

        public void CreateInvoice(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
        }

        public Invoice UpdateInvoice(Invoice invoice)
        {
            var existingInvoice = _context.Invoices.Find(invoice.Id);
            if (existingInvoice == null) return null;

            existingInvoice.Date = invoice.Date;
            existingInvoice.Series = invoice.Series;
            existingInvoice.IsDraft = invoice.IsDraft;
            _context.SaveChanges();

            return existingInvoice;
        }

        public bool DeleteInvoice(int id)
        {
            var invoice = _context.Invoices.Find(id);
            if (invoice == null) return false;

            _context.Invoices.Remove(invoice);
            _context.SaveChanges();

            return true;
        }

        public bool ApproveInvoice(int id)
        {
            var invoice = _context.Invoices.Find(id);
            if (invoice == null || !invoice.IsDraft) return false;

            // İş mantığı: Stok ve Cari işlemleri ekle
            invoice.IsDraft = false;
            _context.SaveChanges();
            return true;
        }
    }
}

