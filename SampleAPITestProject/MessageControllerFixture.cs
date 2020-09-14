using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleAPI.Controllers;
using SampleAPI.Models;
using System.Threading.Tasks;
using System.Linq;


namespace SampleAPITestProject
{
    [TestClass]
    public class MessageControllerFixture
    {
        private MessageController _controller;
        private readonly MessageItemContext _dbContext;

        public MessageControllerFixture()
        {
            _dbContext = new InMemoryDbContextFactory().GetMessageDbContext();
             _controller = new MessageController(_dbContext);
        }
        [TestInitialize]
        public void Setup()
        {
            if (_dbContext.MessageItems.Count() == 0)
            {
                _dbContext.MessageItems.Add(new MessageItem { Message = "Test Message 1" });
                _dbContext.MessageItems.Add(new MessageItem { Message = "Test message 2" });
                _dbContext.SaveChanges();
            }
        }

        [TestMethod]
        public async Task SampleTest()
        {
            var message = new MessageItem();
          

            var result = await _controller.GetMessageItem(1);
            Assert.IsTrue(result.Value.Message.Length > 0);
          
        }

        [TestMethod]
        public async Task TestGetAllItems()
        {
            var message = new MessageItem();
 
            var result = await _controller.GetMessageItems();
            Assert.IsTrue(result.Value.Count() == 2);

        }


    }
}
