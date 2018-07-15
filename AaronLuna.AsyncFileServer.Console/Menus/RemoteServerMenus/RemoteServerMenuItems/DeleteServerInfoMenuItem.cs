﻿namespace AaronLuna.AsyncFileServer.Console.Menus.RemoteServerMenus.RemoteServerMenuItems
{
    using System;
    using System.Threading.Tasks;

    using Model;
    using Common.Console.Menu;
    using Common.Result;

    class DeleteServerInfoMenuItem : IMenuItem
    {
        readonly AppState _state;

        public DeleteServerInfoMenuItem(AppState state)
        {
            _state = state;

            ReturnToParent = false;
            ItemText = "Forget about this server";
        }

        public string ItemText { get; set; }
        public bool ReturnToParent { get; set; }

        public Task<Result> ExecuteAsync()
        {
            return Task.Run((Func<Result>)Execute);
        }

        Result Execute()
        {
            _state.RemoteServerSelected = false;
            _state.Settings.RemoteServers.Remove(_state.SelectedServerInfo);

            return ServerSettings.SaveToFile(_state.Settings, _state.SettingsFilePath);
        }
    }
}
