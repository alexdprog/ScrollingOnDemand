using Xamarin.Forms;
//using Xamarin.Forms.Xaml;

namespace ScrollingOnDemand.Views
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Frame_SizeChanged(object sender, System.EventArgs e)
        {
            ScrollView scrollView = contentView.scrollView;
            ContentView meter = (ContentView)sender;
            var yCoord = meter.Y; VisualElement parent = (VisualElement)meter.Parent; while (parent != contentView) { yCoord +=parent.Y; parent = (VisualElement)parent.Parent; }
            if (yCoord + meter.Height > scrollView.ScrollY + scrollView.Height)
            {
                scrollView.ScrollToAsync(meter, ScrollToPosition.MakeVisible, true);
            }
        }
    }
}
