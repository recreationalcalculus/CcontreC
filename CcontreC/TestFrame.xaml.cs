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
        private Dictionary<double, string> testEvents;
        private ViewModels.TestFrameViewModel vm;
        private int currentQuestion = 1;
        private enum testFill { Full, Partial };
        private testFill testFillState;

        public TestFrame()
        {
            this.InitializeComponent();

            testFillState = testFill.Partial;

            vm = new ViewModels.TestFrameViewModel();
            this.DataContext = vm;

            testData = new List<Object>();

            testEvents = new Dictionary<double, string>();

            Q1.SelectionChanged += Q1_SelectionChanged;

            Q2.SelectionChanged += Q2_SelectionChanged;

            RecordEvent("Question 1 Began");
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
            RecordEvent((cb.SelectedIndex+1).ToString()+" fingers selected on " + cb.Name);
            vm.Q1_UpdateScore();
            vm.UpdateScore();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestion == 1)
            {
                RecordEvent("Question 1 Finished");
                Q1.Visibility = Visibility.Collapsed;
                Q1_SubScore.Visibility = Visibility.Collapsed;
                vm.UpdateScore();
                RecordEvent("Question 2 Began");
                Q2.Visibility = Visibility.Visible;
                Q2_SubScore.Visibility = Visibility.Visible;
                currentQuestion++;
            } else
            {
                RecordEvent("Question 2 Finished");
                testData.Add(testEvents);
                this.Frame.Navigate(typeof(ProcessTestData), testData);
            }

        }

        private void RecordEvent(string message)
        {
            double timestamp = DateTime.Now.TimeOfDay.TotalMilliseconds;
            if(testEvents.Count > 0 && timestamp == testEvents.Keys.Last<double>())
            {
                timestamp += .01;
            }
            testEvents.Add(timestamp, message);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            testData.Add(e.Parameter);
        }

        private void toggleTestFillState()
        {
            if(testFillState == testFill.Partial)
            {
                Top.Height = new GridLength(0, GridUnitType.Star);
                Bottom.Height = new GridLength(0, GridUnitType.Star);
                testFillState = testFill.Full;
                FillStateButtonSymbol.Symbol = Symbol.BackToWindow;
            }
            else
            {
                Top.Height = new GridLength(2, GridUnitType.Star);
                Bottom.Height = new GridLength(1, GridUnitType.Star);
                testFillState = testFill.Partial;
                FillStateButtonSymbol.Symbol = Symbol.FullScreen;
            }
        }

        private void FillToggle_Click(object sender, RoutedEventArgs e)
        {
            toggleTestFillState();
        }
    }
}
