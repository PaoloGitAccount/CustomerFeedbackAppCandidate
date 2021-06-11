namespace CustomerFeedback.Domain
{
    public interface ICustomerFeedbackService
    {
        void SaveFeedback(string firstname, string lastname, string comment);
    }
}