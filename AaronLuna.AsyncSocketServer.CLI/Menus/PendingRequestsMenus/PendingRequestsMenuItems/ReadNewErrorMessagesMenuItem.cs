﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AaronLuna.Common.Console.Menu;
using AaronLuna.Common.Result;

namespace AaronLuna.AsyncSocketServer.CLI.Menus.PendingRequestsMenus.PendingRequestsMenuItems
{
    class ReadNewErrorMessagesMenuItem : IMenuItem
    {
        readonly AppState _state;
        readonly List<ServerError> _errorMessages;

        public ReadNewErrorMessagesMenuItem(AppState state, List<ServerError> errorMessages)
        {
            _state = state;
            _errorMessages = errorMessages;

            var messageCount = errorMessages.Count;
            var messagePlural = messageCount > 1
                ? "messages"
                : "message";

            ReturnToParent = false;
            ItemText = $"View {messageCount} new error {messagePlural}";
        }

        public string ItemText { get; set; }
        public bool ReturnToParent { get; set; }

        public Task<Result> ExecuteAsync()
        {
            return Task.Run((Func<Result>)Execute);
        }

        Result Execute()
        {
            if (_state.AllErrorsHaveBeenRead)
            {
                return Result.Fail("There are no unread error messages at this time.");
            }

            SharedFunctions.DisplayLocalServerInfo(_state);
            System.Console.WriteLine($"{Environment.NewLine}############### NEW ERROR MESSAGES ###############{Environment.NewLine}");

            foreach (var i in Enumerable.Range(0, _errorMessages.Count))
            {
                System.Console.WriteLine(_errorMessages[i].ToString());
                _errorMessages[i].Unread = false;
            }

            System.Console.WriteLine(Environment.NewLine + Resources.Prompt_ReturnToPreviousMenu);
            System.Console.ReadLine();

            return Result.Ok();
        }

    }
}
