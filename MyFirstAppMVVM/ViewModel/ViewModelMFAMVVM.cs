using System.ComponentModel;
using System.Windows.Input;

namespace MyFirstAppMVVM.ViewModel
{
    using Model;
    public class ViewModelMFAMVVM : INotifyPropertyChanged
    {
        private ModelMyFirstAppMVVM model = FileHelper.Read();

        public double Value
        {
            get
            {
                return model.Value;
            }

            set
            {
                model.Value = value;
                onPropertyChanged(nameof(Value));
                model.Save();
            }
        }

        private ICommand rest = null;

        public ICommand Rest
        {
            get
            {
                if (rest == null) rest = new RelayCommand(
                    (object o) =>
                    {
                        model.Rest();
                        onPropertyChanged(nameof(Value));
                    },
                    (object o) =>
                    {
                        return model.Value > 0;
                    });
                return rest;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void onPropertyChanged(string nameProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameProperty));
        }

    }
    
}
