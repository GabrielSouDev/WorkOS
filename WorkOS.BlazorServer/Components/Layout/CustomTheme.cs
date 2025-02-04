using MudBlazor;
using MudBlazor.Utilities;

namespace WorkOS.BlazorServer.Components.Layout;

public static class CustomTheme
{
    public static readonly MudTheme Theme = new MudTheme()
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
