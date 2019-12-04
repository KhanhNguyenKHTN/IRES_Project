using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IRES_Project.Controls.Pages
{
    public class MultiContentPages : ContentPage
    {
        public List<object> ListPages { get; set; }

        public int DisplayIndex = 0;

        private Waitting waiting { get; set; }
        private Grid mainGrid { get; set; }
        public bool IsLoading { get { return waiting.IsVisible; } set { waiting.IsVisible = value; if (value == true) { mainGrid.Children.Clear(); mainGrid.BackgroundColor = Color.White; } } }

        private static MultiContentPages _Instance;

        public static MultiContentPages Instance
        {
            get
            {
                if (_Instance == null) _Instance = new MultiContentPages();
                return _Instance;
            }
        }
        private MultiContentPages()
        {
            waiting = new Waitting() { IsVisible = true };
            Grid grid = new Grid();
            mainGrid = new Grid();
            grid.Children.Add(mainGrid);
            grid.Children.Add(waiting);
            this.Content = grid;
            ListPages = new List<object>();
            DisplayIndex = -1;
            //loadMainContent(action);
        }

        public async void PushPage(BackgroundWorker action)
        {
            await Task.Delay(500);
            IsLoading = true;
            action.RunWorkerCompleted += (s, e) =>
            {
                ListPages.Add(e.Result);
                DisplayIndex = ListPages.Count - 1;
                setDisplayPage();
                IsLoading = false;
            };
            action.RunWorkerAsync();
        }

        internal async void PopModalAsync()
        {
            await Navigation.PopModalAsync();
        }

        private void setDisplayPage()
        {
            if (DisplayIndex == -1) return;
            mainGrid.Children.Clear();
            mainGrid.Children.Add(ListPages[DisplayIndex] as ContentView);
        }

        public void BackPage()
        {
            if (DisplayIndex < 1) return;
            DisplayIndex--;
            setDisplayPage();
        }
        public void PopPage()
        {
            if (DisplayIndex < 1) return;
            ListPages.Remove(ListPages[ListPages.Count - 1]);
            DisplayIndex--;
            setDisplayPage();
        }
        public void ClearAll()
        {
            if (ListPages == null || ListPages.Count == 0) return;
            IsLoading = true;
            //mainGrid.Children.Clear();
            //mainGrid.BackgroundColor = Color.White;
            ListPages.Clear();
        }
        
    }
}
