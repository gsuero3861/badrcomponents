using System; 
using System.Drawing;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;
using Foundation;

namespace flikrcomponent
{
	public class CharacterBadrView : UIView
	{
		public CharacterBadrView (nfloat x, nfloat y,nfloat width, nfloat height)
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


		UIImageView  _card_img , _character_img; 
		UIView _open_bt ;

		void initControls()
		{

			BackgroundColor = UIColor.FromRGB (229, 228, 208);

			//image for the card view
			_card_img = new UIImageView (new CGRect (18, 80, 306, 230));
			_card_img.Image = UIImage.FromFile ("cardimg.png");
			_card_img.ContentMode = UIViewContentMode.ScaleAspectFill; 
			Add (_card_img);

			//button-view for open character
			_open_bt = new UIView(new CGRect(28,320, 94,36 ));
			_open_bt.Add (new UIImageView (UIImage.FromFile ("characterassets/button.png")));
			_open_bt.Add (new UILabel (new CGRect (0, 0, 94, 36)){
				Text = "open",
				Font = UIFont.FromName("HelveticaNeue", 16),
				TextAlignment = UITextAlignment.Center,
				TextColor =  UIColor.White
			});
			Add (_open_bt);

			//RATE
			addRateView();

		}


		UILabel _rate_title, _rate_description ;
		void addRateView()
		{
			_rate_title = new UILabel (new CGRect (136, 320, 190, 20)){ 
				Text = "Rate this collection",
				Font = UIFont.FromName("HelveticaNeue", 16),
				TextAlignment = UITextAlignment.Left,
				TextColor =  UIColor.Black
			};
			Add (_rate_title);

			_rate_description = new UILabel (new CGRect (136, 340, 190, 20)){ 
				Text = "Tape to Rate",
				Font = UIFont.FromName("HelveticaNeue", 11),
				TextAlignment = UITextAlignment.Left,
				TextColor =  UIColor.Black
			};
			Add (_rate_description);
		}


	}
}

