#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Android.Database;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Content;

namespace SampleBrowser
{
	[Preserve]
	public delegate void ScreenChangedEventHandler(object sender, ScreenChangedEventArgs e);

	[Preserve(AllMembers = true)]
	public class ScreenChangedEventArgs : EventArgs
	{
		public int CurrentScreen { get; set; }
		public int CurrentX { get; set; }
	}

	[Preserve(AllMembers = true)]
	[Register("SampleBrowser.SampleBrowser.HorizontalListView")]
	public class HorizontalListView : AdapterView<BaseAdapter>
	{
		#region Fields
		private int _currentScreen;

		private int _leftViewIndex;
		private int _rightViewIndex;
		private int _displayOffset;
		private int _currentX;
		private int _nextX;
		private int _maxX;
		private GestureDetector _gestureDetector;
		private readonly Queue<View> _removedViewQueue = new Queue<View>();
		private bool _dataChanged;
		private DataSetObserver _dataSetObserver;
		private BaseAdapter _adapter;

		#endregion

		#region Ctor + Init

		public HorizontalListView(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
		{
			InitView();
			_dataSetObserver = new DataObserver(this);
		}

		public HorizontalListView(Context context) : this(context, null) { }

		public HorizontalListView(Context context, IAttributeSet attrs) : this(context, attrs, 0) { }

		public HorizontalListView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
		{
			InitView();
			_dataSetObserver = new DataObserver(this);
		}

		private void InitView()
		{
			_leftViewIndex = -1;
			_rightViewIndex = 0;
			_displayOffset = 0;
			_currentX = 0;
			_nextX = 0;
			_maxX = int.MaxValue;
			Scroller = new Scroller(Context);
			var listener = new GestureListener(this);
			_gestureDetector = new GestureDetector(Context, listener);

			SetBackgroundResource(Resource.Layout.listviewborder);
		}

		#endregion

		#region Properties

		#region EventHandlers

		public event ScreenChangedEventHandler ScreenChanged;

		protected virtual void OnScreenChanged(ScreenChangedEventArgs e)
		{
			if (ScreenChanged != null)
				ScreenChanged(this, e);
		}

		#endregion

		public override View SelectedView
		{
			get { return GetChildAt(CurrentScreen); }
		}

		public override BaseAdapter Adapter
		{
			get { return _adapter; }
			set
			{
				if (null != Adapter)
					Adapter.UnregisterDataSetObserver(_dataSetObserver);

				_adapter = value;
				_adapter.RegisterDataSetObserver(_dataSetObserver);
				Reset();
			}
		}

		public Scroller Scroller { get; private set; }

		/// <summary>
		/// Returns the CurrentScreen (Snap mode only).
		/// </summary>
		public int CurrentScreen
		{
			get { return _currentScreen; }
			private set
			{
				_currentScreen = value;
				OnScreenChanged(new ScreenChangedEventArgs
				{
					CurrentScreen = _currentScreen,
					CurrentX = _currentX
				});
			}
		}

		/// <summary>
		/// Returns the current leftmost X coordinate.
		/// </summary>
		public int CurrentX
		{
			get { return _currentX; }
			private set { _currentX = value; }
		}

		#endregion

		private void Reset()
		{
			lock (this)
			{
				InitView();
				RemoveAllViewsInLayout();
				RequestLayout();
			}
		}

		private void AddAndMeasureChild(View child, int viewPos)
		{
			var childParams = child.LayoutParameters ??
							  new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
			AddViewInLayout(child, viewPos, childParams, true);
			child.Measure(MeasureSpec.MakeMeasureSpec(Width, MeasureSpecMode.AtMost),
				MeasureSpec.MakeMeasureSpec(Height, MeasureSpecMode.AtMost));
		}

		protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
		{
			base.OnLayout(changed, left, top, right, bottom);

			if (null == Adapter)
				return;

			if (_dataChanged)
			{
				var oldCurrentX = CurrentX;
				InitView();
				RemoveAllViewsInLayout();
				_nextX = oldCurrentX;
				_dataChanged = false;
			}

			if (Scroller.ComputeScrollOffset())
				_nextX = Scroller.CurrX;

			if (_nextX <= 0)
			{
				_nextX = 0;
				Scroller.ForceFinished(true);
			}

			if (_nextX >= _maxX)
			{
				_nextX = _maxX;
				Scroller.ForceFinished(true);
			}

			var dx = CurrentX - _nextX;
			RemoveNonVisibleItems(dx);
			FillList(dx);
			PositionItems(dx);

			CurrentX = _nextX;

			if (!Scroller.IsFinished)
				Post(RequestLayout);
		}

		public override void SetSelection(int position)
		{
			CurrentScreen = position;
		}

		private void FillList(int dx)
		{
			var edge = _displayOffset; //TODO: https://github.com/dinocore1/DevsmartLib-Android/issues/24
			var child = GetChildAt(ChildCount - 1);
			if (null != child)
				edge = child.Right;
			FillListRight(edge, dx);

			edge = 0;
			child = GetChildAt(0);
			if (null != child)
				edge = child.Left;
			FillListLeft(edge, dx);
		}

		private void FillListRight(int rightEdge, int dx)
		{
			while (rightEdge + dx < Width && _rightViewIndex < Adapter.Count)
			{
				View view = null;
				if (_removedViewQueue.Count > 0)
				{
					view = _removedViewQueue.Dequeue();
				}

				var child = Adapter.GetView(_rightViewIndex, view, this);
				AddAndMeasureChild(child, -1);
				rightEdge += child.MeasuredWidth;

				if (_rightViewIndex == Adapter.Count - 1)
				{
					_maxX = CurrentX + rightEdge - Width;
				}

				if (_maxX < 0)
					_maxX = 0;

				_rightViewIndex++;
			}
		}

		private void FillListLeft(int leftEdge, int dx)
		{
			while (leftEdge + dx > 0 && _leftViewIndex >= 0)
			{
				View view = null;
				if (_removedViewQueue.Count > 0)
				{
					view = _removedViewQueue.Dequeue();
				}

				var child = Adapter.GetView(_leftViewIndex, view, this);
				AddAndMeasureChild(child, 0);
				leftEdge -= child.MeasuredWidth;
				_leftViewIndex--;
				_displayOffset -= child.MeasuredWidth;
			}
		}

		private void RemoveNonVisibleItems(int dx)
		{
			var child = GetChildAt(0);
			while (null != child && child.Right + dx <= 0)
			{
				_displayOffset += child.MeasuredWidth;
				_removedViewQueue.Enqueue(child);
				RemoveViewInLayout(child);
				_leftViewIndex++;
				child = GetChildAt(0);
			}

			child = GetChildAt(ChildCount - 1);
			while (null != child && child.Left + dx >= Width)
			{
				_removedViewQueue.Enqueue(child);
				RemoveViewInLayout(child);
				_rightViewIndex--;
				child = GetChildAt(ChildCount - 1);
			}
		}

		private void PositionItems(int dx)
		{
			if (ChildCount < 1) return;

			_displayOffset += dx;
			var left = _displayOffset;
			for (var i = 0; i < ChildCount; i++)
			{
				var child = GetChildAt(i);
				var childWidth = child.MeasuredWidth;
				child.Layout(left, 0, left + childWidth, child.MeasuredHeight);
				left += childWidth + child.PaddingRight;
			}
		}

		public override bool DispatchTouchEvent(MotionEvent e)
		{
			var handled = base.DispatchTouchEvent(e) | (_gestureDetector.Handle != IntPtr.Zero && _gestureDetector.OnTouchEvent(e));
			return handled;
		}

		public void ScrollTo(int x)
		{
			Scroller.StartScroll(_nextX, 0, x - _nextX, 0);
			RequestLayout();
		}

		protected bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
		{
			lock (this)
			{
				Scroller.Fling(_nextX, 0, (int)-velocityX, 0, 0, _maxX, 0, 0);
			}
			RequestLayout();

			return true;
		}

		protected bool OnDown(MotionEvent e)
		{
			Scroller.ForceFinished(true);
			return true;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (null != _gestureDetector)
				{
					_gestureDetector.Dispose();
					_gestureDetector = null;
				}
				if (null != Scroller)
				{
					Scroller.Dispose();
					Scroller = null;
				}
				if (null != _dataSetObserver)
				{
					_dataSetObserver.Dispose();
					_dataSetObserver = null;
				}
			}

			base.Dispose(disposing);
		}

		#region Internal classes
		[Preserve(AllMembers = true)]
		private class DataObserver : DataSetObserver
		{
			private readonly HorizontalListView _horizontalListView;

			public DataObserver(HorizontalListView horizontalListView)
			{
				_horizontalListView = horizontalListView;
			}

			public override void OnChanged()
			{
				_horizontalListView._dataChanged = true;
				_horizontalListView.Invalidate();
				_horizontalListView.RequestLayout();
			}

			public override void OnInvalidated()
			{
				_horizontalListView.Reset();
				_horizontalListView.Invalidate();
				_horizontalListView.RequestLayout();
			}
		}

		[Preserve(AllMembers = true)]
		private class GestureListener : GestureDetector.SimpleOnGestureListener
		{
			private readonly HorizontalListView _horizontalListView;

			public GestureListener(HorizontalListView horizontalListView)
			{
				_horizontalListView = horizontalListView;
			}

			public override bool OnDown(MotionEvent e)
			{
				return _horizontalListView.OnDown(e);
			}

			public override bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
			{
				return _horizontalListView.OnFling(e1, e2, velocityX, velocityY);
			}

			public override bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
			{
				_horizontalListView.RequestDisallowInterceptTouchEvent(true);
				_horizontalListView._nextX += (int)distanceX;
				_horizontalListView.RequestLayout();

				return true;
			}

			public override bool OnSingleTapConfirmed(MotionEvent e)
			{
				for (var i = 0; i < _horizontalListView.ChildCount; i++)
				{
					var child = _horizontalListView.GetChildAt(i);

					if (!IsEventWithinView(e, child)) continue;
					if (null != _horizontalListView.OnItemClickListener)
						_horizontalListView.OnItemClickListener.OnItemClick(_horizontalListView, child, _horizontalListView._leftViewIndex + 1 + i,
																			_horizontalListView.Adapter.GetItemId(_horizontalListView._leftViewIndex + 1 + i));
					if (null != _horizontalListView.OnItemSelectedListener)
						_horizontalListView.OnItemSelectedListener.OnItemSelected(_horizontalListView, child, _horizontalListView._leftViewIndex + 1 + i,
																				  _horizontalListView.Adapter.GetItemId(_horizontalListView._leftViewIndex + 1 + i));
					break;
				}

				return true;
			}

			public override void OnLongPress(MotionEvent e)
			{
				for (var i = 0; i < _horizontalListView.ChildCount; i++)
				{
					var child = _horizontalListView.GetChildAt(i);

					if (!IsEventWithinView(e, child)) continue;
					if (null != _horizontalListView.OnItemLongClickListener)
						_horizontalListView.OnItemLongClickListener.OnItemLongClick(_horizontalListView, child, _horizontalListView._leftViewIndex + 1 + i,
																					_horizontalListView.Adapter.GetItemId(_horizontalListView._leftViewIndex + 1 + i));
					break;
				}
			}

			private static bool IsEventWithinView(MotionEvent e, View child)
			{
				var viewRect = new Rect();
				var childPosition = new int[2];
				child.GetLocationOnScreen(childPosition);
				var left = childPosition[0];
				var right = left + child.Width;
				var top = childPosition[1];
				var bottom = top + child.Height;
				viewRect.Set(left, top, right, bottom);
				return viewRect.Contains((int)e.RawX, (int)e.RawY);
			}
		}
		#endregion
	}
}