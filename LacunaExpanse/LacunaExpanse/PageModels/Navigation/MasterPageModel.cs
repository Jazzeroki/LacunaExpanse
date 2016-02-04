using Fusillade;
//using LacunaExpanse.MVVM;
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
	public class MasterPageModel : ViewModel
	{
		public MasterPageModel(Page page) : base(page)
		{

		}
		public bool MenuVisible { get; set; }
	}
}