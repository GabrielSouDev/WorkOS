using Microsoft.Extensions.Primitives;
using MudBlazor;
using MudBlazor.Interfaces;
using MudBlazor.Utilities;
using System.Data;

namespace WorkOS.BlazorServer.Services;

public class ThemeService : MudTheme
{
    public readonly MudTheme LightTheme = new MudTheme()
    {
        PaletteLight = new PaletteLight()
        {
            Primary = new MudColor("#2F0869"),
            Secondary = new MudColor("#3E0B8B"),
            Tertiary = new MudColor("#4E0EAD"),
            Background = new MudColor("#4E0EAD"),
            AppbarText = Colors.Gray.Lighten5,
            DrawerText = Colors.Gray.Lighten5,
            DrawerIcon = Colors.Gray.Lighten5
        }
    };

    public readonly MudTheme DarkTheme = new MudTheme()
    {
        PaletteDark = new PaletteDark()
        {
            Primary = Colors.Cyan.Darken1,
            Secondary = Colors.Cyan.Darken2,
            Tertiary = Colors.Cyan.Darken3,
            Background = Colors.Cyan.Lighten1,
            AppbarText = Colors.Cyan.Darken2,
            DrawerText = Colors.Cyan.Darken3,
            DrawerIcon = Colors.Cyan.Darken4
        }
    };
    public MudTheme CurrentTheme { get; private set; }
    public ThemeService()
    {
        CurrentTheme = LightTheme;
    }
    

    public void SwitchTheme()
    {
        if (CurrentTheme == LightTheme)
        {
            CurrentTheme = DarkTheme;
        }
        else
            CurrentTheme = LightTheme;
        
    }
}
