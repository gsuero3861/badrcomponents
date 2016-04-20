using System; 
using System.Drawing;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;
using Foundation;
using Badr;

namespace flikrcomponent
{
	public class BadrRateView : UIView
	{
		public BadrRateView (nfloat x, nfloat y)
		{
			AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;
 
			_x = x;
			_y = y;

			Frame = new CGRect (_x, _y, _size * 5, _size);

			initControls (); 
		}


		//settings
		nfloat _size =  18 ;
		nfloat _x = 0 ;
		nfloat _y = 0 ;


		List<RateStarView> rateList  = new List<RateStarView>();
		void initControls()
		{
			

			for (int i = 0; i < 5; i++) {
				RateStarView star = new RateStarView (i*_size , 0, i); 
				Add (star);
				rateList.Add (star);

				star.UserInteractionEnabled = true;

				UITapGestureRecognizer gesture = new UITapGestureRecognizer(()=>{
					setRate (star.index);
				});
				AddGestureRecognizer (gesture);
				gesture.NumberOfTapsRequired = 1 ; 
				star.AddGestureRecognizer (gesture);
			}

			setRate (2);
		}

		 
		void setRate(int index)
		{
			for (int i = 0; i < 5; i++) {
				if(i<=index)
					rateList [i].startimg.Image = UIImage.FromFile ("badrassets/starblack.png");
				else
					rateList [i].startimg.Image = UIImage.FromFile ("badrassets/starwhite.png");
			} 
		}

	}


	public class RateStarView : UIView
	{
		public RateStarView (nfloat x, nfloat y, int i)
		{
			AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;

			_x = x;
			_y = y;
			index = i;

			Frame = new CGRect (_x, _y, _size, _size);

			initControls (); 
		}


		//settings
		nfloat _size =  18 ;
		nfloat _x = 0 ;
		nfloat _y = 0 ;
		public int index = 0  ;

		public UIImageView startimg;

		void initControls()
		{
			startimg =  new UIImageView(new CGRect(0,0,_size,_size));
			startimg.Image = UIImage.FromFile ("badrassets/starblack.png"); 
			Add (startimg);
		}


	}
}

