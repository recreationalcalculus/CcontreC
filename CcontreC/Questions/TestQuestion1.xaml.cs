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
    public sealed partial class TestQuestion1 : UserControl
    {
        Models.QuestionModel question;
       

        public TestQuestion1()
        {
            this.InitializeComponent();
            question = new Models.QuestionModel("Test Question 1");
            question.Score = 13m;

            this.DataContext = question;
        }

        public void UpdateScore()
        {
            decimal ans1, ans2, ans3;
            decimal.TryParse((string)FirstTrial.SelectionBoxItem, out ans1);
            decimal.TryParse((string)SecondTrial.SelectionBoxItem, out ans2);
            decimal.TryParse((string)ThirdTrial.SelectionBoxItem, out ans3);

            question.Score = Math.Floor((100*(ans1 + ans2 + ans3) / 3))/100;
        }

        private void FirstTrial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            question.RecordEvent("First Trial, " + (string)FirstTrial.SelectionBoxItem + " chosen.");
            UpdateScore();
        }

        private void SecondTrial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            question.RecordEvent("Second Trial, " + (string)SecondTrial.SelectionBoxItem + " chosen.");
            UpdateScore();
        }

        private void ThirdTrial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            question.RecordEvent("Third Trial, " + (string)ThirdTrial.SelectionBoxItem + " chosen.");
            UpdateScore();
        }
    }
}
