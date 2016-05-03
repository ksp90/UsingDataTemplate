using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingDataTemplate
{
    public class SampleViewModel : INotifyPropertyChanged
    {
        ObservableCollection<SampleModel> _Data;
        public ObservableCollection<SampleModel> Data
        {
            get { return _Data; }

            set { _Data = value; RaiseChange(nameof(Data)); }
        }
        public int DataCount
        {
            get { return _Data?.Count - 1 ?? 0; }
        }

        public SampleViewModel()
        {
            List<SampleModel> sampleData = new List<SampleModel>();
            sampleData.Add(new SampleModel { Header = "Item1", Content = "Content1" });
            sampleData.Add(new SampleModel { Header = "Item2", Content = "Content2" });
            sampleData.Add(new SampleModel { Header = "Item3", Content = "Content3" });
            Data = new ObservableCollection<SampleModel>(sampleData);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaiseChange(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
