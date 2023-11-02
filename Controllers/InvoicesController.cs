using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvoiceGeneratorAPI.Models;
//using Microsoft.AspNetCore.Cors;

namespace InvoiceGeneratorAPI.Controllers
{
    //[EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly InvoiceContext _context;

        public InvoicesController(InvoiceContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoice()
        {
          if (_context.Invoice == null)
          {
              return NotFound();
          }
            return await _context.Invoice.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(long id)
        {
          if (_context.Invoice == null)
          {
              return NotFound();
          }
            var invoice = await _context.Invoice.FindAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return invoice;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(long id, Invoice invoice)
        {
            if (id != invoice.id)
            {
                return BadRequest();
            }

            _context.Entry(invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
        {
          if (_context.Invoice == null)
          {
              return Problem("Entity set 'InvoiceContext.Invoice'  is null.");
          }
            _context.Invoice.Add(invoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInvoice), new { id = invoice.id }, invoice);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(long id)
        {
            if (_context.Invoice == null)
            {
                return NotFound();
            }
            var invoice = await _context.Invoice.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            _context.Invoice.Remove(invoice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceExists(long id)
        {
            return (_context.Invoice?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
