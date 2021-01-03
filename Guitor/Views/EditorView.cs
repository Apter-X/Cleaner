using System;
using System.Collections.Generic;
using System.Text;
using Terminal.Gui;

namespace Guitor.Views
{
    public class EditorView
    {
        public static void Edit(string filename)
        {
            var app = Builder.Init("Editor v1.0");

            var editor = new TextView()
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            editor.Text = System.IO.File.ReadAllText(filename);

            app.Add(editor);
            Builder.Run(app);
        }
    }
}
