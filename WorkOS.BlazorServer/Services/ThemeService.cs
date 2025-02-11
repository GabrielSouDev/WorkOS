using MudBlazor;
using MudBlazor.Utilities;

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
            TableHover = new MudColor("#A1D7E1"),
            TableLines = new MudColor("#B8D8E5"),
            TableStriped = new MudColor("#C6E7F2"),
            TextPrimary = new MudColor("#1B5E7A"),
            TextSecondary = new MudColor("#4ACBCC"),
            DrawerIcon = new MudColor("#D6F1F5")
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
            TableHover = new MudColor("#335D6B"),
            TableLines = new MudColor("#1B5E7A"),
            TableStriped = new MudColor("#2A6F80"),
            TextPrimary = new MudColor("#D6F1F5"),
            TextSecondary = new MudColor("#4ACBCC"),
            DrawerIcon = new MudColor("#D6F1F5")
        };
    }
    public bool IsDarkTheme { get; private set; } = true;
    public void SwitchTheme()
    {
        IsDarkTheme = !IsDarkTheme;
    }
}
