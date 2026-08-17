

// ================================================================
//  PROGRAM ENTRY POINT
// ================================================================
using SabraForSpareParts;
static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.SetHighDpiMode(HighDpiMode.SystemAware);

        // Show login first
        // using (var login = new LoginForm())
        // {
        //     if (login.ShowDialog() != DialogResult.OK) return;
        // }

        Application.Run(new frmMain());
    }
}