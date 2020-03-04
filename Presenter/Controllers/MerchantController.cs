using Microsoft.AspNetCore.Mvc;
using FluentVal_Task.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace FluentVal_Task.Presenter.Controllers
{
    [ApiController]
    [Route("merchant")]
    [Authorize]
    public class MerchantController : ControllerBase
    {
        private readonly FluentContext _context;
        public MerchantController(FluentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMerchant()
        {
            var me = _context.Merchants;
            return Ok(new {message = "success retrieve data", status = true, data = me});
        }

        [HttpPost]
        public IActionResult PostMerchant(ReqMer me)
        {
            _context.Merchants.Add(me.data.attributes);
            _context.SaveChanges();
            return Ok(me);
        }

        [HttpGet("{id}")]
        public IActionResult GetMerchantById(int id)
        {
            var me = _context.Merchants.First(i => i.Id == id);
            return Ok(me);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMerchant(int id, ReqMer merchant)
        {
            var me = _context.Merchants.First(i => i.Id == id);
            me.Name = merchant.data.attributes.Name;

            _context.Merchants.Update(me);
            _context.SaveChanges();
            return Ok(me);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMerchant(int id)
        {
            var me = _context.Merchants.First(i => i.Id == id);
            _context.Merchants.Remove(me);
            _context.SaveChanges();
            return Ok(me);
        }
    }

    public class ReqMer
    {
        public Merc data { get; set; }
    }

    public class Merc
    {
        public Merchant attributes { get; set; }
    }
}