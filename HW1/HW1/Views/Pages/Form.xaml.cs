using HW1.ViewModels;

namespace HW1.Views.Pages;

public partial class Form : ContentPage
{
    public Form()
    {
        InitializeComponent();
        BindingContext = new FormViewModel();
    }

    /*
    void OnEntryCompleted(object sender, EventArgs e)
    {
    }

    void OnAgeValueChanged(object sender, ValueChangedEventArgs args)
    {
        var value = Math.Round(args.NewValue);
        
        if (sender != AgeSlider)
            AgeSlider.Value = value;
        if (sender != AgeStepper)
            AgeStepper.Value = value;
        
        AgeLabel.Text = String.Format("Ваш возраст: {0}", value);
    }
    */

    // void OnAgreeSwitchToggled(object sender, ToggledEventArgs args)
    // {
    //     SubmitButton.IsEnabled = args.Value;
    // }
}