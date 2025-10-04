using System.ComponentModel;
using System.Runtime.CompilerServices;
using HW1.Models;
using HW1.Models.Enums;

namespace HW1.ViewModels;

public class FormViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public Command SubmitCommand { get; }
    
    private UserForm userForm = new();
    private bool isFormValid;
    private Color phoneColor = Colors.Red;

    public FormViewModel()
    {
        SubmitCommand = new Command(ExecuteSubmit, () => IsSubmitEnabled);
        PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(IsSubmitEnabled)) 
                SubmitCommand.ChangeCanExecute();
        };
    }
    
    public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    public string LastName
    {
        get => userForm.LastName;
        set
        {
            userForm.LastName = value;
            OnPropertyChanged();
            ValidateForm();
        }
    }
    
    public string FirstName
    {
        get => userForm.FirstName;
        set
        {
            userForm.FirstName = value;
            OnPropertyChanged();
            ValidateForm();
        }
    }
    
    public string MiddleName
    {
        get => userForm.MiddleName;
        set
        {
            userForm.MiddleName = value;
            OnPropertyChanged();
        }
    }
    
    public double Age
    {
        get => userForm.Age;
        set
        {
            userForm.Age = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(AgeDisplayText));
            ValidateForm();
        }
    }
    
    public string PhoneNumber
    {
        get => userForm.PhoneNumber;
        set
        {
            userForm.PhoneNumber = value;
            OnPropertyChanged();
            UpdatePhoneColor();
            ValidateForm();
        }
    }
    
    public Gender Gender
    {
        get => userForm.Gender;
        set
        {
            userForm.Gender = value;
            OnPropertyChanged();
            ValidateForm();
        }
    }
    
    public bool IsAgreed
    {
        get => userForm.IsAgreed;
        set
        {
            userForm.IsAgreed = value;
            OnPropertyChanged();
            ValidateForm();
        }
    }
    
    public Color PhoneColor
    {
        get => phoneColor;
        set
        {
            if (phoneColor != value)
            {
                phoneColor = value;
                OnPropertyChanged();
            }
        }
    }
    
    public string AgeDisplayText => $"Ваш возраст: {Math.Round(Age)}";
    
    public bool IsSubmitEnabled => isFormValid && IsAgreed;
    
    private void ValidateForm()
    {
        isFormValid = !string.IsNullOrWhiteSpace(LastName) &&
                      !string.IsNullOrWhiteSpace(FirstName) &&
                      !string.IsNullOrWhiteSpace(PhoneNumber) && 
                      Age is >= 1 and <= 100 &&
                      Gender != Gender.None &&
                      PhoneNumber.Length == 10;
        
        OnPropertyChanged(nameof(IsSubmitEnabled));
    }

    private async void ExecuteSubmit()
    {
        ResetForm();
        await Application.Current.MainPage.DisplayAlert("Поздравляем!", "Форма отправлена", "Ok");
    }
    
    private void ResetForm()
    {
        LastName = string.Empty;
        FirstName = string.Empty;
        MiddleName = string.Empty;
        Age = 0;
        PhoneNumber = string.Empty;
        Gender = Gender.None;
        IsAgreed = false;
        PhoneColor = Colors.Red;
    }

    private void UpdatePhoneColor()
    {
        if (string.IsNullOrEmpty(PhoneNumber))
        {
            PhoneColor = Colors.Red;
        }
        else if (PhoneNumber.Length == 10)
        {
            PhoneColor = Colors.Green;
        }
        else
        {
            PhoneColor = Colors.Red;
        }
    }
}