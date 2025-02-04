using MudBlazor;

namespace WorkOS.BlazorServer.Components.Layout;

public static class CustomTheme
{
    public static readonly MudTheme Theme = new MudTheme()
    {
        PaletteLight = new PaletteLight()
        {
            Primary = Colors.Cyan.Lighten1,
            Secondary = Colors.Cyan.Lighten2,
            Tertiary = Colors.Cyan.Lighten3,
            Background = Colors.Cyan.Darken1,
            AppbarText = Colors.Cyan.Darken2,
            DrawerText = Colors.Cyan.Darken3,
            DrawerIcon = Colors.Cyan.Darken4
        },
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
}
