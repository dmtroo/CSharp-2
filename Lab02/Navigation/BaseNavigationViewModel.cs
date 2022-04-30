using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ProgrammingInCSharp.Lab02.Navigation
{
    internal abstract class BaseNavigationViewModel : INotifyPropertyChanged
    {

        #region Fields

        List<INavigatable> _viewModels = new();
        private INavigatable _currentViewModel;

        #endregion

        #region Commands

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties
        public INavigatable CurrentViewModel
        {
            get => _currentViewModel;

            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        #endregion

        internal void Navigate(MainNavigationTypes type)
        {
            if (CurrentViewModel != null && CurrentViewModel.ViewType.Equals(type))
                return;

            INavigatable viewModel = GetViewModel(type);

            if (viewModel == null)
                return;
            
            CurrentViewModel = viewModel;
        }

        private INavigatable GetViewModel(MainNavigationTypes type)
        {
            INavigatable viewModel = _viewModels.FirstOrDefault(viewModel => viewModel.ViewType == type);

            if (viewModel != null)
                return viewModel;

            viewModel = CreateViewModel(type);

            _viewModels.Add(viewModel);

            return viewModel;
        }

        protected abstract INavigatable CreateViewModel(MainNavigationTypes type);

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    enum MainNavigationTypes
    {
        SignIn = 1,
        Main = 2,
    }
}