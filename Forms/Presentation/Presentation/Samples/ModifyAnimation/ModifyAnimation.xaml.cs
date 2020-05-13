#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COLOR = Syncfusion.Drawing;
using Xamarin.Forms;
using System.IO;
using System.Reflection;
using SampleBrowser.Core;

namespace SampleBrowser.Presentation
{
    public partial class ModifyAnimation : SampleView
    {
        public ModifyAnimation()
        {
            InitializeComponent();

            if (Device.Idiom != TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
				this.btnGenerate.BackgroundColor = Color.Gray;
                this.btnInpTemplate.HorizontalOptions = LayoutOptions.Start;
                this.btnInpTemplate.VerticalOptions = LayoutOptions.Center;
                this.btnInpTemplate.BackgroundColor = Color.Gray;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.RuntimePlatform == Device.UWP)
            {
                this.Description.FontSize = 13.5;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
                this.btnInpTemplate.VerticalOptions = LayoutOptions.Center;
            }
        }

        void OnInputButtonClicked(object sender, EventArgs e)
        {
			string resourcePath = "";
			#if COMMONSB
			resourcePath = "SampleBrowser.Samples.Presentation.Samples.Templates.ShapeWithAnimation.pptx";
            #else
			resourcePath = "SampleBrowser.Presentation.Samples.Templates.ShapeWithAnimation.pptx";
            #endif
            Assembly assembly = typeof(GettingStarted).GetTypeInfo().Assembly;
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            MemoryStream stream = new MemoryStream();
            fileStream.CopyTo(stream);
            stream.Position = 0;
            fileStream.Dispose();
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("InputTemplate.pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("InputTemplate.pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation", stream);
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
			string resourcePath = "";
#if COMMONSB
			resourcePath = "SampleBrowser.Samples.Presentation.Samples.Templates.ShapeWithAnimation.pptx";
#else
			resourcePath = "SampleBrowser.Presentation.Samples.Templates.ShapeWithAnimation.pptx";
#endif
            Assembly assembly = typeof(GettingStarted).GetTypeInfo().Assembly;
            Stream fileStream = assembly.GetManifestResourceStream(resourcePath);

            //Open a PowerPoint presentation
            IPresentation presentation = Syncfusion.Presentation.Presentation.Open(fileStream);

            //Modify the existing animation
            ModifyAppliedAnimation(presentation);
			
            //Save the Presentation to stream
            MemoryStream stream = new MemoryStream();
            presentation.Save(stream);
            presentation.Close();
            stream.Position = 0;
            if (Device.RuntimePlatform == Device.UWP)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("ModifyAnimationSample.pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("ModifyAnimationSample.pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation", stream);
        }

#region Modify Animation

        private void ModifyAppliedAnimation(IPresentation presentation)
        {
            //Get the slide from the presentation
            ISlide slide = presentation.Slides[0];

            //Access the animation sequence to modify effects
            ISequence sequence = slide.Timeline.MainSequence;

            //Change the animation effect of the first effect
            IEffect loopEffect = sequence[0];
            loopEffect.Type = EffectType.Bounce;
        }
#endregion
    }
}
