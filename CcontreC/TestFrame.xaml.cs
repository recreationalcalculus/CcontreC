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
    public sealed partial class TestFrame : Page
    {
        private List<Object> testData;
        private List<decimal> subTestScores;
        private int clicks = 0;

        public TestFrame()
        {
            this.InitializeComponent();
            SubScore.DataContext = Q1.DataContext;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (clicks == 0)
            {
                Q1.Visibility = Visibility.Collapsed;
                subTestScores.Add(decimal.Parse(SubScore.Text));
                Q2.Visibility = Visibility.Visible;
                SubScore.DataContext = Q2.DataContext;
                clicks++;
            } else
            {

            }

        }

        
    }
}
