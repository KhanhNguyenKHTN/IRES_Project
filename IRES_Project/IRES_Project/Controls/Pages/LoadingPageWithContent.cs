using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IRES_Project.Controls.Pages
{
    public class LoadingPageWithContent: ContentPage
    {
        public object ContentView { get; set; }

        private Waitting waiting { get; set; }
        private Grid mainGrid { get; set; }
        public bool IsLoading { get { return waiting.IsVisible; } set { waiting.IsVisible = value; } }
        public LoadingPageWithContent(BackgroundWorker action)
        {
            waiting = new Waitting() { IsVisible = true };
            mainGrid = new Grid();
            mainGrid.Children.Add(waiting);
            this.Content = mainGrid;
            loadMainContent(action);
        }

        private async void loadMainContent(BackgroundWorker action)
        {
            await Task.Delay(500);
            action.RunWorkerCompleted += (s, e) =>
            {
                mainGrid.Children.Add(e.Result as ContentView);
                IsLoading = false;
            };
            action.RunWorkerAsync();
        }
        
    }
}
