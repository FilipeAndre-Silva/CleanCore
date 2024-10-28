using System.Collections.Generic;
using FluentValidation.Results;

namespace Notifications.Core
{
    public interface INotificationHandler
    {
        void AddNotification(string message);
        void AddNotification(string message, ValidationResult validationResult);
        bool HasNotifications();
        IReadOnlyCollection<Notification> GetNotifications();
    }
}
