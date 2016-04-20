using System; 
using System.Drawing;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;
using Foundation;
using Badr;

namespace flikrcomponent
{
	public class PostBadrView : UIView
	{
		public PostBadrView (nfloat x, nfloat y,nfloat width, nfloat height)
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


		UIView _topview , _backview ; 
		BadrScrollView pscroll ;


		void initControls()
		{
			
		}

	}
}

