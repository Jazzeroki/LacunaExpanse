using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akavache;
using System.Reactive.Linq;

namespace LacunaExpanse.AccountManager
{
	public class AccountManager : IAccountManager
	{
		private string accountKey = "account";
		public async Task<AccountModel> LoadAccount()
		{
			try
			{
				var account = BlobCache.Secure.GetObject<AccountModel>(accountKey);
				var s = await account.FirstOrDefaultAsync();
				return s;
			}
			catch
			{
				return new AccountModel();
			}
		}

		public async void SaveAccount(AccountModel model)
		{
			await BlobCache.Secure.InsertObject(accountKey, model, new DateTimeOffset(DateTime.Now.AddYears(3)));
		}
	}
}
