using CustomerFeedback.App.Models;
using CustomerFeedback.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CustomerFeedback.Tests.RepositoryTests
{
    [TestClass]
    public class RepositoryTests
    {
        private readonly Data.Feedback _feedback;
        private readonly CustomerFeedbackRepository _customerFeedbackRepository;

        public RepositoryTests()
        {
            _customerFeedbackRepository = new CustomerFeedbackRepository();

            _feedback = new Data.Feedback
            {
                FirstName = "Alan",
                Lastname = "Smith",
                Comment = "This is not good"
            };
        }

        [TestMethod]
        public void Saving_Feedback_Should_Return_GUID_Of_New_Feedback_Record()
        {
            var response = _customerFeedbackRepository.Save(_feedback.FirstName, _feedback.Lastname, _feedback.Comment);
            Assert.AreEqual(response.GetType(), typeof(Guid));
        }
    }
}
