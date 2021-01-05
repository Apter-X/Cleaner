//using Terminal.Gui;
//using System.Collections.Generic;
//using Guitor.Controllers;

//namespace Guitor.Views
//{
//    public class LauncherView
//    {
//		public static void Start()
//        {
//			var app = Builder.Init("Launcher");

//			#region Output
//			var output = new FrameView("Output")
//			{
//				X = 0,
//				Y = 1,
//				Width = Dim.Percent(100),
//				Height = Dim.Percent(80)
//			};

//			var outputList = new ListView
//			{
//				X = 0,
//				Y = 0,
//				Width = Dim.Fill(),
//				Height = Dim.Fill(),
//			};
//			output.Add(outputList);
//			app.Add(output);


//			#endregion

//			#region Progress Bar
//			var activityProgressBar = new ProgressBar()
//			{
//				X = 1,
//				Y = Pos.Percent(90),
//				Width = Dim.Fill(),
//				Height = 1,
//				Fraction = 0.25F,
//				ColorScheme = Colors.Error
//			};
//			app.Add(activityProgressBar);
//			#endregion

//			#region Buttons
//			var startButton = new Button("Check")
//			{
//				X = Pos.Center(),
//				Y = Pos.Top(activityProgressBar) - 2,
//			};
//			startButton.Clicked += () => Application.MainLoop?.Invoke(() => {
//				List<string> outputs = new List<string>();
//				LauncherController.OnLogAdded = (logData) =>
//				{
//					Application.MainLoop.Invoke(() =>
//					{
//						outputs.Add(logData.log);
//						outputList.SetSource(outputs);
//					});
//				};
//				LauncherController.StartChecking();
//			});
//			app.Add(startButton);

//			var stopButton = new Button("Enter")
//			{
//				X = Pos.Right(startButton) + 2,
//				Y = Pos.Y(startButton),
//			};
//			stopButton.Clicked += () => CleanerView.Start();
//			app.Add(stopButton);
//            #endregion

//            Builder.Run(app);
//        }
//	}
//}
