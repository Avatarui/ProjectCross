using System;
using System.Threading.Tasks;
using System.Windows.Input;
using RegSystem.Pages;

namespace RegSystem.ViewModels;

public partial class ProfileViewModel 
{
    public ICommand HomeCommand { get; }
    public ICommand GoToPageCommand { get; }

    public ProfileViewModel()
    {
        HomeCommand = new Command(async () => await HomeAsync());
        GoToPageCommand = new Command<string>(async (page) => await GoToPage(page));
    }

    private async Task HomeAsync()
    {
        await GoToPage((HimePage));
    }

    private async Task GoToPage(string page)
    {
        await Shell.Current.GoToAsync(page);
    }
}