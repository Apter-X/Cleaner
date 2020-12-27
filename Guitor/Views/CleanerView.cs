using Terminal.Gui;

namespace Guitor.Views
{
    static class CleanerView
    {
        public static void Start()
        {
            var app = Builder.Init("Cleaner v1.0");

            #region tool-list
            var toolBar = new FrameView("Tools")
            {
                X = 0,
                Y = 1,
                Width = Dim.Percent(15),
                Height = Dim.Percent(80)
            };

            var analBtn = new Button("Analyze", true)
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            var clnBtn = new Button("Clean", true)
            {
                X = 0,
                Y = 2,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            toolBar.Add(analBtn, clnBtn);
            app.Add(toolBar);
            #endregion

            #region overview
            var overView = new FrameView("Overview")
            {
                X = Pos.Right(toolBar),
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Percent(80)
            };

            app.Add(overView);
            #endregion

            #region console
            var consoleBare = new FrameView("Output")
            {
                X = 0,
                Y = Pos.Bottom(overView),
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            var prompt = new ListView()
            {
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            consoleBare.Add(prompt);
            app.Add(consoleBare);
            #endregion

            Builder.Run(app);
        }
    }
}
