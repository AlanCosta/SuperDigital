using SuperDigital.IO.Domain.Core.Bus;
using SuperDigital.IO.Domain.Core.Events;
using SuperDigital.IO.Domain.Core.Notifications;
using SuperDigital.IO.Domain.Interfaces;
using SuperDigital.IO.Infra.CrossCutting.Bus;
using SuperDigital.IO.Infra.Data.Context;
using SuperDigital.IO.Infra.Data.Repository;
using SuperDigital.IO.Infra.Data.Uow;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SuperDigital.IO.Application.Interfaces;
using SuperDigital.IO.Application.Services;
using Microsoft.Extensions.Configuration;
using RestSharp;
using SuperDigital.IO.Domain.ContaCorrente.Commands;
using SuperDigital.IO.Domain.ContaCorrente.Events;
using SuperDigital.IO.Domain.ContaCorrente.Repository;

namespace SuperDigital.IO.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            
            //ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //Application
            services.AddScoped<IContaCorrenteAppService, ContaCorrenteAppService>();
            //Domain - commands
            services.AddScoped<IHandler<RegistrarContaCorrenteCommand>, ContaCorrenteCommandHandler>();
            services.AddScoped<IHandler<AtualizarContaCorrenteCommand>, ContaCorrenteCommandHandler>();
            services.AddScoped<IHandler<AtualizarValorContaCommand>, ContaCorrenteCommandHandler>();
            //Domain - Events
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<ContaCorrenteRegistradoEvent>, ContaCorrenteEventHandler>();
            services.AddScoped<IHandler<ContaCorrenteAtualizadoEvent>, ContaCorrenteEventHandler>();
            services.AddScoped<IHandler<ContaCorrenteValorAtualizadoEvent>, ContaCorrenteEventHandler>();
            //Infra - Data
            services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ContaCorrenteContext>();

            //INfra - bus
            services.AddScoped<IBus, InMemoryBus>();


        }
    }
}
