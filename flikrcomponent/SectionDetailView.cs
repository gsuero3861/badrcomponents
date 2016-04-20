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
		BadrScrollView pscroll ;

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
			pscroll = new BadrScrollView (0, 0, _width, _height);
			pscroll.SetContent (_topview, 5000);
			pscroll.SetBackContent (_backview, 1500);
			Add (pscroll);
		}



		UIImageView _icon_image ;
		UILabel _year_label ;
		UILabel _released_label, _pages_label , _creator_label, _rating_label ;
		UIView _open_view  ;
		BadrRateView _rate_view1 , _rate_view2 ;
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

			//year label
			_year_label = new UILabel(new CGRect(132,82,300,20)){
				Text = "2016 | 24 pages",
				TextColor = UIColor.White,
				Font = UIFont.FromName("HelveticaNeue" , 18 )
			};
			_header_view.Add (_year_label);

			//RATING VIEW
			var genre_label = new UILabel(new CGRect(132,106, 300 , 20)){
				Text = "Genre Comic",
				TextColor =  UIColor.White,
				Font =  UIFont.FromName("HelveticaNeue-Light", 14)
			};
			_header_view.Add (genre_label);	

			_rate_view1 = new BadrRateView (132, 126);
			_header_view.Add (_rate_view1);


			var rates_label = new UILabel(new CGRect(132,150, 300 , 20)){
				Text = "(116 Ratings)",
				TextColor =  UIColor.White,
				Font =  UIFont.FromName("HelveticaNeue", 14)
			};
			_header_view.Add (rates_label);	



			// Released 
			_released_label = new UILabel(new CGRect(20,182,300,18)){
				Text = "Released : Feb 24, 2016",
				TextColor = UIColor.White,
				Font = UIFont.FromName("HelveticaNeue" , 14 )
			};
			_header_view.Add (_released_label);

			// Pages 
			_pages_label = new UILabel(new CGRect(20,200,300,18)){
				Text = "Pages : 24",
				TextColor = UIColor.White,
				Font = UIFont.FromName("HelveticaNeue" , 14 )
			};
			_header_view.Add (_pages_label);

			// Creators 
			_creator_label = new UILabel(new CGRect(20,218,300,18)){
				Text = "Creator :  NWES",
				TextColor = UIColor.White,
				Font = UIFont.FromName("HelveticaNeue" , 14 )
			};
			_header_view.Add (_creator_label);


			// Rating 
			_rating_label = new UILabel(new CGRect(20,236,300,18)){
				Text = "Rating : 12+",
				TextColor = UIColor.White,
				Font = UIFont.FromName("HelveticaNeue" , 14 )
			};
			_header_view.Add (_rating_label);




			//Open button-view 
			_open_view = new UIView(new CGRect(612,216, 94,36 ));
			_open_view.Add (new UIImageView (UIImage.FromFile ("characterassets/button.png")));
			_open_view.Add (new UILabel (new CGRect (0, 0, 94, 36)){
				Text = "open",
				Font = UIFont.FromName("HelveticaNeue", 16),
				TextAlignment = UITextAlignment.Center,
				TextColor =  UIColor.White
			});
			UITapGestureRecognizer open_gesture = new UITapGestureRecognizer (() => {
				
			});
			_open_view.AddGestureRecognizer (open_gesture);
			_header_view.Add (_open_view);
		}

		/// <summary>
		/// Number of pages property
		/// </summary>
		int num_pages = 10  ;
		public int NumberPages
		{
			get { return num_pages; }
			set 
			{
				num_pages = value; 
				_year_label.Text = Year + " | " + num_pages + " pages";
			}
		}


		/// <summary>
		/// Number of pages property
		/// </summary>
		int year = 2000  ;
		public int Year
		{
			get { return year; }
			set 
			{
				year = value; 
				_year_label.Text = year + " | " + num_pages + " pages";
			}
		}


		UIImageView _slice_image ; 
		UILabel _summary_title , _credits_title ;

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

