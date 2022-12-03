using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminPanelGoSibu;
using System.Windows.Input;
namespace AdminPanelGoSibu;

public class MainPageViewModel
{
    public ICommand ICommandNavToEditPackagePage { get; set; }

    public MainPageViewModel()
    {
        ICommandNavToEditPackagePage = new Command(() => NavigateToEditPackage());
    }

    private void NavigateToEditPackage()
    {
        App.Current.MainPage.Navigation.PushAsync(new EditPackagePage());
    }

}
