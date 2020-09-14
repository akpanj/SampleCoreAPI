using Microsoft.EntityFrameworkCore;
using SampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAPITestProject
{
    public class InMemoryDbContextFactory
    {
        public MessageItemContext GetMessageDbContext()
        {
            var options = new DbContextOptionsBuilder<MessageItemContext>()
                            .UseInMemoryDatabase(databaseName: "InMemoryMessagedatabase")
                            .Options;
            var dbContext = new MessageItemContext(options);

            return dbContext;
        }
    }
}
