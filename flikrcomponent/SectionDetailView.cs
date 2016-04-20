using System; 
using System.Drawing;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;
using Foundation;
using Badr;

namespace flikrcomponent
{
	public class SectionDetailView  : UIView
	{
		public SectionDetailView  (nfloat x, nfloat y,nfloat width, nfloat height)
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


		void initControls()
		{
			initParallax ();
		}

		nfloat _topheight =  268 ;
		UIView _topview , _backview ;
		UIImageView _backimage ;
		UIView _header_view , _description_view ;

		void initParallax()
		{
			_topview = new UIView (new CGRect (0,0,_width,2000)){BackgroundColor = UIColor.Clear};
			//var topsubview = new UIView (new CGRect (0,_topheight,_width,2000-_topheight)){BackgroundColor = UIColor.White};
			//_topview.Add (topsubview);


			loadHeaderView ();
			loadDescription ();

			_backview = new UIView (new CGRect (0,0,_width,_height * 2)){BackgroundColor = UIColor.Black};

			//Badr image from back Scroll
			_backimage = new UIImageView (new CGRect (0,0,_width,_height)){ContentMode= UIViewContentMode.ScaleAspectFill};
			_backimage.Image = UIImage.FromFile ("fullpag.png");
			_backview.Add (_backimage);

			//Set the main view for Badr
			BadrScrollView pscroll = new BadrScrollView (0, 0, _width, _height);
			pscroll.SetContent (_topview, 5000);
			pscroll.SetBackContent (_backview, 1500);
			Add (pscroll);
		}

		UIImageView _icon_image ;
		void loadHeaderView()
		{
			_header_view = new UIView (new CGRect(0,0,_width, _topheight));
			_topview.Add (_header_view);

			//icon image
			_icon_image =  new UIImageView(new CGRect(20,78,92,92));
			_icon_image.Image = UIImage.FromFile ("cardimg.png");
			_icon_image.Layer.CornerRadius = 10;
			_icon_image.Layer.MasksToBounds = true;
			_header_view.Add (_icon_image);


		}


		UIImageView _slice_image ;

		void loadDescription()
		{
			_description_view = new UIView (new CGRect(0,_topheight,_width, _height - _topheight));
			_description_view.BackgroundColor = UIColor.White;
			_topview.Add (_description_view);
			//slice image
			_slice_image = new UIImageView(new CGRect(526,0,362,474));
			_slice_image.Image = UIImage.FromFile ("slice5.png");
			//_slice_image.ContentMode = UIViewContentMode.ScaleAspectFill;
			_slice_image.Layer.MasksToBounds = true;
			_description_view.Add (_slice_image);
		}
	}
}

