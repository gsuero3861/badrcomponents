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

			Frame = new CGRect (x, y, width, height);

		}

		//settings
		nfloat _width = 1024 ;
		nfloat _height = 768 ;
		nfloat _x = 0 ;
		nfloat _y = 0 ;




	}
}

