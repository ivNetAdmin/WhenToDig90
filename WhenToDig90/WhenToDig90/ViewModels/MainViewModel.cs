using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace WhenToDig90.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The <see cref="ClickCount" /> property's name.
        /// </summary>
        public const string ClickCountPropertyName = "ClickCount";

        private int _clickCount;

        /// <summary>
        /// Sets and gets the ClickCount property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ClickCount
        {
            get
            {
                return _clickCount;
            }
            set
            {
                if (Set(() => ClickCount, ref _clickCount, value))
                {
                    RaisePropertyChanged(() => ClickCountFormatted);
                }
            }
        }

        public string ClickCountFormatted
        {
            get
            {
                return string.Format("The button was clicked {0} time(s)", ClickCount);
            }
        }

        private RelayCommand _incrementCommand;

        /// <summary>
        /// Gets the IncrementCommand.
        /// </summary>
        public RelayCommand IncrementCommand
        {
            get
            {
                return _incrementCommand
                    ?? (_incrementCommand = new RelayCommand(
                    () =>
                    {
                        ClickCount++;
                    }));
            }
        }
    }
}
