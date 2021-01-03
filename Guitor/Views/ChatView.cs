using System.Collections.Generic;
using Terminal.Gui;
using Guitor.Views.Windows;

namespace Guitor.Views
{
    public class ChatView
    {
        private static string _username;
        private static readonly List<string> _users = new List<string>();
        private static readonly List<string> _messages = new List<string>();

        public static void Start()
        {
            var app = Builder.Init("Chat");

            #region chat-view
            var chatViewFrame = new FrameView("Chats")
            {
                X = 0,
                Y = 1,
                Width = Dim.Percent(75),
                Height = Dim.Percent(80),
            };

            var chatView = new ListView
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill(),
            };
            chatViewFrame.Add(chatView);
            app.Add(chatViewFrame);
            #endregion

            #region online-user-list
            var userListFrame = new FrameView("Online Users")
            {
                X = Pos.Right(chatViewFrame),
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            var userList = new ListView(_users)
            {
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            userListFrame.Add(userList);
            app.Add(userListFrame);
            #endregion

            #region chat-bar
            var chatBar = new FrameView(null)
            {
                X = 0,
                Y = Pos.Bottom(chatViewFrame),
                Width = chatViewFrame.Width,
                Height = Dim.Fill()
            };

            var chatMessage = new TextField("")
            {
                X = 0,
                Y = 0,
                Width = Dim.Percent(75),
                Height = Dim.Fill()
            };

            var sendButton = new Button("Send", true)
            {
                X = Pos.Right(chatMessage),
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            sendButton.Clicked = () =>
            {
                Application.MainLoop.Invoke(() =>
                {
                    _messages.Add($"{_username}: {chatMessage.Text}");
                    chatView.SetSource(_messages);
                    chatMessage.Text = "";
                });
            };

            chatBar.Add(chatMessage);
            chatBar.Add(sendButton);
            app.Add(chatBar);
            #endregion

            // login window will be appear on the center screen
            var loginWindow = new LoginWindow(null)
            {
                OnExit = Application.RequestStop,

                OnLogin = (loginData) =>
                {
                    // for thread-safety
                    Application.MainLoop.Invoke(() =>
                    {
                        _users.Add(loginData.name);
                        _username = loginData.name;
                        userList.SetSource(_users);
                    });
                    Builder.Run(app);
                }
            };

            // run login-window-first
            Application.Run(loginWindow);
        }
    }
}
