using LacunaExpanse.PageModels.Mail;
using LacunaExpanse.Pages.ViewCells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace LacunaExpanse.Pages.Mail
{
	public class MailMainView : ContentPage
	{
		ListView messages = new ListView
		{
			VerticalOptions = LayoutOptions.FillAndExpand,
			ItemTemplate = new DataTemplate(typeof(MailViewCell)),
			HasUnevenRows = true,
		};


		public MailMainView()
		{
			SetBindings();
			BindingContext = new MailMainModel(this);
			Content = new StackLayout
			{
				Children = {
					messages
				}
			};
		}

		private void SetBindings()
		{
			messages.SetBinding(ListView.ItemsSourceProperty, "Messages");
			messages.SetBinding(ListView.SelectedItemProperty, "SelectedItem", BindingMode.TwoWay);
		}
	}
}
