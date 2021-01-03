using Terminal.Gui;

namespace Guitor
{
    public class Builder
    {
        public static Window Init(string title)
        {
            Application.Init();

            #region window
            var mainWindow = new Window(title)
            {
                X = 0,
                Y = 1, // Leave one row for the toplevel menu

                // By using Dim.Fill(), it will automatically resize without manual intervention
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            #endregion

            return mainWindow;
        }

        public static void Run(Window app)
        {
            var top = Application.Top;

            #region top-menu
            top.Add(
                new MenuBar(new MenuBarItem[] {
                    new MenuBarItem("_File", new MenuItem[]{
                        new MenuItem("_Quit", "", Application.RequestStop)
                    }), // end of file menu
                    new MenuBarItem("_Help", new MenuItem[]{
                        new MenuItem("_About", "", ()
                                    => MessageBox.Query(50, 5, "About", "Written by Iliass Raihani\nVersion: 0.0001", "Ok"))
                    }) // end of the help menu
                })
            );
            #endregion

            top.Add(app);

            Application.Run(top);
        }
    }
}
