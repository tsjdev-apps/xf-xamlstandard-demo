using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using RandomUserSharp;
using RandomUserSharp.Models;
using Xamarin.Forms;

namespace XamlStandardDemo.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly RandomUserClient _randomUserClient;

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; OnPropertyChanged(); }
        }

        private List<User> _users;
        public List<User> Users
        {
            get => _users;
            set { _users = value; OnPropertyChanged(); }
        }

        public MainViewModel()
        {
            _randomUserClient = new RandomUserClient();
        }

        private ICommand _getUserCommand;
        
        public ICommand GetUserCommand => _getUserCommand ?? (_getUserCommand = new Command(async () => await GetUser()));

        private async Task GetUser()
        {
            IsLoading = true;

            try
            {
                Users = await _randomUserClient.GetRandomUsersAsync(20);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"MainViewModel | GetUser | {ex}");
                Users = null;
            }
            finally
            {
                IsLoading = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
