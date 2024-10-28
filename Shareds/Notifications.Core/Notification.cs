
using FluentValidation.Results;

namespace Notifications.Core
{
    public class Notification
    {
        public string Message { get; }
        public ValidationResult ValidationResult { get; }

        public Notification(string message)
        {
            Message = message;
        }

        public Notification(string message, ValidationResult validationResult)
        {
            ValidationResult = validationResult;
            Message = message;
        }
    }
}