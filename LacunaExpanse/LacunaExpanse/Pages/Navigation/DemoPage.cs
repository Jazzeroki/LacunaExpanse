using LacunaExpanse.PageModels.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace LacunaExpanse.Pages.Navigation
{
	
	public class DemoPage : ContentPage
	{
		private readonly DemoPageModel _viewModel;
		Label myLabel = new Label { Text = "Hello ContentPage" };
		public DemoPage()
		{
			_viewModel = new DemoPageModel();
			BindingContext = _viewModel;
			myLabel.SetBinding(Label.TextProperty, "ResultString");
			Content = new StackLayout
			{
				Children = {
					myLabel
				}
			};
		}
	}
}
