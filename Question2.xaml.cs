using MauiApp3.ViewModel;
namespace MauiApp3;

public partial class Question2 : ContentPage
{
	public Question2()
	{
		InitializeComponent();
    }

    private bool isPhoneValid = false;
    private bool isPasswordValid = false;
    private bool isTermsChecked = false;

    // Phone Entry Validation
    private void OnPhoneEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        // Check if the phone number contains only digits and has exactly 10 digits
        if (string.IsNullOrWhiteSpace(PhoneEntry.Text) || !IsValidPhoneNumber(PhoneEntry.Text))
        {
            isPhoneValid = false;
            PhoneErrorLabel.IsVisible = true;
        }
        else
        {
            isPhoneValid = true;
            PhoneErrorLabel.IsVisible = false;
        }

        UpdateRegisterButtonState();
    }

    // Utility: Check if Phone Number Contains Only Digits and is 10 Digits Long
    private bool IsValidPhoneNumber(string phoneNumber)
    {
        // Only digits and exactly 10 digits
        return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\d{10}$");
    }


    // Password Entry Validation
    private void OnPasswordEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        if (PasswordEntry.Text == null || PasswordEntry.Text.Length < 6)
        {
            isPasswordValid = false;
            PasswordErrorLabel.IsVisible = true;
        }
        else
        {
            isPasswordValid = true;
            PasswordErrorLabel.IsVisible = false;
        }

        UpdateRegisterButtonState();
    }

    // Terms and Conditions Checkbox
    private void OnTermsCheckboxChanged(object sender, CheckedChangedEventArgs e)
    {
        isTermsChecked = e.Value;
        UpdateRegisterButtonState();
    }

    // Tap Gesture for Terms and Conditions Label
    private void OnTermsTapped(object sender, EventArgs e)
    {
        TermsCheckbox.IsChecked = !TermsCheckbox.IsChecked;
    }

    // Enable Register Button if All Conditions Are Met
    private void UpdateRegisterButtonState()
    {
        RegisterButton.IsEnabled = isPhoneValid && isPasswordValid && isTermsChecked;
    }

    // Utility: Check if String Is Numeric
    private bool IsNumeric(string text)
    {
        return long.TryParse(text, out _); // Checks if text can be parsed to a number
    }
}