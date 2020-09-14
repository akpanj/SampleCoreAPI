using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleAPI.Models;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly MessageItemContext _context;
        public MessageController(MessageItemContext context)
        {
            _context = context;

            if (_context.MessageItems.Count() == 0)
            {
                // Create a new MessageItem if collection is empty
                _context.MessageItems.Add(new MessageItem { Message = "Hello World from Controller" });
                _context.MessageItems.Add(new MessageItem { Message = "Hello World from Controller 2"  });
                _context.SaveChanges();
            }
        }

        #region GetAll
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageItem>>> GetMessageItems()
        {
            return await _context.MessageItems.ToListAsync();
        }
        #endregion

        #region GetByID
        // GET: api/Message/1
        [HttpGet("{id}")]
        public async Task<ActionResult<MessageItem>> GetMessageItem(long id)
        {
            var messageItem = await _context.MessageItems.FindAsync(id);

            if (messageItem == null)
            {
                return NotFound();
            }

            return messageItem;
        }
        #endregion

        #region Create
        // POST: api/Message
        [HttpPost]
        public async Task<ActionResult<MessageItem>> PostMessageItem([FromBody]MessageItem item)
        {
            _context.MessageItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMessageItem), new { id = item.Id }, item);
        }
        #endregion

    }
}
