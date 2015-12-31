using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CcontreC
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProcessTestData : Page
    {

        private object testData;

        private IRepository remoteRepository;
        private IRepository localRepository;

        public ProcessTestData()
        {
            this.InitializeComponent();

            localRepository = new Repositories.LocalRepository();

        }

        private void Discard_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), null);
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            await localRepository.Save(testData);
            Save.Content = "Saved!";
            Save.IsEnabled = false;
            Discard.Content = "New Test";
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            testData = e.Parameter;
            TestData.Text = JsonConvert.SerializeObject(testData);
        }

    }
}
