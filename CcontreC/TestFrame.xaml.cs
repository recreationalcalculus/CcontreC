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
        private ViewModels.TestFrameViewModel vm;
        private int currentQuestion = 1;

        public TestFrame()
        {
            this.InitializeComponent();

            vm = new ViewModels.TestFrameViewModel();
            this.DataContext = vm;

            testData = new List<Object>();

            Q1.SelectionChanged += Q1_SelectionChanged;

            Q2.SelectionChanged += Q2_SelectionChanged;
        }

        private void Q2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            switch (cb.SelectedIndex)
            {
                case 0:
                    vm.Q2_Score = 5m; //correct day
                    break;
                case 1:
                    vm.Q2_Score = 3m; //off by one
                    break;
                default:
                    vm.Q2_Score = 0m; //off by more than one
                    break;
            }

            vm.UpdateScore();
        }

        private void Q1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            vm.Q1_SubScores[cb.Name] = cb.SelectedIndex + 1m;
            vm.Q1_UpdateScore();
            vm.UpdateScore();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestion == 1)
            {
                Q1.Visibility = Visibility.Collapsed;
                Q1_SubScore.Visibility = Visibility.Collapsed;
                //testData.Add(vm.q1.EventRecord);
                vm.UpdateScore();
                Q2.Visibility = Visibility.Visible;
                Q2_SubScore.Visibility = Visibility.Visible;
                currentQuestion++;
            } else
            {

            }

        }

    }
}
