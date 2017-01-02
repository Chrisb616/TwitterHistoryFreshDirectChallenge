﻿using System;
using UIKit;
using Foundation;
namespace TwitterHistory
{
	public class TwitterUserInfoView : UIView
	{
		UIImageView ProfilePictureImageView = new UIImageView();
		UIView UsernameTopDivider = new UIView();
		UILabel UsernameLabel = new UILabel();
		UILabel UserFullNameLabel = new UILabel();
		UILabel LocationLabel = new UILabel();


		public void InitialSetUp()
		{

			this.Layer.CornerRadius = 3;
			this.BackgroundColor = UIColor.White;


			this.AddSubview(UsernameTopDivider);
			UsernameTopDivider.BackgroundColor = Constants.TwitterBlue;
			UsernameTopDivider.Layer.CornerRadius = 3;
			UsernameTopDivider.Frame = CoreGraphics.CGRect.FromLTRB(
				0,
				0,
				this.Frame.Width,
				this.Frame.Height * 0.3f
			);
			this.AddSubview(ProfilePictureImageView);
			ProfilePictureImageView.BackgroundColor = Constants.TwitterBlue;
			ProfilePictureImageView.Frame = CoreGraphics.CGRect.FromLTRB(
				0,
				0,
				this.Frame.Height,
				this.Frame.Height
			);
			ProfilePictureImageView.Layer.CornerRadius = 3;

			this.AddSubview(UsernameLabel);
			UsernameLabel.TextColor = UIColor.White;
			UsernameLabel.Frame = CoreGraphics.CGRect.FromLTRB(
				ProfilePictureImageView.Frame.Right + 10f,
				UsernameTopDivider.Frame.Top,
				UsernameTopDivider.Frame.Right,
				UsernameTopDivider.Frame.Bottom
			);
			UsernameLabel.Font = UIFont.FromName("HelveticaNeue", 16f);

			this.AddSubview(UserFullNameLabel);
			UserFullNameLabel.Frame = CoreGraphics.CGRect.FromLTRB(
				UsernameLabel.Frame.Left,
				UsernameLabel.Frame.Bottom,
				UsernameLabel.Frame.Right,
				this.Frame.Height * 0.6f
			);
			UserFullNameLabel.Font = UIFont.FromName("HelveticaNeue", 16f);

			this.AddSubview(LocationLabel);
			LocationLabel.Frame = CoreGraphics.CGRect.FromLTRB(
				UserFullNameLabel.Frame.Left,
				UserFullNameLabel.Frame.Bottom,
				UserFullNameLabel.Frame.Right,
				this.Frame.Height * 0.8f
			);
			LocationLabel.Font = UIFont.FromName("HelveticaNeue", 12f);

		}
		public void SetupForUser(User user)
		{
			NSOperationQueue.MainQueue.AddOperation(() =>
			{
				UsernameLabel.Text = "@" + user.screen_name;
				UserFullNameLabel.Text = user.name;
				LocationLabel.Text = user.location;
			});
			
		}
		public void UpdateProfileImage(UIImage ProfileImage)
		{
			NSOperationQueue.MainQueue.AddOperation(() =>
			{
				ProfilePictureImageView.Image = ProfileImage;
			});
		}
		public void clearInfo()
		{
			UsernameLabel.Text = "";
			UserFullNameLabel.Text = "";
			LocationLabel.Text = "";
		}
	}
}