using CustomerFeedback.Data;
using CustomerFeedback.Domain;
using CustomerFeedback.App.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CustomerFeedback.Tests.ServiceTests
{
    [TestClass]
    public class CustomerFeedbackServiceTests
    {  
        private readonly Data.Feedback _feedback;
        private readonly Mock<ICustomerFeedbackRepository> _customerFeedbackRepository;
        private readonly CustomerFeedbackService _customerFeedbackService;

        public CustomerFeedbackServiceTests()
        {
             _customerFeedbackRepository = new Mock<ICustomerFeedbackRepository>();
            _customerFeedbackService = new CustomerFeedbackService(_customerFeedbackRepository.Object);

            _feedback = new Data.Feedback
            {
                FirstName = "Alan",
                Lastname = "Smith",
                Comment = "This is not good"
            };
        }

        [TestMethod]
        public void Should_Call_Save_Method_In_Repository()
        {
            _customerFeedbackService.SaveFeedback(_feedback.FirstName, _feedback.Lastname, _feedback.Comment);
            _customerFeedbackRepository.Verify(x => x.Save(_feedback.FirstName, _feedback.Lastname, _feedback.Comment));
        }

       

    }
}
