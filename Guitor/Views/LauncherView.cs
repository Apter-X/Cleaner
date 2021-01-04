using Terminal.Gui;
using Updater;
using Diagnostics;
using System.Collections.Generic;
using System.Threading;
using Guitor.Controllers;

namespace Guitor.Views
{
    public class LauncherView
    {
		public static void Start()
        {
            #region Initialization
			var update = new Update();
			List<string> _outputs = new List<string>();
			var app = Builder.Init("Launcher");
			#endregion

		#region Output
		var output = new FrameView("Output")
			{
				X = 0,
				Y = 1,
				Width = Dim.Percent(100),
				Height = Dim.Percent(80)
			};

			var outputList = new ListView
			{
				X = 0,
				Y = 0,
				Width = Dim.Fill(),
				Height = Dim.Fill(),
			};
			output.Add(outputList);
			app.Add(output);

			LauncherController.StartDebuging();

			LauncherController.OnLogAdded = (logData) =>
			{
				Application.MainLoop.Invoke(() =>
				{
					_outputs.Add(logData.log);
					outputList.SetSource(_outputs);
				});
			};
			#endregion

			#region Progress Bar
			var activityProgressBar = new ProgressBar()
			{
				X = 1,
				Y = Pos.Percent(90),
				Width = Dim.Fill(),
				Height = 1,
				Fraction = 0.25F,
				ColorScheme = Colors.Error
			};
			app.Add(activityProgressBar);
			#endregion

			#region Buttons
			var startButton = new Button("Start")
			{
				X = Pos.Center(),
				Y = Pos.Top(activityProgressBar) - 2,
			};
			
			
			startButton.Clicked += () => Application.MainLoop?.Invoke(() => { 
				update.StartMonitoring();
			});

			app.Add(startButton);

			var stopButton = new Button("Stop")
			{
				X = Pos.Right(startButton) + 2,
				Y = Pos.Y(startButton),
			};
			stopButton.Clicked += () => update.StopMonitoring();

			app.Add(stopButton);
            #endregion

            Builder.Run(app);
        }
	}
}
