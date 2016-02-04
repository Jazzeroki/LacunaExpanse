using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using LacunaExpanse.PageModels.Navigation;
using Xamarin.Forms;

namespace LacunaExpanse.Pages.Navigation
{
	public class SplashPageView : ContentPage
	{
		public SplashPageView()
		{
			Content = InitializeControls();

			SetBindings(); 
			BindingContext = new  SplashPageModel(this);
		}

		private void SetBindings()
		{
			throw new NotImplementedException();
		}

		private View InitializeControls()
		{
			throw new NotImplementedException();
		}
	}
}
