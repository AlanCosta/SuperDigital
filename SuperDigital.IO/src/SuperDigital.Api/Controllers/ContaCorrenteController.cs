using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperDigital.IO.Application.Interfaces;
using SuperDigital.IO.Application.ViewModels;
using SuperDigital.IO.Domain.Core.Notifications;

namespace SuperDigital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly IContaCorrenteAppService context;
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;
        public ContaCorrenteController(IContaCorrenteAppService _context,
            IDomainNotificationHandler<DomainNotification> notifications) : base()
        {
            context = _context;
            _notifications = notifications;
        }

        [HttpPost]
        [Route("Lancamentos")]
        public ActionResult Post(LancamentosViewModel collection)
        {
            if (!ModelState.IsValid) return NotFound(collection);
            context.Lancamentos(collection);

            if (!_notifications.HasNotifications())
                return Ok(collection);
            else
                return NotFound(_notifications);
        }

        [HttpPost]
        [Route("InserirConta")]
        public ActionResult Post(ContaCorrenteViewModel collection)
        {
            if (!ModelState.IsValid) return NotFound(collection);
            context.Registrar(collection);

            if (!_notifications.HasNotifications())
                return Ok(collection);
            else
                return NotFound(_notifications);
        }
    }
}