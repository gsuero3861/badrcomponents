using System; 
using System.Drawing;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;
using Foundation;

namespace Badr
{
	public class BadrHomeView : UIView
	{
		public BadrHomeView (nfloat x, nfloat y,nfloat width, nfloat height)
		{
			AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;

			_width = width;
			_height = height;

			Frame = new CGRect (x, y, width, height);


		}


		//settings
		nfloat _width = 1024 ;
		nfloat _height =  768 ;
	}
}

