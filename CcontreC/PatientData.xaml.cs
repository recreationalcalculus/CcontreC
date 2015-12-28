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
    public sealed partial class PatientData : Page
    {
        private Dictionary<string, Models.PatientDataModel.ConcussionStatus> conc_dic;
        private Dictionary<string, Models.PatientDataModel.Races> race_dic;
        private Dictionary<string, Models.PatientDataModel.SexOptions> sex_dic;
        
        public PatientData()
        {
            this.InitializeComponent();

            conc_dic = new Dictionary<string, Models.PatientDataModel.ConcussionStatus>();
            conc_dic.Add("Suspected", Models.PatientDataModel.ConcussionStatus.Suspected);
            conc_dic.Add("Not Suspected", Models.PatientDataModel.ConcussionStatus.NotSuspected);
            conc_dic.Add("Confirmed", Models.PatientDataModel.ConcussionStatus.Confirmed);

            race_dic = new Dictionary<string, Models.PatientDataModel.Races>();
            race_dic.Add("White", Models.PatientDataModel.Races.White);
            race_dic.Add("Black", Models.PatientDataModel.Races.Black);
            race_dic.Add("Hispanic", Models.PatientDataModel.Races.Hispanic);
            race_dic.Add("Asian", Models.PatientDataModel.Races.Asian);
            race_dic.Add("Other", Models.PatientDataModel.Races.Other);

            sex_dic = new Dictionary<string, Models.PatientDataModel.SexOptions>();
            sex_dic.Add("Male", Models.PatientDataModel.SexOptions.Male);
            sex_dic.Add("Female", Models.PatientDataModel.SexOptions.Female);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int age = int.Parse((string)Age_Tens.SelectionBoxItem) * 10 + int.Parse((string)Age_Ones.SelectionBoxItem);
            Models.PatientDataModel.SexOptions sex = sex_dic[(string)Sex.SelectionBoxItem];
            int weight = int.Parse(Weight.Text);
            int height = int.Parse(Height_Feet.Text) * 12 + int.Parse(Height_Inches.Text);
            Models.PatientDataModel.Races race = race_dic[(string)Race.SelectionBoxItem];
            Models.PatientDataModel.ConcussionStatus concussed = conc_dic[(string)Concussed.SelectionBoxItem];

            Models.PatientDataModel patient = new Models.PatientDataModel
            {
                Age = age,
                HeightInInches = height,
                WeightInPounds = weight,
                Race = race,
                Sex = sex,
                Concussion = concussed
            };

            this.Frame.Navigate(typeof(TestFrame), patient);
        }
    }
}
