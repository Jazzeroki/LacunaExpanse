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
		Label mail = new Label { Text = "Mail" };
		Label logout = new Label { Text = "Logout" };
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
		}

		private View CreateLayout()
		{
			var mainLayout = new StackLayout
			{
				Children =
				{
					mail, logout
				}
			};
			return mainLayout;
		}
	}
}
