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
            Primary = new MudColor("#1A73E8"), // Azul vibrante para o tema claro
            Secondary = new MudColor("#4285F4"), // Azul mais suave
            Tertiary = new MudColor("#8AB4F8"), // Azul claro
            Background = new MudColor("#FFFFFF"), // Fundo branco
            AppbarText = new MudColor("#FFFFFF"), // Texto branco no AppBar
            DrawerText = new MudColor("#202124"), // Texto escuro no Drawer
            DrawerIcon = new MudColor("#202124") // Ícones escuros no Drawer
        };

        PaletteDark = new PaletteDark()
        {
            Primary = new MudColor("#0B5ED7"), // Azul forte para o tema escuro
            Secondary = new MudColor("#1C6EF2"), // Azul médio
            Tertiary = new MudColor("#4A90E2"), // Azul mais claro
            Background = new MudColor("#121212"), // Fundo escuro
            AppbarText = new MudColor("#E8EAED"), // Texto claro no AppBar
            DrawerText = new MudColor("#E8EAED"), // Texto claro no Drawer
            DrawerIcon = new MudColor("#E8EAED") // Ícones claros no Drawer
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
