#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Java.IO;
using System.Collections.Generic;

namespace SampleBrowser
{
	public class SampleBase : Java.Lang.Object, ISerializable
	{
		public SampleBase()
		{
		}

		public string Type = "";

		public string Name;

		public string Description;

		public string Title;

		public string ImageId;
	}

	public class Group : SampleBase
	{
		public Group()
		{

		}

		public List<SampleBase> subGroups = new List<SampleBase>();

		public List<SampleBase> Features = new List<SampleBase>();

		public List<SampleBase> samples = new List<SampleBase>();
	}

	public class Sample : SampleBase
	{
		public Sample()
		{
		}
	}

	public class Feature : SampleBase
	{
		public Feature()
		{
		}
	}
}