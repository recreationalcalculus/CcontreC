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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace CcontreC.Questions
{
    public sealed partial class TestQuestion2 : UserControl
    {
        Models.QuestionModel question;

        public TestQuestion2()
        {
            this.InitializeComponent();

            question = new Models.QuestionModel("Test Question 2");
            question.Score = 14m;

            this.DataContext = question;
        }

        public void UpdateScore()
        {
            if((bool)Correct.IsChecked)
            {
                question.Score = 5m;
            } else if((bool)OffByOne.IsChecked)
            {
                question.Score = 2m;
            } else
            {
                question.Score = 0m;
            }
        }

        private void Correct_Click(object sender, RoutedEventArgs e)
        {
            question.RecordEvent("Responded Correctly");
            UpdateScore();
        }

        private void OffByOne_Click(object sender, RoutedEventArgs e)
        {
            question.RecordEvent("Off by one");
            UpdateScore();
        }

        private void Off_Click(object sender, RoutedEventArgs e)
        {
            question.RecordEvent("Off by more than one");
            UpdateScore();
        }
    }
}
