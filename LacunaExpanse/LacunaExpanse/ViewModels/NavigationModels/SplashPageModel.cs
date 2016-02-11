using LacunaExpanse.MVVM;
using LacunaExpanse.Views.NavigationViews;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LacunaExpanse.ViewModels.NavigationModels
{
	[ImplementPropertyChanged]
	public class SplashPageModel : ViewModel
	{
		public SplashPageModel(ContentPage page): base(page)
		{
			AppStart();
		}
		private async void AppStart()
		{
			await Navigation.PushAsync(new LoginPageView());
		}
	}
}
