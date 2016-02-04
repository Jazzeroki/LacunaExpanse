using Fusillade;
using LacunaExpanse.PageModels.ViewCellModels;
using LacunaExpanse.Server;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LacunaExpanse.PageModels.Mail
{
	[ImplementPropertyChanged]
	public class MailMainModel : ViewModel
	{
		ObservableCollection<MailViewCellModel> Messages { get; set; }
		public MailMainModel(Page page) : base(page)
		{
			Messages = new ObservableCollection<MailViewCellModel>();
			var accountMan = new AccountManager.AccountManager();
			var account = accountMan.LoadAccount().Result;

			var json = LacunaExpanseAPIWrapper.Inbox.ViewInbox(account.SessionID);
			var apiService = new ApiService(account.Server);
			var service = new RefitApiService(apiService);
			var result = service.InboxAsync(Priority.Background, json).Result;//.ConfigureAwait (false);
			if (result != null)
			{
				foreach(var m in result.result.messages)
				{
					var model = new MailViewCellModel
					{
						BodyPreview = m.body_preview,
						From = m.from,
						MessageID = m.id,
						Subject = m.subject
					};
					Messages.Add(model);
				}
			}
			else
			{
			}
		}
	}
}
