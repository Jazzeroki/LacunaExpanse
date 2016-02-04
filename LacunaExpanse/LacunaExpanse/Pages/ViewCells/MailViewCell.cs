using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LacunaExpanse.Pages.ViewCells
{
	public class MailViewCell : ViewCell
	{
		StackLayout VerticalInner = new StackLayout { Orientation = StackOrientation.Vertical };

		Label GoogleLetter = new Label { TextColor = Color.White };
		Label From = new Label { TextColor = Color.White };
		Label MessageHeader = new Label { TextColor = Color.White };
		Label BodySummary = new Label { TextColor = Color.White };

		public MailViewCell()
		{
			//BindingContext
			From.SetBinding(Label.TextProperty, "From");
			MessageHeader.SetBinding(Label.TextProperty, "Subject");
			VerticalInner.Children.Add(From);
			VerticalInner.Children.Add(MessageHeader);
			View = VerticalInner;
		}
	}
}
