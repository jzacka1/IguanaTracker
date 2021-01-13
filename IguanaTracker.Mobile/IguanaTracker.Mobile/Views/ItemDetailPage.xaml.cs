using System.ComponentModel;
using Xamarin.Forms;
using IguanaTracker.Mobile.ViewModels;

namespace IguanaTracker.Mobile.Views
{
	public partial class ItemDetailPage : ContentPage
	{
		public ItemDetailPage()
		{
			InitializeComponent();
			BindingContext = new ItemDetailViewModel();
		}
	}
}