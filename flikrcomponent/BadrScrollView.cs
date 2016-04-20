using System; 
using System.Drawing;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;
using Foundation;

namespace Badr
{
	public class BadrScrollView : UIView
	{
		public BadrScrollView (nfloat x, nfloat y,nfloat width, nfloat height)
		{
			AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;

			_width = width;
			_height = height;
			_x = x;
			_y = y;

			Frame = new CGRect (_x, _y, _width, _height);

			initControls (); 
		}

		//settings
		nfloat _width = 888 ;
		nfloat _height = 742 ;
		nfloat _x = 0 ;
		nfloat _y = 0 ;

	 
	 

		#region Properties

		UIScrollView scroll, backScroll ; 
		//GTScrollOrientation ScrollOrientation = GTScrollOrientation.Horizontal ;
		//nfloat DeviceWidth = 1024, DeviceHeight = 768 ;
		nfloat ContentSize = 0 ;
		//nfloat xPos= 0, yPos = 0;

		#endregion


		void initControls()
		{
			BackgroundColor = UIColor.Clear;

			backScroll = new UIScrollView (new CGRect(_x,_y,_width,_height));
			backScroll.MinimumZoomScale = 1.0f;
			backScroll.MaximumZoomScale = 10.0f;
			backScroll.BouncesZoom = false;
			backScroll.BackgroundColor = UIColor.Clear;
			Add (backScroll);

			scroll = new UIScrollView (new CGRect(_x,_y,_width,_height));
			scroll.DecelerationRate = 8;  
			Add (scroll);

			scroll.Scrolled += (sender, e) => {
				nfloat off_set ;
				off_set = scroll.ContentOffset.Y ;

				if(off_set <= 0 ) 
				{
					backScroll.SetZoomScale(1+ (nfloat)Math.Abs(off_set*0.0002) , false ); 
					//backScroll.SetContentOffset(new CGPoint(0, 0), false); 
					backScroll.SetContentOffset(new CGPoint(0.5 * _width * (nfloat)Math.Abs(off_set*0.0002) ,0), false);
				}
				else 
					backScroll.SetContentOffset(new CGPoint(scroll.ContentOffset.X / 2, scroll.ContentOffset.Y / 2), false);  
			};

		}


		#region Public Methods

		public void SetContent(UIView content, nfloat size)
		{
			ContentSize = size; 
			scroll.Add (content); 
			scroll.ContentSize = new CGSize (_width,ContentSize); 
		}

		public void SetBackContent(UIView content, nfloat size)
		{
			backScroll.Add (content); 
			backScroll.ContentSize = new CGSize (_width,size); 
			backScroll.ViewForZoomingInScrollView += (UIScrollView sv) => { return content; };
		}

		public void SetSize(nfloat size)
		{
			ContentSize = size;
			scroll.ContentSize = new CGSize (_width,ContentSize); 
		}

		public void SetContentOffset(nfloat offset)
		{
			backScroll.SetContentOffset (new CGPoint (backScroll.ContentOffset.X, offset), false);
		}

		#endregion

	}
}

