using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TextLocal.Tests
{
    [TestClass]
    public class SendSMS : TestBase
    {
        [TestMethod]
        [ExpectedException(typeof(TextLocal.Models.TextLocalException), "No recipients specified")]
        public void TestNoReceipientsSpecified()
        {
            tl.SendSMS(new Models.SendSMS_Parameters()
            {
                message = "Test Message",
                numbers = new System.Collections.Generic.List<string>(),
                sender = "TestAPI",
                test = true
            });
        }

        [TestMethod]
        public void TestSends()
        {
            tl.SendSMS(new Models.SendSMS_Parameters()
            {
                message = "Test Message",
                numbers = new System.Collections.Generic.List<string>() {  "0061450033557"},
                sender = "TestAPI",
                test = true
            });
        }
    }
}
