using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CcontreC.ViewModels
{
    class TestFrameViewModel : INotifyPropertyChanged
    {
        private decimal score;
        public decimal Score
        {
            get { return score; }
            set
            {
                score = value;
                NotifyPropertyChanged("Score");
            }

        }

        private decimal q1_score;
        public decimal Q1_Score
        {
            get { return q1_score; }
            set
            {
                q1_score = value;
                NotifyPropertyChanged("Q1_Score");
            }
        }

        public Dictionary<string, decimal> Q1_SubScores;

        private decimal q2_score;
        public decimal Q2_Score
        {
            get { return q2_score; }
            set
            {
                q2_score = value;
                NotifyPropertyChanged("Q2_Score");
            }
        }




        public TestFrameViewModel()
        {
            Q1_SubScores = new Dictionary<string, decimal>();
            Q1_SubScores.Add("FirstTrial", 0m);
            Q1_SubScores.Add("SecondTrial", 0m);
            Q1_SubScores.Add("ThirdTrial", 0m);
            Q1_UpdateScore();

            Q2_Score = 0m;
            UpdateScore();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        public void UpdateScore()
        {
            Score = Math.Floor(100*((Q1_Score + Q2_Score) / 2)) / 100;
        }

        public void Q1_UpdateScore()
        {
            decimal val = (Q1_SubScores["FirstTrial"] + Q1_SubScores["SecondTrial"] + Q1_SubScores["ThirdTrial"]) / 3;
            Q1_Score = Math.Floor(100 * val) / 100;
        }

        public void Q2_UpdateScore()
        {

        }

    }
}
