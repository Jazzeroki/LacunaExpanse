using LacunaExpanse.ViewModels.NavigationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LacunaExpanse.Views.NavigationViews
{
	public class SplashPageView : ContentPage
	{
		public SplashPageView()
		{
			Content = CreateLayout();
			SetBindings();
			BindingContext = new SplashPageModel(this);
		}

		private void SetBindings()
		{
			throw new NotImplementedException();
		}

		private View CreateLayout()
		{
			throw new NotImplementedException();
		}
	}
}
