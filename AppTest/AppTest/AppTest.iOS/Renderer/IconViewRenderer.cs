using System;
using System.ComponentModel;
using AppTest;
using Xamarin.Forms;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using AppTest.iOS.Renderer;
using CoreGraphics;

[assembly: ExportRendererAttribute(typeof(IconApp), typeof(IconViewRenderer))]

namespace AppTest.iOS.Renderer
{
    public class IconViewRenderer : ViewRenderer<IconApp, UIImageView>
    {
        private bool _isDisposed;

        protected override void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            if (disposing && base.Control != null)
            {
                UIImage image = base.Control.Image;
                UIImage uIImage = image;
                if (image != null)
                {
                    uIImage.Dispose();
                    uIImage = null;
                }
            }

            _isDisposed = true;
            base.Dispose(disposing);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<IconApp> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                UIImageView uIImageView = new UIImageView(CGRect.Empty)
                {
                    ContentMode = UIViewContentMode.ScaleAspectFit,
                    ClipsToBounds = true
                };
                SetNativeControl(uIImageView);
            }
            if (e.NewElement != null)
            {
                SetImage(e.OldElement);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == IconApp.SourceProperty.PropertyName)
            {
                SetImage(null);
            }
            else if (e.PropertyName == IconApp.ForegroundProperty.PropertyName)
            {
                SetImage(null);
            }
        }

        private void SetImage(IconApp previous = null)
        {
            if (previous == null && !string.IsNullOrWhiteSpace(Element.Source))
            {
                var uiImage = new UIImage(Element.Source);
                uiImage = uiImage.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                Control.TintColor = Element.Foreground.ToUIColor();
                Control.Image = uiImage;
                if (!_isDisposed)
                {
                    ((IVisualElementController)Element).NativeSizeChanged();
                }
            }
        }
    }
}