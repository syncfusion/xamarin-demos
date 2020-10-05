#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.XForms.EffectsView;
using System;
using System.ComponentModel;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfEffectsView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GettingStarted : SampleView
	{
		public GettingStarted()
		{
			InitializeComponent();
		}

		private void ApplyRotationEffectButtonClicked(object sender, EventArgs e)
		{
			if (RotationEffectsView.Angle == 0)
			{
				RotationEffectsView.Angle = 0;
				RotationEffectsView.ApplyEffects(effects: SfEffects.Rotation);
				ApplyRotationEffectButton.Text = "Rotate to 180°";

			}
			else
			{
				RotationEffectsView.Angle = 180;
				RotationEffectsView.ApplyEffects(effects: SfEffects.Rotation);
				ApplyRotationEffectButton.Text = "Rotate to 0°";
			}
		}

		private void RotationEffectsViewAnimationCompleted(object sender, EventArgs e)
		{
			if (RotationEffectsView.Angle == 180)
			{
				RotationEffectsView.Angle = 0;
				ApplyRotationEffectButton.Text = "Rotate to 0°";
			}
			else
			{
				RotationEffectsView.Angle = 180;
				ApplyRotationEffectButton.Text = "Rotate to 180°";
			}
		}

		private void AnimationCompleted(object sender, EventArgs e)
		{
			Syncfusion.XForms.EffectsView.SfEffectsView effectsView = sender as Syncfusion.XForms.EffectsView.SfEffectsView;
			if (effectsView.ScaleFactor == 0.85)
			{
				effectsView.ScaleFactor = 1;
			}
			else
			{
				effectsView.ScaleFactor = 0.85;
			}
		}
	}

	public class CustomBorder : Syncfusion.XForms.Border.SfBorder
	{
		private bool isPotrait = true;
		double width;
		protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
		{

			if (isPotrait && widthConstraint != double.PositiveInfinity)
			{
				width = widthConstraint;
				isPotrait = false;
			}

			return base.OnMeasure(width, heightConstraint);
		}
	}

	public class EffectsViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private double scaleFactorValue = 0.85;

		public double ScaleFactorValue
		{
			get
			{
				return scaleFactorValue;
			}
			set
			{
				if (scaleFactorValue != value)
				{
					scaleFactorValue = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ScaleFactorValue"));
				}
			}
		}

		private double scaleDuration = 150;

		public double ScaleDuration
		{
			get
			{
				return scaleDuration;
			}
			set
			{
				if (scaleDuration != value)
				{
					scaleDuration = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ScaleDuration"));
				}
			}
		}

		private SfEffects touchUpEffectsValue = SfEffects.Scale;
		public SfEffects TouchUpEffectsValue
		{
			get
			{
				return touchUpEffectsValue;
			}
			set
			{
				touchUpEffectsValue = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TouchUpEffectsValue"));
			}
		}
	}

	public class VisibilityConvertor : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			Syncfusion.XForms.EffectsView.SfEffectsView effectsView = parameter as Syncfusion.XForms.EffectsView.SfEffectsView;
			return effectsView.ScaleFactor == 1;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value;
		}
	}
}