using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacunaExpanse.PageModels.ViewCellModels
{
	public class MailViewCellModel
	{
		public string From { get; set; }
		public string Subject { get; set; }
		public string BodyPreview { get; set; }
		public string MessageID { get; set; }
	}
}
