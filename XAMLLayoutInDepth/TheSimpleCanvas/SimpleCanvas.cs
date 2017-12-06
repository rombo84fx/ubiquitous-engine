using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;

namespace TheSimpleCanvas
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
                new FrameworkPropertyMetadata(0.0, 
                    FrameworkPropertyMetadataOptions.AffectsParentArrange));

        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (UIElement child in InternalChildren)
            {
                child.Measure(availableSize);
            }
            return base.MeasureOverride(availableSize);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            var location = new Point();
            foreach (UIElement child in InternalChildren)
            {
                location.Y = GetTop(child);
                child.Arrange(new Rect(location, child.DesiredSize));
            }
            return base.ArrangeOverride(finalSize);
        }
    }
}