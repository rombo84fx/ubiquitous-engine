using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TheSimpleCanvasUWP
{
    public class SimpleCanvas : Panel
    {
        public static double GetTop(DependencyObject obj)
        {
            return (double)obj.GetValue(TopProperty);
        }

        public static void SetTop(DependencyObject obj, double value)
        {
            obj.SetValue(TopProperty, value);
        }

        // Using a DependencyProperty as the backing store for Top.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TopProperty =
            DependencyProperty.RegisterAttached("Top", 
                typeof(double), 
                typeof(SimpleCanvas), 
                new PropertyMetadata(0.0, OnTopPropertyChanged));

        private static void OnTopPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is FrameworkElement child)) return;
            var parent = (SimpleCanvas)child.Parent;
            parent?.InvalidateArrange(); 
            parent?.UpdateLayout();
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (UIElement child in Children)
            {
                child.Measure(availableSize);
            }
            return base.MeasureOverride(availableSize);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var location = new Point();
            foreach (UIElement child in Children)
            {
                location.Y = GetTop(child);
                child.Arrange(new Rect(location, child.DesiredSize));
            }
            return base.ArrangeOverride(finalSize);
        }
    }
}