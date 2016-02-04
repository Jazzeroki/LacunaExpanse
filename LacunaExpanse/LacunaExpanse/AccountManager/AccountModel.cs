using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanse.AccountManager
{
	public class AccountModel
	{
		public string EmpireName { get; set; }
		public string Password { get; set; }
		public string SessionID { get; set; }
		public string Server { get; set; }
		public DateTime CaptchaLastRenewed { get; set; }
		public DateTime SessionLastRenewed { get; set; }
	}
}
