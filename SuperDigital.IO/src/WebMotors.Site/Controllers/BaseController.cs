using SuperDigital.IO.Domain.Core.Notifications;
using SuperDigital.IO.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDigital.Site.Controllers
{
    public class BaseController : Controller
    {
        private readonly IDomainNotificationHandler<DomainNotification> notifications;
        private readonly IUser user;
        public BaseController(IDomainNotificationHandler<DomainNotification> _notifications)
        {
            _notifications = notifications;

        }

        protected bool OperacaoValida()
        {
            return (!notifications.HasNotifications());
        }
    }
}
