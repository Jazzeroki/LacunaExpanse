using LacunaExpanse.ViewModels.NavigationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace LacunaExpanse.Views.NavigationViews
{
	public class MasterCorePageView : MasterDetailPage
	{
		NavigationPage nav;
		public MasterCorePageView()
		{
			nav = new NavigationPage(new SplashPageView());
			BindingContext = new MasterCorePageModel(this);
			this.Detail = nav;
			this.Master = new MainMenuPageView(nav);
		}
	}
}
