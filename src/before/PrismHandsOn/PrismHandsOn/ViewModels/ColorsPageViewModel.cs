using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using Prism.Navigation;
using PrismHandsOn.Views;

namespace PrismHandsOn.ViewModels
{
  public class ColorsPageViewModel
  {
    private readonly INavigationService _navigationService;

    public IReadOnlyCollection<ColorInfo> ColorInfos { get; } =
      typeof(Color)
        .GetRuntimeFields()
        .Where(x => x.IsPublic && x.IsStatic && x.FieldType == typeof(Color))
        .Select(x => new ColorInfo { Name = x.Name, Color = (Color)x.GetValue(null) })
        .ToList();

    public Command<ColorInfo> ItemSelectedCommand =>
    new Command<ColorInfo>(colorInfo =>
    {
      _navigationService.NavigateAsync(
        $"{nameof(SelectedItemPage)}?colorName={colorInfo.Name}"
      );
    });

    public ColorsPageViewModel(INavigationService navigationService)
    {
      _navigationService = navigationService;
    }
  }
}
