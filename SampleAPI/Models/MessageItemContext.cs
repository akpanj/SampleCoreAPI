using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Models
{
    public class MessageItemContext: DbContext, IMessageItemContext
    {
        public MessageItemContext(DbContextOptions<MessageItemContext> options)
                :base(options)
        {

        }
        public DbSet<MessageItem> MessageItems { get; set; }
    }
}
