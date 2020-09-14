using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SampleAPI.Controllers;
using Moq;
using Microsoft.EntityFrameworkCore;
using SampleAPI.Models;
using System.Threading.Tasks;
using System.Linq;
using Moq.AutoMock;
using Microsoft.AspNetCore.Mvc;

namespace SampleAPITestProject
{
    [TestClass]
    public class Tests
    {
        [TestInitialize]
        public void Setup()
        {
        }

        [TestMethod]
        public void Test1()
        {
            int x = 1;
            Assert.IsTrue(x == 1);
        }
    }
}