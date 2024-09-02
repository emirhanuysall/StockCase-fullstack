using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Services;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public IActionResult GetAllInvoices()
        {
            var invoices = _invoiceService.GetAllInvoices();
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        public IActionResult GetInvoiceById(int id)
        {
            var invoice = _invoiceService.GetInvoiceById(id);
            if (invoice == null) return NotFound();
            return Ok(invoice);
        }

        [HttpPost]
        public IActionResult CreateInvoice(Invoice invoice)
        {
            _invoiceService.CreateInvoice(invoice);
            return CreatedAtAction(nameof(GetInvoiceById), new { id = invoice.Id }, invoice);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateInvoice(int id, Invoice invoice)
        {
            if (id != invoice.Id) return BadRequest();
            var updatedInvoice = _invoiceService.UpdateInvoice(invoice);
            if (updatedInvoice == null) return NotFound();
            return Ok(updatedInvoice);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInvoice(int id)
        {
            var success = _invoiceService.DeleteInvoice(id);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpPost("{id}/approve")]
        public IActionResult ApproveInvoice(int id)
        {
            var success = _invoiceService.ApproveInvoice(id);
            if (!success) return BadRequest();
            return Ok();
        }
    }
}

