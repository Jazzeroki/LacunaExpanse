using ExtendedEntryControl.Forms.Plugin.Abstractions;
using LacunaExpanse.PageModels.Navigation;
using Xamarin.Forms;

namespace LacunaExpanse.Pages.Navigation
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
			//BindingContext = new LoginPageModel(this);
		}

		private void SetBindings()
		{
			empireName.SetBinding(ExtendedEntry.TextProperty, "Empire");
			password.SetBinding(ExtendedEntry.TextProperty, "Password");
			server.SetBinding(ExtendedEntry.TextProperty, "Server");

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
		ExtendedEntry empireName = new ExtendedEntry { Placeholder = "Empire Name"};
		ExtendedEntry password = new ExtendedEntry { Placeholder = "Password" };
		ExtendedEntry server = new ExtendedEntry { Placeholder = "Server"};

		Button us1Server = new Button { Text = "US1" };
		Button ptServer = new Button { Text = "PT" };
		Button login = new Button { Text = "Login" };
	}
}
