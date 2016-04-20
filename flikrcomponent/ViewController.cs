using System;

using UIKit;
using Badr;
using CoreGraphics;

namespace flikrcomponent
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		BadrScrollView bscroll;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			View.BackgroundColor = UIColor.Yellow ;
			//bscroll = new BadrScrollView (20, 20, 888, 742);


			//View.Add (bscroll);
		//	addView();

			UIView mainview = new UIView (new CGRect(20,20,888,742));
			mainview.Layer.CornerRadius = 10;
			mainview.Layer.MasksToBounds = true;
			View.Add (mainview);



			CharacterBadrView cview = new CharacterBadrView (0, 0, 888, 742);
			mainview.Add (cview);

			UIView header = new UIView (new CGRect (0, 0, 888, 60));
			header.BackgroundColor = UIColor.FromRGB (206, 111, 28);
			mainview.Add (header);


			BadrRateView rateview = new BadrRateView (100, 100);
			rateview.Layer.ZPosition = 100;
			//View.Add (rateview);

		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
 
		UIView _topview , _backview ;
		UIImageView _backimage ;

		void addView()
		{
			_topview = new UIView (new CGRect (0,0,1024,2000)){BackgroundColor = UIColor.Clear};
			var topsubview = new UIView (new CGRect (0,300,1024,2000-300)){BackgroundColor = UIColor.Blue};
			_topview.Add (topsubview);

			_backview = new UIView (new CGRect (0,0,1024,1000)){BackgroundColor = UIColor.Black};
			//Main image from back
			_backimage = new UIImageView (new CGRect (0,0,1024,800)){ContentMode= UIViewContentMode.ScaleToFill};
			_backimage.Image = UIImage.FromFile ("myimage.jpg"); 
			_backview.Add (_backimage);

			BadrScrollView pscroll = new BadrScrollView (0, 0, 1024, 768);
			pscroll.SetContent (_topview, 5000);
			pscroll.SetBackContent (_backview, 1500);
			View.Add (pscroll);
		}

	}
}

