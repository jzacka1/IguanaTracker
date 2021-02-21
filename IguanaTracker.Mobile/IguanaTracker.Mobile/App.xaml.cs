using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using IguanaTracker.Mobile.Services;
using IguanaTracker.Mobile.Views;
using Autofac;
using IguanaTracker.Mobile.ViewModels;
using RestfulApiService.Services.IguanaApiService;

namespace IguanaTracker.Mobile
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			//DependencyService.Register<MockDataStore>();

			//Services
			//DependencyService.Register<IErrorLogger, ErrorLogger>();
			//DependencyService.Register<IDeserializer, JsonSerializer>();
			////DependencyService.Register<ICacheService, InMemoryCache>();

			//DependencyService.Register<ICacheService, InMemoryCache>();
			//DependencyService.Register<IIguanaTrackerApiService, IguanaTrackerApiService>();

			//_builder.RegisterInstance<IErrorLogger>(new ErrorLogger()).SingleInstance();
			//_builder.RegisterInstance<IDeserializer>(new JsonSerializer()).SingleInstance();
			//_builder.RegisterInstance<ICacheService>(new InMemoryCache()).SingleInstance();
			//_builder.RegisterInstance<IIguanaTrackerApiService>(new IguanaTrackerApiService()).SingleInstance();


			MainPage = new AppShell();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
