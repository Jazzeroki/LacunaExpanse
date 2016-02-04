using Fusillade;
//using LacunaExpanse.MVVM;
using LacunaExpanse.Pages.Mail;
using LacunaExpanse.Server;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LacunaExpanse.PageModels.Navigation
{
	[ImplementPropertyChanged]
	public class LoginPageModel : ViewModel
	{
		public LoginPageModel(Page page) : base(page)
		{
			
		}
		//private string _empireName;
		//public string EmpireName
		//{
		//	get { return _empireName; }
		//	set { SetProperty(ref _empireName, value); }
		//}
		//private string _password;
		//public string Password
		//{
		//	get { return _password; }
		//	set { SetProperty(ref _password, value); }
		//}
		//private string _server;
		//public string Server
		//{
		//	get { return _server; }
		//	set { SetProperty(ref _server, value); }
		//}
		public string Server { get; set; }
		public string Password { get; set; }
		public string EmpireName { get; set; }
		public ICommand LoginCommand
		{
			get
			{
				return new Command(() =>
				{
					if(!String.IsNullOrEmpty(Server) && !String.IsNullOrEmpty(EmpireName) && !String.IsNullOrEmpty(Password))
					{
						var request = LacunaExpanseAPIWrapper.Empire.Login(1, EmpireName, Password);
						var apiService = new ApiService(Server);
						var service = new RefitApiService(apiService);
						Login(service, request);
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
					Server = Constants.PTServer;
				});
			}
		}
		public ICommand US1Command
		{
			get
			{
				return new Command(() =>
				{
					Server = Constants.US1Server;
				});
			}
		}

		async void Login(RefitApiService service, string requestString)
		{
			var result = await service.EmpireAsync(Priority.Background, requestString);//.ConfigureAwait (false);
			if(result != null)
			{
				if (!String.IsNullOrEmpty(result.result.session_id))
				{
					await Navigation.PushAsync(new MailMainView());
				}
			}
			else
			{

			}
			//if (result != null)
			//	ResultString = result.result.session_id;
			//else
			//	ResultString = "An Error Occured";//resultLbl.Text = result.ToString() ;
		}
		//public LoginPageModel(ContentPage page): base(page)
		//{

		//}
	}
}
