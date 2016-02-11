using LacunaExpanse.GameServices;
using LacunaExpanse.MVVM;
using LacunaExpanseAPIWrapper;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LacunaExpanse.ViewModels.NavigationModels
{
	[ImplementPropertyChanged]
	class LoginPageModel : ViewModel
	{
		public LoginPageModel(ContentPage page) : base(page)
		{

		}

		public string Server { get; set; }
		public string Password { get; set; }
		public string EmpireName { get; set; }
		public ICommand LoginCommand
		{
			get
			{
				return new Command(async () =>
				{
					if (!String.IsNullOrEmpty(Server) && !String.IsNullOrEmpty(EmpireName) && !String.IsNullOrEmpty(Password))
					{
						var request = Empire.Login(1, EmpireName, Password);
						var server = new Server();
						var response = await server.GetHttpResultAsync(Server, Empire.url, request);
						var s = response;
						//var apiService = new ApiService(Server);
						//var service = new RefitApiService(apiService);
						//Login(service, request);
					}
				});
			}
		}
		public ICommand PTCommand
		{
			get
			{
				return new Command(() =>
				{
					Server = Constants.PTSSERVER;
				});
			}
		}
		public ICommand US1Command
		{
			get
			{
				return new Command(() =>
				{
					Server = Constants.US1SERVER;
				});
			}
		}
	}
}
