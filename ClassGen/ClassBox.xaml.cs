using ClassGen.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ClassGen
{
    public sealed partial class ClassBox : UserControl
    {
        public Class ThisClass {get;set;}
        public SolidColorBrush BackgroundColor { get; set; }
        public ClassBox()
        {
            ThisClass = new Class();
            this.InitializeComponent();
        }

        public ClassBox(Class theClass,Color background)
        {
            ThisClass = theClass;
            background.A = 50;
            BackgroundColor = new SolidColorBrush(background);
            this.InitializeComponent();
        }

        private void UserControl_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }

        Compositor _compositor = Window.Current.Compositor;
        SpringVector3NaturalMotionAnimation _springAnimation;

        private void CreateOrUpdateSpringAnimation(float finalValue)
        {
            if (_springAnimation == null)
            {
                _springAnimation = _compositor.CreateSpringVector3Animation();
                _springAnimation.Target = "Scale";
            }

            _springAnimation.FinalValue = new Vector3(finalValue);
        }

        private void element_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            // Scale up to 1.5
            Canvas.SetZIndex(this, 10);
            ElementSoundPlayer.Play(ElementSoundKind.Focus);
            CreateOrUpdateSpringAnimation(1.5f);
           
            try
            {
                (sender as UIElement).StartAnimation(_springAnimation);
            
            }
            catch (Exception)
            {

           
            }
           
        }

        private void element_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Canvas.SetZIndex(this, 1);
            try
            {
                // Scale back down to 1.0
                CreateOrUpdateSpringAnimation(1.0f);

                (sender as UIElement).StartAnimation(_springAnimation);
            }
            catch (Exception)
            {

             
            }
         
        }
    }
}
