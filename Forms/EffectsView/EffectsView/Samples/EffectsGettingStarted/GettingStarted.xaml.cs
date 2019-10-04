#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.XForms.Border;
using Syncfusion.XForms.EffectsView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfEffectsView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GettingStarted : SampleView
    {
		TapGestureRecognizer tapGesture;

		public GettingStarted()
        {
            InitializeComponent();
			Assembly assembly = typeof(GettingStarted).GetTypeInfo().Assembly;
#if COMMONSB
			cardImage.Source = ImageSource.FromResource("SampleBrowser.Images.Person.png", assembly);
			person1.Source = ImageSource.FromResource("SampleBrowser.Images.Person1.jpg", assembly);
			person2.Source = ImageSource.FromResource("SampleBrowser.Images.Person2.jpg", assembly);
			person3.Source = ImageSource.FromResource("SampleBrowser.Images.Person3.jpg", assembly);
			person4.Source = ImageSource.FromResource("SampleBrowser.Images.Person4.jpg", assembly);
			person5.Source = ImageSource.FromResource("SampleBrowser.Images.Person5.jpg", assembly);
			person6.Source = ImageSource.FromResource("SampleBrowser.Images.Person6.jpg", assembly);
			first.Source = ImageSource.FromResource("SampleBrowser.Images.Selection.png", assembly);
			second.Source = ImageSource.FromResource("SampleBrowser.Images.Selection.png", assembly);
			third.Source = ImageSource.FromResource("SampleBrowser.Images.Selection.png", assembly);
			fourth.Source = ImageSource.FromResource("SampleBrowser.Images.Selection.png", assembly);
			fifth.Source = ImageSource.FromResource("SampleBrowser.Images.Selection.png", assembly);
			sixth.Source = ImageSource.FromResource("SampleBrowser.Images.Selection.png", assembly);
#else
			cardImage.Source = ImageSource.FromResource("SampleBrowser.SfEffectsView.Images.Person.png", assembly);
			person1.Source = ImageSource.FromResource("SampleBrowser.SfEffectsView.Images.Person1.jpg", assembly);
			person2.Source = ImageSource.FromResource("SampleBrowser.SfEffectsView.Images.Person2.jpg", assembly);
			person3.Source = ImageSource.FromResource("SampleBrowser.SfEffectsView.Images.Person3.jpg", assembly);
			person4.Source = ImageSource.FromResource("SampleBrowser.SfEffectsView.Images.Person4.jpg", assembly);
			person5.Source = ImageSource.FromResource("SampleBrowser.SfEffectsView.Images.Person5.jpg", assembly);
			person6.Source = ImageSource.FromResource("SampleBrowser.SfEffectsView.Images.Person6.jpg", assembly);
			first.Source = ImageSource.FromResource("SampleBrowser.SfEffectsView.Images.Selection.png", assembly);
			second.Source = ImageSource.FromResource("SampleBrowser.SfEffectsView.Images.Selection.png", assembly);
			third.Source = ImageSource.FromResource("SampleBrowser.SfEffectsView.Images.Selection.png", assembly);
			fourth.Source = ImageSource.FromResource("SampleBrowser.SfEffectsView.Images.Selection.png", assembly);
			fifth.Source = ImageSource.FromResource("SampleBrowser.SfEffectsView.Images.Selection.png", assembly);
			sixth.Source = ImageSource.FromResource("SampleBrowser.SfEffectsView.Images.Selection.png", assembly);
#endif
		}

        private void ApplyRotationEffectButton_Clicked(object sender, EventArgs e)
        {         
            if(this.RotationEffectsView.Angle == 0)
            {
                this.RotationEffectsView.Angle = 0;
                this.RotationEffectsView.ApplyEffects(effects: SfEffects.Rotation);
				this.ApplyRotationEffectButton.Text = "Rotate to 180°";

			}
			else
            {
                this.RotationEffectsView.Angle = 180;
                this.RotationEffectsView.ApplyEffects(effects: SfEffects.Rotation);
				this.ApplyRotationEffectButton.Text = "Rotate to 0°";
			}
		}

        private void RotationEffectsView_AnimationCompleted(object sender, EventArgs e)
        {
            if (this.RotationEffectsView.Angle == 180)
            {
                this.RotationEffectsView.Angle = 0;
                this.ApplyRotationEffectButton.Text = "Rotate to 0°";
            }
            else
            {
                this.RotationEffectsView.Angle = 180;
                this.ApplyRotationEffectButton.Text = "Rotate to 180°";
            }
        }

		private void FirstView_SelectionChanged(object sender, EventArgs e)
		{
			Syncfusion.XForms.EffectsView.SfEffectsView effects = sender as Syncfusion.XForms.EffectsView.SfEffectsView;
			var childGesture = ((effects?.Content) as Image)?.GestureRecognizers;

			if (effects.IsSelected && effects.LongPressEffects.HasFlag(SfEffects.Scale | SfEffects.Selection))
			{
				view.LongPressEffectsValue = SfEffects.None;
				view.TouchDownEffectsValue = SfEffects.Scale | SfEffects.Selection;
			}

			if (childGesture.Count == 0 && effects.IsSelected)
			{
				tapGesture = new TapGestureRecognizer();
				tapGesture.Tapped += TapGestureRecognizer_Tapped;
				tapGesture.CommandParameter = effects;
				childGesture.Add(tapGesture);
			}

			if (childGesture.Count > 0 && !effects.IsSelected)
			{
				var child = childGesture;
				(child[0] as TapGestureRecognizer).Tapped -= TapGestureRecognizer_Tapped;
				childGesture.RemoveAt(0);
				effects.ScaleFactor = 0.85;
			}

			if (!firstView.IsSelected && !secondView.IsSelected
				&& !thirdView.IsSelected && !fourthView.IsSelected
				&& !fifthView.IsSelected && !sixthView.IsSelected)
			{
				view.ScaleFactorValue = 0.85;
				view.TouchDownEffectsValue = SfEffects.None;
				view.LongPressEffectsValue = SfEffects.Scale | SfEffects.Selection;
			}
		}

		private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			var eventArgs = (TappedEventArgs)e;
			var effects = (eventArgs.Parameter) as Syncfusion.XForms.EffectsView.SfEffectsView;
			effects.ScaleFactor = 1;
			effects.IsSelected = false;
			effects.ApplyEffects(SfEffects.Scale);
		}

		private void AnimationDurationSlider2_ValueChanged(object sender, ValueChangedEventArgs e)
		{
			view.ScaleDuration = e.NewValue;
		}

		private void AnimationDurationSlider3_ValueChanged(object sender, ValueChangedEventArgs e)
		{
			RotationEffectsView.RippleAnimationDuration = e.NewValue;
			RotationEffectsView.RotationAnimationDuration = e.NewValue;
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
		Assembly assembly;

		public EffectsViewModel()
		{
			assembly = typeof(EffectsViewModel).GetTypeInfo().Assembly;
		}

		private ImageSource selectionImage;

		public ImageSource SelectionImage
		{
			get
			{
				return selectionImage;
			}
			set
			{
				selectionImage = value;
#if COMMONSB
				selectionImage= ImageSource.FromResource("SampleBrowser.Images.Selection.png", assembly);
#else
				selectionImage= ImageSource.FromResource("SampleBrowser.SfEffectsView.Images.Selection.png", assembly);
#endif
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectionImage"));
			}
		}

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

		private SfEffects touchDownEffectsValue = SfEffects.None;
		public SfEffects TouchDownEffectsValue
		{
			get
			{
				return touchDownEffectsValue;
			}
			set
			{
				touchDownEffectsValue = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TouchDownEffectsValue"));
			}
		}

		private SfEffects longPressEffectsValue = SfEffects.Scale | SfEffects.Selection;
		public SfEffects LongPressEffectsValue
		{
			get
			{
				return longPressEffectsValue;
			}
			set
			{
				longPressEffectsValue = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LongPressEffectsValue"));
			}
		}
	}
}