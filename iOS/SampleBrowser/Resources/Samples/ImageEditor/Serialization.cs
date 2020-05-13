#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using Syncfusion.SfImageEditor.iOS;
using Foundation;
using UIKit;
using CoreGraphics;
using System.Drawing;
using Photos;
using System.IO;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Collections.Generic;

namespace SampleBrowser
{
	public class Serialization : SampleView
	{
		CustomCollectionView CustomCollectionView = new CustomCollectionView();
		SerializationViewModel ViewModel = new SerializationViewModel();
		UINavigationController navigationController;
		List<SerializationModel> list = new List<SerializationModel>();
		UIButton Delete;

		public override void MovedToSuperview()
		{
			base.MovedToSuperview();
			var view = Superview;
			var window = UIApplication.SharedApplication.KeyWindow;
			navigationController = window.RootViewController as UINavigationController;
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			CustomCollectionView.Frame = new CGRect(0, 70, Frame.Width, Frame.Height - 150);
			CustomCollectionView.DataSource = ViewModel.ModelCollection;
			CustomCollectionView.ItemSelected += (sender, e) =>
			{
				var model = e as SerializationModel;
				ValidateItem(model);
			};
			CustomCollectionView.LongPressed += (sender, e) =>
			{
				
				if ((e as SerializationModel).Name != "Create New")
				{
				    Delete.Alpha = 1;
					EnableSelection();
				}
			};
			this.BackgroundColor = UIColor.FromRGB(242, 242, 242);

			/*------Header Label-------*/

			UILabel label = new UILabel(new CGRect(20, 50, Frame.Width, 25));
			label.BackgroundColor = UIColor.Clear;
			label.Font = UIFont.SystemFontOfSize(25);
			label.TextAlignment = UITextAlignment.Left;
			label.TextColor = UIColor.Gray;
			label.Text = "Serialization";


			/*------Delete------------*/


			Delete = new UIButton(new CGRect(Frame.Width / 2 - 50, Frame.Height - 60, 100, 50));
			Delete.Alpha = 0;
			Delete.BackgroundColor = UIColor.Clear;
			Delete.TouchUpInside += (sender, e) =>
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (ViewModel.ModelCollection.Contains(list[i]))
					{
						ViewModel.ModelCollection.Remove(list[i]);
					}

				}
				foreach (var item1 in ViewModel.ModelCollection)
				{
					item1.IsImageSelected = false;
					item1.IsItemSelectedToDelete = false;
					list = new List<SerializationModel>();

				}
				CustomCollectionView.DataSource = ViewModel.ModelCollection;
				Delete.Alpha = 0;
			};

			UIImageView DeleteButton = new UIImageView(new CGRect(0,0, 100, 50));
			DeleteButton.Image = UIImage.FromBundle("Images/ImageEditor/Delete1.png");
			DeleteButton.ContentMode = UIViewContentMode.ScaleAspectFit;
			Delete.AddSubview(DeleteButton);
			AddSubview(label);
			AddSubview(CustomCollectionView);
			AddSubview(Delete);

		}



		void ValidateItem(SerializationModel model)
		{
			if (model.Name == "Create New")
			{
				Delete.Alpha = 0;
				navigationController.PushViewController(new EditorViewController(model, CustomCollectionView, ViewModel), false);
				foreach (var item1 in ViewModel.ModelCollection)
				{
					item1.IsImageSelected = false;
					item1.IsItemSelectedToDelete = false;
				}
				
               CustomCollectionView.DataSource = ViewModel.ModelCollection;
               list = new List<SerializationModel>();
			}
			else if (!model.IsImageSelected)
				navigationController.PushViewController(new EditorViewController(model, CustomCollectionView, ViewModel), false);
			else
			{
				if (!model.IsItemSelectedToDelete)
				{
					model.IsItemSelectedToDelete = true;
					list.Add(model);

				}
				else
				{
					model.IsItemSelectedToDelete = false;
					if(list.Count!=0)
					list.Remove(model);
				}
				CustomCollectionView.DataSource = ViewModel.ModelCollection;
			}
			

		}
		
		void EnableSelection()
		{
			foreach (var item in ViewModel.ModelCollection)
			{
				item.IsImageSelected = true;
			}
			 CustomCollectionView.DataSource = ViewModel.ModelCollection;
		}
	}


	public class EditorViewController : UIViewController
	{
		SerializationModel _model;
		SfImageEditor sfImageEditor;
		SerializationViewModel _serializationViewModel;
		CustomCollectionView _collectionView;
		  string itemName = "";
		public EditorViewController(SerializationModel model, CustomCollectionView collectionView, SerializationViewModel serializationViewModel)
		{
			_model = model;
			_serializationViewModel = serializationViewModel;
			_collectionView = collectionView;
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			sfImageEditor = new SfImageEditor(new CGRect(View.Frame.Location.X, 60, View.Frame.Size.Width, View.Frame.Size.Height - 60));
			var sampleTimer = NSTimer.CreateTimer(TimeSpan.FromSeconds(3.0), delegate
			{

				ReadFile();
				Dispose();


			});
			sampleTimer.Fire();
			sfImageEditor.ImageSaving += (sender, e) =>
		{
			e.Cancel = true;
			var stream = e.Stream;
			var byteArray = ReadFully(stream);
			NSData data = NSData.FromArray(byteArray);

			if (_model.Name == "Create New")
			{
				var count = _collectionView.DataSource.Count;
				SerializationModel item = new SerializationModel()
				{
					Name = itemName != "" ? itemName : ValidateName(),
					ImageAlignment = UIViewContentMode.Center,
					ImageBackgroundColor = UIColor.FromRGB(255, 255, 255),
					id = count - 1,
					EditsStrm = null
				};
				item.EditsStrm = sfImageEditor.SaveEdits();
				item.Image = UIImage.LoadFromData(data);
				item.ImageAlignment = UIViewContentMode.ScaleAspectFit;
				_serializationViewModel.ModelCollection.Add(item);
				EditsViewModel.EditsCollection.Add(new EditsModel() { Name = item.Name });
			}
			else
			{
				_model.EditsStrm = sfImageEditor.SaveEdits();
				_model.Image = UIImage.LoadFromData(data);
				_model.ImageAlignment = UIViewContentMode.ScaleAspectFit;
			}


			_collectionView.DataSource = _serializationViewModel.ModelCollection;


		};

			this.View.Add(sfImageEditor);
		}
		
		 string ValidateName()
        {
            String Name = "NewItem";
            int j = 1;
            for (int i = 0; i < _serializationViewModel.ModelCollection.Count; i++)
            {
                if ( _serializationViewModel.ModelCollection[i].Name == Name)
                {
                    Name = "NewItem " + j;
                    j++;
                }

            }
            return Name;
        }


		public static byte[] ReadFully(Stream input)
		{
			byte[] buffer = new byte[16 * 1024];
			using (MemoryStream ms = new MemoryStream())
			{
				int read;
				while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
				{
					ms.Write(buffer, 0, read);
				}
				return ms.ToArray();
			}
		}


		private void ReadFile()
		{
			if (_model.id != -1)
			{
				if (_model.EditsStrm == null )
					sfImageEditor.LoadEdits(EditsViewModel.EditsCollection[_model.id].Stream);
				else
					sfImageEditor.LoadEdits(_model.EditsStrm);
			}
		}

	}




	public class EditsViewModel
	{
		public static ObservableCollection<EditsModel> EditsCollection = new ObservableCollection<EditsModel>()
		{

		new EditsModel(){Name = "Chart"},
		new EditsModel(){Name = "Venn"},
		new EditsModel(){Name = "FreeHand"},

		};
	}
	public class EditsModel
	{
		private string name;

		public string Name
		{
			get { return name; }
			set
			{
				name = value;
			}
		}
		private Stream stream;

		public Stream Stream
		{
			get
			{
				return this.GetType().GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Resources.Images.ImageEditor." + name + ".txt");
			}

			set
			{
				stream = value;

			}
		}
	}





	public class SerializationModel
	{

		public string Name { get; set; }

		public int id { get; set; }

		public UIImage Image { get; set; }

		public UIViewContentMode ImageAlignment { get; set; }

		public UIColor ImageBackgroundColor { get; set; }

		public Stream Strm { get; set; }

		public Stream EditsStrm { get; set; }
		
		public bool IsImageSelected { get; set; }
		
		public bool IsItemSelectedToDelete { get; set; }



	}


	public class SerializationViewModel
	{

		public ObservableCollection<SerializationModel> ModelCollection { get; set; }


		public SerializationViewModel()
		{
			ModelCollection = new ObservableCollection<SerializationModel>() {

		   new SerializationModel(){ Name ="Create New", Image = UIImage.FromBundle("Images/ImageEditor/CreateNew.png"),ImageAlignment= UIViewContentMode.Center,ImageBackgroundColor=UIColor.FromRGB(6,93,199),id=-1,EditsStrm=null,IsItemSelectedToDelete=false },
		   new SerializationModel(){ Name ="Chart", Image = UIImage.FromBundle("Images/ImageEditor/Chart.jpg"),ImageAlignment= UIViewContentMode.ScaleAspectFit,ImageBackgroundColor=UIColor.FromRGB(255,255,255),Strm=EditsViewModel.EditsCollection[0].Stream,id=0,EditsStrm=null,IsImageSelected =false,IsItemSelectedToDelete=false},
		   new SerializationModel(){ Name ="Venn Diagram", Image = UIImage.FromBundle("Images/ImageEditor/Venn.jpg"),ImageAlignment= UIViewContentMode.ScaleAspectFit,ImageBackgroundColor=UIColor.FromRGB(255,255,255),Strm=EditsViewModel.EditsCollection[1].Stream,id=1,EditsStrm=null,IsImageSelected = false,IsItemSelectedToDelete=false},
		   new SerializationModel(){ Name ="Freehand", Image = UIImage.FromBundle("Images/ImageEditor/Freehand.jpg"),ImageAlignment= UIViewContentMode.ScaleAspectFit,ImageBackgroundColor=UIColor.FromRGB(255,255,255),Strm=EditsViewModel.EditsCollection[2].Stream,id=2,EditsStrm=null,IsImageSelected =false ,IsItemSelectedToDelete=false},
 };
		}
	}

	public class CustomCollectionView : UIScrollView
	{

		ObservableCollection<SerializationModel> dataSource;

		public CustomCollectionView()
		{


		}

		public ObservableCollection<SerializationModel> DataSource
		{

			get { return dataSource; }
			set
			{
				dataSource = value;
				GenerateCollectionView();
			}
		}

		public int NumberofColums = 2;
		public event CollectionViewSelectionEventHandler ItemSelected;
		public event CollectionViewSelectionEventHandler LongPressed;


		void GenerateCollectionView()
		{
			//Remove subViews
			foreach (UIView view in this.Subviews)
			{
				view.RemoveFromSuperview();
			}

			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				NumberofColums = 3;
			}

			int index = 0, x = 0, y = 30;
			int padding = 30;
			nfloat ItemSize = (Frame.Width / NumberofColums) - padding;
			x = padding / 2;

			ContentSize = new CGSize(Frame.Width, (ItemSize + padding) * ((DataSource.Count / NumberofColums) + 1));

			foreach (var model in DataSource)
			{

				CGRect rect = new CGRect(x, y, ItemSize, ItemSize);
				this.AddSubview(GetItemView(model, rect));
				index++;
				if (index % NumberofColums != 0)
				{
					x += (15 + (int)ItemSize);
				}
				else
				{
					x = padding / 2;
					y += (int)ItemSize + 10;

				}

			}

		}

		UIView GetItemView(SerializationModel model, CGRect frame)
		{
			UIButton button = new UIButton(frame);
			UIImageView imageView = new UIImageView(new CGRect(0, 5, frame.Width, frame.Height - 20));
			imageView.Alpha = 1f;
			imageView.Image = model.Image;
			imageView.BackgroundColor = model.ImageBackgroundColor;
			imageView.ContentMode = model.ImageAlignment;
			button.AddSubview(imageView);

			UILabel label = new UILabel();
			if (model.Name != "Create New")
			{

				label.Frame = new CGRect(0, frame.Height - 40, frame.Width, 25);
				label.Alpha = 0.5f;
				label.BackgroundColor = UIColor.LightGray;
				if (model.IsImageSelected)
				{
					UIImageView SelectedView = new UIImageView(new CGRect(frame.Width - 25, 10, 20, 20));
					if (!model.IsItemSelectedToDelete)
					{
						SelectedView.Image = UIImage.FromBundle("Images/ImageEditor/NotSelected.png");
						imageView.Alpha = 1f;
					}
					else
					{
						SelectedView.Image = UIImage.FromBundle("Images/ImageEditor/Selected.png");
						imageView.Alpha = 0.3f;
					}
					SelectedView.BackgroundColor = UIColor.Clear;
					SelectedView.ContentMode = UIViewContentMode.ScaleAspectFit;
					button.AddSubview(SelectedView);

				}

			}
			else
			{
				if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				{
					label.Frame = new CGRect(0, frame.Height / 2 + 50, frame.Width, 25);
				}
				else
				label.Frame = new CGRect(0, frame.Height / 2 + 20, frame.Width, 25);
				label.Alpha = 1f;
				label.BackgroundColor = UIColor.Clear;
				label.TextColor = UIColor.White;
			}

			label.Font = UIFont.SystemFontOfSize(18);
			label.TextAlignment = UITextAlignment.Center;
			label.Text = model.Name;
			button.AddSubview(label);
			UILongPressGestureRecognizer detector = new UILongPressGestureRecognizer((UILongPressGestureRecognizer obj) =>
			{
				OnLongPressed(this, model);
			});
			button.AddGestureRecognizer(detector);
			button.TouchUpInside += (sender, e) =>
			{

				OnItemSelected(this, model);
			};
			
			return button;



		}

		internal void OnItemSelected(object sender, SerializationModel args)
		{
			this.ItemSelected?.Invoke(sender, args);
		}

		internal void OnLongPressed(object sender, SerializationModel args)
		{
			this.LongPressed?.Invoke(sender, args);
		}
	}
	public delegate void CollectionViewSelectionEventHandler(object sender, SerializationModel e);
	public delegate void CollectionViewLongPressEventHandler(object sender, SerializationModel e);
}
