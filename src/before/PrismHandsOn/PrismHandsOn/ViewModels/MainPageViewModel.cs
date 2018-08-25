using System;
using Prism.Mvvm;
using System.Windows.Input;
using Xamarin.Forms;
using Prism.Navigation;

namespace PrismHandsOn.ViewModels
{
  public class MainPageViewModel : BindableBase
  {
    public string _message = "Hello, Prism for Xamarin Forms!";
    private readonly INavigationService _navigationService;

    public MainPageViewModel(INavigationService navigationService)
    {
      _navigationService = navigationService;
    }

    public string Message
    {
      get => _message;
      set => SetProperty(ref _message, value);
    }

    public ICommand AppearingCommand => new Command(
      () => Message = $"Appearing on {DateTime.Now}"
    );

    public ICommand UpdateMessageCommand => new Command(
      () => Message = $"Updated on {DateTime.Now}"
    );

    public Command<string> NavigateCommand =>
    new Command<string>(
      name => _navigationService.NavigateAsync(name)
    );
  }
}
