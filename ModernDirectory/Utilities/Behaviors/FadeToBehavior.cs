using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace ModernDirectory.Utilities.Behaviors
{
	public class FadeToBehavior : Behavior<ActivityIndicator>
	{
		protected override void OnAttachedTo(ActivityIndicator bindable)
		{
			bindable.PropertyChanging += Bindable_PropertyChanging;
		}

		protected override void OnDetachingFrom(ActivityIndicator bindable)
		{
			bindable.PropertyChanging -= Bindable_PropertyChanging;
		}

		public static readonly BindableProperty FromProperty = BindableProperty.Create("From", typeof(double), typeof(FadeToBehavior), 0.0);

		public double From
		{
			get { return (double)GetValue(FromProperty); }
			set { SetValue(FromProperty, value); }
		}

		public static readonly BindableProperty ToProperty = BindableProperty.Create("To", typeof(double), typeof(FadeToBehavior), 1.0);

		public double To
		{
			get { return (double)GetValue(ToProperty); }
			set { SetValue(ToProperty, value); }
		}

		async void Bindable_PropertyChanging (object sender, PropertyChangingEventArgs e)
		{
			if(e.PropertyName.Equals (ActivityIndicator.IsRunningProperty.PropertyName))
			{
				var activityIndicator = sender as ActivityIndicator;

				if(activityIndicator != null)
				{
					if(!activityIndicator.IsRunning)
					{
						Debug.WriteLine ("Fading loading indicator in");
						await activityIndicator.FadeTo (To);
					}
					else{
						Debug.WriteLine ("Fading loading indicator out");
						await activityIndicator.FadeTo (From);
					}
				}
			}
		}
	}
}

