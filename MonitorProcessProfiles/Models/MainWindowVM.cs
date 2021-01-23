using MonitorProcessProfiles.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorProcessProfiles.Models
{
    class MainWindowVM : INotifyPropertyChanged
    {
        private int normalBrightness;
        public int NormalBrightness
        {
            get { return normalBrightness; }
            set { PropertyChanged.ChangeAndNotify(ref normalBrightness, value, () => NormalBrightness); }
        }

        private int normalContrast;
        public int NormalContrast
        {
            get { return normalContrast; }
            set { PropertyChanged.ChangeAndNotify(ref normalContrast, value, () => NormalContrast); }
        }

        private int gamingBrightness;
        public int GamingBrightness
        {
            get { return gamingBrightness; }
            set { PropertyChanged.ChangeAndNotify(ref gamingBrightness, value, () => GamingBrightness); }
        }

        private int gamingContrast;
        public int GamingContrast
        {
            get { return gamingContrast; }
            set { PropertyChanged.ChangeAndNotify(ref gamingContrast, value, () => GamingContrast); }
        }

        private List<string> processes;
        public List<string> Processes
        {
            get { return processes; }
            set { PropertyChanged.ChangeAndNotify(ref processes, value, () => Processes); }
        }

        public event PropertyChangedEventHandler PropertyChanged;        

        public MainWindowVM()
        {
            Processes = new List<string>();
        }
    }
}
