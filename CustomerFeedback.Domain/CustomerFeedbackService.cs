using CustomerFeedback.Data;

namespace CustomerFeedback.Domain
{
    public class CustomerFeedbackService : ICustomerFeedbackService
    {
        private readonly ICustomerFeedbackRepository _customerFeedbackRepository;

        public CustomerFeedbackService(ICustomerFeedbackRepository customerFeedbackRepository)
        {
            _customerFeedbackRepository = customerFeedbackRepository;
        }

        public void SaveFeedback(string firstname, string lastname, string comment)
        {
            _customerFeedbackRepository.Save(firstname, lastname, comment);
        }
    }
}