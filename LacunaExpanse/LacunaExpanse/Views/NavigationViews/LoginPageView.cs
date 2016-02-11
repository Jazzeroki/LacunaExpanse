using LacunaExpanse.ViewModels.NavigationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Xamarin.Forms;

namespace LacunaExpanse.Views.NavigationViews
{
	public class LoginPageView : ContentPage
	{
		private readonly LoginPageModel _viewModel;
		public LoginPageView()
		{
			Content = CreateLayout();

			SetBindings();
			_viewModel = new LoginPageModel(this);
			BindingContext = _viewModel;
		}

		private void SetBindings()
		{
			empireName.SetBinding(Entry.TextProperty, "EmpireName");
			password.SetBinding(Entry.TextProperty, "Password");
			server.SetBinding(Entry.TextProperty, "Server");

			login.SetBinding(Button.CommandProperty, "LoginCommand");
			ptServer.SetBinding(Button.CommandProperty, "PTCommand");
			us1Server.SetBinding(Button.CommandProperty, "US1Command");
		}

		private View CreateLayout()
		{
			var mainLayout = new StackLayout
			{
				Children =
				{
					mainImage, empireName, password, us1Server, ptServer, server, login
				}
			};
			return mainLayout;
		}


		Image mainImage = new Image { };
		Entry empireName = new Entry { Placeholder = "Empire Name" };
		Entry password = new Entry { Placeholder = "Password" };
		Entry server = new Entry { Placeholder = "Server" };

		Button us1Server = new Button { Text = "US1" };
		Button ptServer = new Button { Text = "PT" };
		Button login = new Button { Text = "Login" };
	}
}
