using System;

namespace CustomerFeedback.Data
{
    public interface ICustomerFeedbackRepository
    {
        object Save(string firstname, string lastname, string comment);
    }
}