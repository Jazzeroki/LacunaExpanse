using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace LacunaExpanse.Pages.Navigation
{
	public class MainNavigationMenuView : ContentPage
	{
		public MainNavigationMenuView()
		{
			Title = "Lacuna Expanse";
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}
