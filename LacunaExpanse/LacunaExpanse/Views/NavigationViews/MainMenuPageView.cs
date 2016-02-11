using LacunaExpanse.ViewModels.NavigationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace LacunaExpanse.Views.NavigationViews
{
	public class MainMenuPageView : ContentPage
	{
		public MainMenuPageView(NavigationPage navPage)
		{
			Title = Constants.APPNAME;
			NavigationPage.SetHasNavigationBar(this, false);
			Content = CreateLayout();
			BindingContext = new MainMenuPageModel(this, navPage);
			SetBindings();
		}

		private void SetBindings()
		{
			throw new NotImplementedException();
		}

		private View CreateLayout()
		{
			throw new NotImplementedException();
		}
	}
}
