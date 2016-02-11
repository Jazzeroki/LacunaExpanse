using LacunaExpanse.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LacunaExpanse.ViewModels.NavigationModels
{

	class MainMenuPageModel : ViewModel
	{
		private NavigationPage nav;
		public MainMenuPageModel(ContentPage page, NavigationPage navPage) : base(page)
		{
			nav = navPage;
		}
	}
}
