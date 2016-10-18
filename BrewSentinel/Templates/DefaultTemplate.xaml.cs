using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace BrewSentinel.Templates
{
    public sealed partial class DefaultTemplate : UserControl
    {
        public DefaultTemplate()
        {
            this.InitializeComponent();
        }      

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(object), typeof(DefaultTemplate), new PropertyMetadata(null));

        public object Title
        {
            get { return GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty MainProperty = DependencyProperty.Register("Main", typeof(object), typeof(DefaultTemplate), new PropertyMetadata(null));

        public object Main
        {
            get { return GetValue(MainProperty); }
            set { SetValue(MainProperty, value); }
        }

        public static readonly DependencyProperty FooterProperty = DependencyProperty.Register("Footer", typeof(object), typeof(DefaultTemplate), new PropertyMetadata(null));

        public object Footer
        {
            get { return GetValue(FooterProperty); }
            set { SetValue(FooterProperty, value); }
        }
    }
}
