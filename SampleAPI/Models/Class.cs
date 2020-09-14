using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Models
{
    public interface IMessageItemContext
    {
         DbSet<MessageItem> MessageItems { get; set; }
    }
}
