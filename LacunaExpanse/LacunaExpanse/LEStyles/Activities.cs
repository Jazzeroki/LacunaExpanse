using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LacunaExpanse.LEStyles
{
	public static class Activities
	{
		public enum ActivityStyleNames
		{
			RunningActivity
		}
		public static ResourceDictionary ActivityStyles = new ResourceDictionary
		{
			#region RunningActivity
			{
				ActivityStyleNames.RunningActivity.ToString(), new Style(typeof(BoxView))
				{
					Setters =
					{
						new Setter
						{
							Property = ActivityIndicator.IsRunningProperty,
							Value = true
						},
						
					}
				}
			},
			#endregion			
		};
	}
}
