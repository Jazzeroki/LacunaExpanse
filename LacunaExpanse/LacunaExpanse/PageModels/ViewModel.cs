using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LacunaExpanse.PageModels
{
	
	public class ViewModel
	{
		protected INavigation Navigation;

		public ViewModel(Page page)
		{
			Navigation = page.Navigation;
		}
	}
}