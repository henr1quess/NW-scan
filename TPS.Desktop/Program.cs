using System.Diagnostics;
using TPS.Core;
using Velopack;

namespace TPS.Desktop;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        VelopackApp.Build().Run();

#if DEBUG
        Scanner.Version = "DEBUG";
#else
        var version = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);
        Scanner.Version = $"{version.FileMajorPart}.{version.FileMinorPart}.{version.FileBuildPart}";
#endif
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());

        Application.ApplicationExit += Application_ApplicationExit;
    }

    private static void Application_ApplicationExit(object sender, EventArgs e)
    {
        CharacterRecognition.Dispose();
    }

}