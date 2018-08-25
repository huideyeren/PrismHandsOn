using System;
using System.Reflection;
using Prism.Mvvm;
using Xamarin.Forms;
using Prism.Navigation;
using System.Windows.Input;
using PrismHandsOn.Views;
using PrismHandsOn.Models;

namespace PrismHandsOn.ViewModels
{
  public class SelectedItemPageViewModel : BindableBase, INavigatingAware
  {
    private readonly INavigationService _navigationService;

    private readonly ITextToSpeechService _textToSpeechService;

    private string _colorName;

    private Color _color;

    public string ColorName
    {
      get => _colorName;
      set => SetProperty(ref _colorName, value);
    }

    public Color Color
    {
      get => _color;
      set => SetProperty(ref _color, value);
    }

    public void OnNavigatingTo(NavigationParameters parameters)
    {
      ColorName = (string)parameters["colorName"];
      Color = (Color)typeof(Color).GetRuntimeField(ColorName).GetValue(null);
    }

    public ICommand GoBackCommand => new Command(
      () => _navigationService.GoBackAsync()
    );

    public ICommand SpeakCommand => new Command(
      () => _textToSpeechService.Speak(ColorName)
    );

    public SelectedItemPageViewModel(
      INavigationService navigationService,
      ITextToSpeechService textToSpeechService
    )
    {
      _navigationService = navigationService;
      _textToSpeechService = textToSpeechService;
    }
  }
}