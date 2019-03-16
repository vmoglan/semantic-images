using Prokim.Service.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Prokim.View.Navigation
{
    public class FrameNavigationService : IFrameNavigationService, INotifyPropertyChanged
    {
        private readonly Dictionary<string, Uri> _pages;
        private readonly Stack<string> _history;

        public object Parameter => throw new System.NotImplementedException();

        public string CurrentPageKey => throw new System.NotImplementedException();

        public event PropertyChangedEventHandler PropertyChanged;

        public void GoBack()
        {
            throw new System.NotImplementedException();
        }

        public void NavigateTo(string pageKey)
        {
            throw new System.NotImplementedException();
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            throw new System.NotImplementedException();
        }
    }
}
