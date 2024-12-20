using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Input;


namespace MauiApp3.ViewModel
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private string phoneNumber;
        private string password;
        private bool isTermsChecked;
        private bool isRegisterButtonEnabled;

        public event PropertyChangedEventHandler PropertyChanged;
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if (phoneNumber != value)
                {
                    phoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                    CheckRegisterButtonState();
                }
            }
        }

        public string Password
        {
            get => password;
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged(nameof(Password));
                    CheckRegisterButtonState();
                }
            }
        }

        public bool IsTermsChecked
        {
            get => isTermsChecked;
            set
            {
                if (isTermsChecked != value)
                {
                    isTermsChecked = value;
                    OnPropertyChanged(nameof(IsTermsChecked));
                    CheckRegisterButtonState();
                }
            }
        }

        public bool IsRegisterButtonEnabled
        {
            get => isRegisterButtonEnabled;
            set
            {
                if (isRegisterButtonEnabled != value)
                {
                    isRegisterButtonEnabled = value;
                    OnPropertyChanged(nameof(IsRegisterButtonEnabled));
                }
            }
        }

        private void CheckRegisterButtonState()
        {
            IsRegisterButtonEnabled = IsPhoneNumberValid() && IsPasswordValid() && IsTermsChecked;
        }

        private bool IsPhoneNumberValid()
        {
            return Regex.IsMatch(PhoneNumber, @"^\d+$");
        }

        private bool IsPasswordValid()
        {
            return Password.Length >= 6;
        }

        public ICommand ToggleTermsCheckedCommand => new Command(() =>
        {
            IsTermsChecked = !IsTermsChecked;
        });

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
