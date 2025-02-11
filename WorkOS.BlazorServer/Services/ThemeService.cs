using Microsoft.Extensions.Primitives;
using MudBlazor;
using MudBlazor.Interfaces;
using MudBlazor.Utilities;
using System.Data;

namespace WorkOS.BlazorServer.Services;

public class ThemeService : MudTheme
{
    public ThemeService()
    {
        PaletteLight = new PaletteLight()
        {
            Primary = new MudColor("#1B5E7A"),
            Secondary = new MudColor("#4ACBCC"),
            Tertiary = new MudColor("#2FA6B3"),
            Background = new MudColor("#D6F1F5"),
            AppbarBackground = new MudColor("#4ACBCC"),
            AppbarText = new MudColor("#0F2C3F"),
            DrawerBackground = new MudColor("#1B5E7A"),
            DrawerText = new MudColor("#D6F1F5"),
            DrawerIcon = new MudColor("#D6F1F5"),
        };

        PaletteDark = new PaletteDark()
        {
            Primary = new MudColor("#2FA6B3"),
            Secondary = new MudColor("#1B5E7A"),
            Tertiary = new MudColor("#4ACBCC"),
            Background = new MudColor("#0F2C3F"),
            AppbarBackground = new MudColor("#1B5E7A"),
            AppbarText = new MudColor("#D6F1F5"),
            DrawerBackground = new MudColor("#2FA6B3"),
            DrawerText = new MudColor("#D6F1F5"),
            DrawerIcon = new MudColor("#D6F1F5")
        };

    }
    //public readonly MudTheme LightTheme = new MudTheme()
    //{
    //    PaletteLight = new PaletteLight()
    //    {
    //        Primary = new MudColor("#2F0869"),
    //        Secondary = new MudColor("#3E0B8B"),
    //        Tertiary = new MudColor("#4E0EAD"),
    //        Background = new MudColor("#4E0EAD"),
    //        AppbarText = Colors.Gray.Lighten5,
    //        DrawerText = Colors.Gray.Lighten5,
    //        DrawerIcon = Colors.Gray.Lighten5
    //    }
    //};

    //public readonly MudTheme DarkTheme = new MudTheme()
    //{
    //    PaletteDark = new PaletteDark()
    //    {
    //        Primary = Colors.Cyan.Darken1,
    //        Secondary = Colors.Cyan.Darken2,
    //        Tertiary = Colors.Cyan.Darken3,
    //        Background = Colors.Cyan.Lighten1,
    //        AppbarText = Colors.Cyan.Darken2,
    //        DrawerText = Colors.Cyan.Darken3,
    //        DrawerIcon = Colors.Cyan.Darken4
    //    }
    //};
    public bool IsDarkTheme { get; private set; } = true;
    

    public void SwitchTheme()
    {
        IsDarkTheme = !IsDarkTheme;
    }
}
