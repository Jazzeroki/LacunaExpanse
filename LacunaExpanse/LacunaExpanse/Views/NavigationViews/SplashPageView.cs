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
		BoxView topspacer = new BoxView { Color = Color.Transparent, VerticalOptions = LayoutOptions.StartAndExpand };
		ActivityIndicator activity = new ActivityIndicator
		{
			IsRunning = true,
			IsVisible = true,
			IsEnabled = true,
		};
		Label notificationLabel = new Label
		{
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Center,
			TextColor = Color.White,
			BackgroundColor = Color.Transparent,
		};
		BoxView bottomspacer = new BoxView { Color = Color.Transparent, VerticalOptions = LayoutOptions.EndAndExpand };
		public SplashPageView()
		{
			Content = CreateLayout();
			SetBindings();
			BindingContext = new SplashPageModel(this);
		}

		private void SetBindings()
		{
			
		}

		private View CreateLayout()
		{
			var mainLayout = new StackLayout
			{
				BackgroundColor = Color.Gray,
				Children =
				{
					topspacer, notificationLabel, activity, bottomspacer
				}
			};
			return mainLayout;
		}
	}
}
