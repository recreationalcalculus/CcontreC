using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CcontreC.Models
{
    public class QuestionModel : INotifyPropertyChanged
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
        public Dictionary<long, string> EventRecord;

        public QuestionModel(string questionName = "unnamed question")
        {
            Score = -1m;
            EventRecord = new Dictionary<long, string>();
            RecordEvent(questionName + " object created");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        public void RecordEvent(string e)
        {
            EventRecord.Add((long)DateTime.Now.TimeOfDay.TotalMilliseconds, e);
        }
    }
}
