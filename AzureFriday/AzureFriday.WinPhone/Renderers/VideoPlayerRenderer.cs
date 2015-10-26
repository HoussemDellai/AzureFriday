using System;
using System.Windows.Controls;
using AzureFriday.Views;
using AzureFriday.WinPhone.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(VideoPlayerView), typeof(VideoPlayerRenderer))]

namespace AzureFriday.WinPhone.Renderers
{

    public class VideoPlayerRenderer : PageRenderer
    {
        public VideoPlayerRenderer()
        {
            MessagingCenter.Subscribe<string, string>(this, "Hi", (sender, videoLink) =>
            {
                PlayVideo(videoLink);
            });
        }

        private void PlayVideo(string videoLink)
        {
            if (videoLink != null)
            {
                var me = new MediaElement
                {
                    AutoPlay = true,
                    Source = new Uri(videoLink),
                    
                };

                (ContainerElement as Canvas).Children.Add(me);
            }
        }
    }
}