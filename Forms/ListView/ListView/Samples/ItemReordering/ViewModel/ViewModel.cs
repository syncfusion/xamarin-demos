#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.ListView.XForms.Control.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfListView
{
    [Preserve(AllMembers = true)]
    public class ListViewToDoViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<ToDoItem> toDoList;

        private Command<object> markDoneCommand;

        #endregion

        #region Constructor

        public ListViewToDoViewModel()
        {
            this.GenerateSource();
            MarkDoneCommand = new Command<object>(MarkItemAsDone);
        }

        private void MarkItemAsDone(object obj)
        {
            var item = obj as ToDoItem;
            item.IsDone = !item.IsDone;
        }

        #endregion

        #region Property

        public Command<object> MarkDoneCommand { get
            {
                return markDoneCommand;
            }
             set
            {
                if(markDoneCommand != value)
                {
                    markDoneCommand = value;
                    OnPropertyChanged("MarkDoneCommand");
                }
            }
        }

        public ObservableCollection<ToDoItem> ToDoList
        {
            get
            {
                return toDoList;
            }
            set
            {
                this.toDoList = value;
            }
        }

        #endregion

        #region Method

        public void GenerateSource()
        {
            ToDoListRepository groceryRepository = new ToDoListRepository();
            toDoList = groceryRepository.GetToDoList();
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
        
    }
}
