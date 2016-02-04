//using LacunaExpanse.MVVM;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LacunaExpanse.PageModels.Navigation
{
	[ImplementPropertyChanged]
	public class SplashPageModel : ViewModel
	{
		public SplashPageModel(Page page) : base(page)
		{

		}
		//string _pinText = "4562";

		//public string PinText
		//{
		//	get { return _pinText; }
		//	set
		//	{
		//		SetProperty(ref _pinText, value);
		//		NotifyPropertyChanged(() => PinTooShortVisible);
		//		InformationModel.LoginStatus.PIN = _pinText;
		//	}
		//}
		//private bool _activityVisible;
		//public bool ActivityVisible
		//{
		//	get { return _activityVisible; }
		//	set { SetProperty(ref _activityVisible, value); }
		//}
		//public SplashPageModel(ContentPage page): base(page)
		//{
			
		//}
	}
}
