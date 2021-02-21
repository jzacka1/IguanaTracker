using Autofac;
using IguanaTracker.Data.Data;
using IguanaTracker.Mobile.ViewModels;
using RestfulApiService.Services.IguanaApiService;
using System;
using System.Collections.Generic;
using System.Text;

namespace IguanaTracker.Mobile.Services
{
	public class AppContainer
	{
		private static IContainer container;

		public AppContainer(){
			
		}

		public static void Initialize(){
			ContainerBuilder _builder = new ContainerBuilder();

			//Register the services
			_builder.RegisterType<IguanaApiService>()
				.As<IIguanaApiService>().SingleInstance();

			//Register the models
			_builder.RegisterType<SightingsViewModel>().SingleInstance();

			container = _builder.Build();
		}

		public static T Resolve<T>() => container.Resolve<T>();

		public static object Resolve(Type type) => container.Resolve(type);
	}
}
