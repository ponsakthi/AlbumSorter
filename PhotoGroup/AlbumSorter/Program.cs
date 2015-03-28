namespace AlbumSorter
{
    using AlbumSorter.FileSystemHandler;
    using AlbumSorter.View;
    using System;
    using System.Windows.Forms;

    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(new AlbumSorter.FileSystemHandler.FileSystemHandler()));
        }
    }
}

