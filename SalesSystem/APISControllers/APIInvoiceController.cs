using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesSystem.APISControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIInvoiceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public APIInvoiceController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<APIInvoiceController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.InvoiceTemp.Include(x => x.Product)
                       .ToList());
        }

        // GET api/<APIInvoiceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<APIInvoiceController>
        [HttpPost]
        public IActionResult Post([FromBody] InvoiceTemp model)
        {
            try
            {
                var result = _context.InvoiceTemp.FirstOrDefault(x => x.ProductId.Equals(model.ProductId));

                if (result == null)
                {
                    _context.InvoiceTemp.Add(model);

                    // _context.InvoiceTemp.Add(model);
                    //_context.SaveChanges();
                    //return Ok();
                }
                else
                {
                    result.Quentit += model.Quentit;
                    result.Total += model.PriceSale * model.Quentit;
                    _context.InvoiceTemp.Update(result);
                }
                _context.SaveChanges();
                return Ok();
            }
            
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
           
        }

        // PUT api/<APIInvoiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<APIInvoiceController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try{
                var result = _context.InvoiceTemp.FirstOrDefault(x => x.InvoiceId.Equals(id));
                if (result != null)
                {
                     _context.InvoiceTemp.Remove(result);
                    _context.SaveChanges();
                    return Ok();
                }
                return BadRequest();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllTotal")]
        public IActionResult GetAllTotal()
        {
            return Ok(_context.InvoiceTemp.Sum(x => x.Total));
        }
    }
}
