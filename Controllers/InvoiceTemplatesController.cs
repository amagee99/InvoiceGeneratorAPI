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
   
    public class InvoiceTemplatesController : ControllerBase
    {
        
        private readonly InvoiceTemplateContext _context;

        public InvoiceTemplatesController(InvoiceTemplateContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceTemplate>>> GetInvoiceTemplate()
        {
          if (_context.InvoiceTemplates == null)
          {
              return NotFound();
          }
            return await _context.InvoiceTemplates.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceTemplate>> GetInvoiceTemplate(long id)
        {
          if (_context.InvoiceTemplates == null)
          {
              return NotFound();
          }
            var invoiceTemplate = await _context.InvoiceTemplates.FindAsync(id);

            if (invoiceTemplate == null)
            {
                return NotFound();
            }

            return invoiceTemplate;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceTemplate(long id, InvoiceTemplate invoiceTemplate)
        {
            if (id != invoiceTemplate.id)
            {
                return BadRequest();
            }

            _context.Entry(invoiceTemplate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceTemplateExists(id))
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
        public async Task<ActionResult<InvoiceTemplate>> PostInvoiceTemplate(InvoiceTemplate invoiceTemplate)
        {
          if (_context.InvoiceTemplates == null)
          {
              return Problem("Entity set 'InvoiceTemplateContext.InvoiceTemplate'  is null.");
          }
            _context.InvoiceTemplates.Add(invoiceTemplate);
            await _context.SaveChangesAsync();
            

            return CreatedAtAction(nameof(GetInvoiceTemplate), new { id = invoiceTemplate.id }, invoiceTemplate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceTemplate(long id)
        {
            if (_context.InvoiceTemplates == null)
            {
                return NotFound();
            }
            var invoiceTemplate = await _context.InvoiceTemplates.FindAsync(id);
            if (invoiceTemplate == null)
            {
                return NotFound();
            }

            _context.InvoiceTemplates.Remove(invoiceTemplate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceTemplateExists(long id)
        {
            return (_context.InvoiceTemplates?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
