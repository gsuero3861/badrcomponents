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
		BadrRateView _rate_view1 ;
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


			addInfo ();

			_character_img = new UIImageView (new CGRect(572, 60, 316, 682));
			_character_img.ContentMode = UIViewContentMode.ScaleAspectFill;
			_character_img.Image =  UIImage.FromFile("abuyahl.png");
			Add (_character_img);

			_rate_view1 = new BadrRateView (210, 340);
			Add (_rate_view1);

		}


		string strname =  "Abu Yahl Hishan Aj Majzumi" ;
		string stryears = "40 years" ;
		string strheight =  "1.80 m" ;
		string strweight = "91 kg" ; 
		string stroccup = "General del Ejercito Peruano" ;
		string strtalent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit" ;
		string strcolors = "Lorem ipsum dolor sit amet, consectetur adipiscing elit" ;
		string strdress = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." ;
		string strpersonal = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo" ;
		UILabel _fullname , _yearslabel , _heightlabel , _weightlabel , _occuplabel;
		UILabel _talentlabel , _colorlabel , _dresslabel, _personallabel ;
		void addInfo()
		{
			var firstAttributes = new UIStringAttributes {
				ForegroundColor = UIColor.FromRGB(121,12,30), 
				Font = UIFont.FromName("HelveticaNeue-Bold", 14f)
			};

			var secondAttributes = new UIStringAttributes {
				ForegroundColor = UIColor.Black, 
				Font = UIFont.FromName("HelveticaNeue", 14f)
			};

			nfloat delta = 28;

			// Name
			var nameString = new NSMutableAttributedString ("Full Name : " + strname);
			nameString.SetAttributes (firstAttributes.Dictionary, new NSRange (0, 11));
			nameString.SetAttributes (secondAttributes.Dictionary, new NSRange (12, strname.Length ));
			_fullname = new UILabel (new CGRect (20, 390 + 0*delta, 540, 30));
			_fullname.AttributedText = nameString;
			Add (_fullname);

			// Age
			var yearsString = new NSMutableAttributedString ("Age : " + stryears);
			yearsString.SetAttributes (firstAttributes.Dictionary, new NSRange (0, 5));
			yearsString.SetAttributes (secondAttributes.Dictionary, new NSRange ( 6 , stryears.Length ));
			_yearslabel = new UILabel (new CGRect (20, 390 + 1*delta, 540, 30));
			_yearslabel.AttributedText = yearsString;
			Add (_yearslabel);

			// Height
			var heightString = new NSMutableAttributedString ("Height : " + strheight);
			heightString.SetAttributes (firstAttributes.Dictionary, new NSRange (0, 8));
			heightString.SetAttributes (secondAttributes.Dictionary, new NSRange (9, strheight.Length ));
			_heightlabel = new UILabel ( new CGRect (20, 390 + 2*delta, 540, 30));
			_heightlabel.AttributedText = heightString;
			Add (_heightlabel);

			// Weight
			var weightString = new NSMutableAttributedString ("Weight : " + strweight);
			weightString.SetAttributes (firstAttributes.Dictionary, new NSRange (0, 8));
			weightString.SetAttributes (secondAttributes.Dictionary, new NSRange (9, strweight.Length ));
			_weightlabel = new UILabel (new CGRect (20, 390 + 3*delta, 540, 30));
			_weightlabel.AttributedText = weightString;
			Add (_weightlabel);

			// Occupation
			var occupString = new NSMutableAttributedString ("Occupation : " + stroccup);
			occupString.SetAttributes (firstAttributes.Dictionary, new NSRange (0, 12));
			occupString.SetAttributes (secondAttributes.Dictionary, new NSRange (13, stroccup.Length ));
			_occuplabel = new UILabel (new CGRect (20, 390 + 4*delta, 540, 30));
			_occuplabel.AttributedText = occupString;
			Add (_occuplabel);

			// Talent
			var talentString = new NSMutableAttributedString ("Talent/Skills : " + strtalent);
			talentString.SetAttributes (firstAttributes.Dictionary, new NSRange (0, 15));
			talentString.SetAttributes (secondAttributes.Dictionary, new NSRange (16, strtalent.Length ));
			_talentlabel = new UILabel (new CGRect (20, 390 + 5*delta, 540, 30));
			_talentlabel.AttributedText = talentString;
			Add (_talentlabel);

			// Color
			var colorString = new NSMutableAttributedString ("Color (eyes, hair, skill) : " + strcolors);
			colorString.SetAttributes (firstAttributes.Dictionary, new NSRange (0, 27));
			colorString.SetAttributes (secondAttributes.Dictionary, new NSRange (28, strcolors.Length ));
			_colorlabel = new UILabel (new CGRect (20, 390 + 6*delta, 540, 30));
			_colorlabel.AttributedText = colorString;
			Add (_colorlabel);

			// Dressing
			var dressString = new NSMutableAttributedString ("Dressing : " + strdress);
			dressString.SetAttributes (firstAttributes.Dictionary, new NSRange (0, 10));
			dressString.SetAttributes (secondAttributes.Dictionary, new NSRange (11, strdress.Length ));
			_dresslabel = new UILabel (new CGRect (20, 390 + 7*delta, 540, 60));
			_dresslabel.AttributedText = dressString;
			_dresslabel.Lines = 2;
			_dresslabel.LineBreakMode = UILineBreakMode.WordWrap;
			Add (_dresslabel);

			// Personality
			var personString = new NSMutableAttributedString ("Personality : " + strpersonal);
			personString.SetAttributes (firstAttributes.Dictionary, new NSRange (0, 13));
			personString.SetAttributes (secondAttributes.Dictionary, new NSRange (14, strpersonal.Length ));
			_personallabel = new UILabel (new CGRect (20, 390 + 9*delta, 540, 60));
			_personallabel.AttributedText = personString;
			_personallabel.Lines = 2;
			_personallabel.LineBreakMode = UILineBreakMode.WordWrap;
			Add (_personallabel);


		}






		public nfloat ResizeHeigthTextLabel(UILabel label,float maxHeight = 960f) 
		{
			nfloat width =  label.Frame.Width;  
			CGSize size = ((NSString)label.Text).StringSize(label.Font,constrainedToSize:new CGSize(width,maxHeight),
				lineBreakMode:UILineBreakMode.WordWrap);
			var labelFrame = label.Frame;
			label.Lines = (int)(size.Height / label.Font.CapHeight);
			labelFrame.Size = new CGSize(width,size.Height);
			var newHeight = size.Height;
			label.Frame = labelFrame;
			return newHeight;
		}
	}
}

