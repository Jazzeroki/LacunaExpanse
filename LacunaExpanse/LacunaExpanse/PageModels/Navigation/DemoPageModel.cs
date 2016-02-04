using Fusillade;
using LacunaExpanse.Server;
using PropertyChanged;

namespace LacunaExpanse.PageModels.Navigation
{
	[ImplementPropertyChanged]
	public class DemoPageModel
	{
		public const string TekConfApiUrl = "http://us1.lacunaexpanse.com/";
		string requestString = "{\"id\":4,\"method\":\"login\",\"jsonrpc\":\"2.0\",\"params\":[\"sasha\",\"Moscow11\",\"53137d8f-3544-4118-9001-b0acbec70b3d\",\"2328404eaa7f576b2500f3a3efe0e495\"]}";

		public string ResultString { get; set; }

		public DemoPageModel()
		{
			var apiService = new ApiService(TekConfApiUrl);
			var service = new RefitApiService(apiService);
			Login(service);
		}
		async void Login(RefitApiService service)
		{
			var result = await service.EmpireAsync(Priority.Background, requestString);//.ConfigureAwait (false);
			if (result != null)
				ResultString = result.result.session_id;
			else
				ResultString = "An Error Occured";//resultLbl.Text = result.ToString() ;
		}
	}
}