using Moq;
using NUnit.Framework;
using CustomerCommLib;

namespace CustomerCommLib.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mailSenderMock;
        private CustomerComm _customerComm;

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            // Initializing the mock and the class under test once for all test cases
            _mailSenderMock = new Mock<IMailSender>();
            // Configuring the mock to always return true for any string arguments
            _mailSenderMock
                .Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            _customerComm = new CustomerComm(_mailSenderMock.Object);
        }

        [TestCase]
        public void SendMailToCustomer_ShouldReturnTrue()
        {
            // Act
            var result = _customerComm.SendMailToCustomer();
               Assert.That(result, Is.True);
        }
    }
}
