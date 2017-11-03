namespace BrainOffline.Blast.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadApplication(new BrainOffline.Blast.App());
        }
    }
}