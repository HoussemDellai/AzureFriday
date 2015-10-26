using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using Xamarin.Forms;

namespace AzureFriday.Droid
{
	[Activity (Label = "Videos", 
        ScreenOrientation = ScreenOrientation.Landscape)]			
	public class VideoPlayerActivity : Activity
	{
	    protected override void OnPostCreate(Bundle savedInstanceState)
	    {
            MessagingCenter.Subscribe<string, string>(this, "Hi", (sender, arg) =>
            {
                // do something whenever the "Hi" message is sent
                // using the 'arg' parameter which is a string
                PlayVideo(arg);
            });

            base.OnPostCreate(savedInstanceState);
	    }

	    protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.VideoPlayerLayout);

            //var button = FindViewById<Button> (Resource.Id.myButton);

            //button.Click += (sender, e) => {
            //	Finish(); // back to the previous activity
            //};
        }

	    private void PlayVideo(string videoUri)
	    {
            var videoView = FindViewById<VideoView>(Resource.Id.MainVideoView);

            var uri = Android.Net.Uri.Parse(videoUri);

            videoView.SetVideoURI(uri);

            // doc : http://code.tutsplus.com/tutorials/streaming-video-in-android-apps--cms-19888
            var mediaController = new MediaController(this);

            mediaController.SetAnchorView(videoView);

            videoView.SetMediaController(mediaController);

            videoView.Start();
        }
	}
}

