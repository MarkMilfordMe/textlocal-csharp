using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextLocal.Tests
{
    [TestClass]
    public class TestBase
    {
        private string apiKey = "";

        protected TextLocal.TextLocalConnector tl;

        public TestBase()
        {
            tl = new TextLocal.TextLocalConnector(apiKey);
        }
    }
}
