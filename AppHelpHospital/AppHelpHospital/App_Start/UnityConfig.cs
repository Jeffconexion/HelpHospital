using AppHelpHospital.Controllers;
using HelpHospital.Data.Context;
using HelpHospital.Service;
using HelpHospital.Service.Contracts;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace AppHelpHospital
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());

            container.RegisterType<HelpHospitalDb, HelpHospitalDb>();
            container.RegisterType<IEmailService, EmailCuidadorService>();
            container.RegisterType<IPacienteService, PacienteService>();
            container.RegisterType<IImprimirService,ImprimirService>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}