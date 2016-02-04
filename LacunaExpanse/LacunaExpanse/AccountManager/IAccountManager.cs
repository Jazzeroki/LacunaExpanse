using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanse.AccountManager
{
	public interface IAccountManager
	{
		Task<AccountModel> LoadAccount();
		void SaveAccount(AccountModel account);
	}
}
