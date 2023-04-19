using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapperApp.WebUI.Models;
using AutoMapperApp.WebUI.Models.Context;
using FluentValidation;
using AutoMapper;
using AutoMapperApp.WebUI.Dtos;

namespace AutoMapperApp.WebUI.Controllers
{
    //Metod ismiyle eşleme yapmak istiyoruz bu yuzden route değişti
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerApiController : ControllerBase
    {
        private readonly AppDatabaseContext _context;
        private readonly IValidator<Customer> _validator;
        private readonly IMapper _mapper;

        public CustomerApiController(AppDatabaseContext context, IValidator<Customer> validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        // GET: api/CustomerApi
        //[HttpGet]
        //public async Task<ActionResult<IList<CustomerDto>>> GetCustomers()
        //{
        //    //burada dönüştürme işlemii automapper ile yaptık
        //  if (_context.Customers == null)
        //  {
        //      return NotFound();
        //  }

        //  List<Customer> customers= await _context.Customers.ToListAsync();
        //    return _mapper.Map<List<CustomerDto>>(customers);
        //}


        [HttpGet]
        public async Task<ActionResult<IList<CustomerDiferentPropertyDto>>> GetCustomers()
        {
            //burada dönüştürme işlemii automapper ile yaptık
            if (_context.Customers == null)
            {
                return NotFound();
            }

            List<Customer> customers = await _context.Customers.ToListAsync();
            return _mapper.Map<List<CustomerDiferentPropertyDto>>(customers);
        }

        // GET: api/CustomerApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
          if (_context.Customers == null)
          {
              return NotFound();
          }
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/CustomerApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/CustomerApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
          if (_context.Customers == null)
          {
              return Problem("Entity set 'AppDatabaseContext.Customers'  is null.");
          }
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/CustomerApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
