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
                // do something whenever the "Hi" message is sent
                // using the 'arg' parameter which is a string
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

        //protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        //{
        //    base.OnElementChanged(e);

        //    if (e.OldElement == null)
        //    {
        //        if (_videoLink != null)
        //        {
        //            var me = new MediaElement
        //            {
        //                AutoPlay = true,
        //                Source = new Uri(_videoLink)
        //            };

        //            (ContainerElement as Canvas).Children.Add(me);
        //        }
        //        //me.IsFullWindow = true;
        //        //me.AreTransportControlsEnabled = true;

        //    }
        //}
    }
}