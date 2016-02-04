using LacunaExpanse.PageModels.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace LacunaExpanse.Pages.Navigation
{
	public class MasterPageView : MasterDetailPage
	{
		MasterPageModel _viewModel;
		NavigationPage nav;
		public MasterPageView()
		{
			Title = "Lacuna Expanse";

			_viewModel = new MasterPageModel(this);
			BindingContext = _viewModel;

			nav = new NavigationPage(new LoginPageView());
			nav.Title = Constants.AppName;

			this.Detail = nav;
			this.Master = new MainNavigationMenuView();
			

			this.SetBinding(MasterDetailPage.IsPresentedProperty, "MenuVisible");
		}
	}
}
