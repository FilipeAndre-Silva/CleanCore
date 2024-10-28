using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace Notifications.Core
{
    public class NotificationHandler : INotificationHandler
    {
        private readonly List<Notification> _notifications;

        public NotificationHandler()
        {
            _notifications = new List<Notification>();
        }

        public void AddNotification(string message)
        {
            _notifications.Add(new Notification(message));
        }

        public void AddNotification(string message, ValidationResult validationResult)
        {
            _notifications.Add(new Notification(message, validationResult));
        }

        public bool HasNotifications()
        {
            return _notifications.Any();
        }

        public IReadOnlyCollection<Notification> GetNotifications()
        {
            return _notifications.AsReadOnly();
        }
    }
}