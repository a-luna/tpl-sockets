﻿using System;
using System.IO;
using System.Xml.Serialization;
using AaronLuna.Common.Network;
using AaronLuna.Common.Result;

namespace TplSocketServer
{
    using System.Collections.Generic;

    public class AppSettings
    {
        public AppSettings()
        {
            TransferFolderPath = string.Empty;
            SocketSettings = new SocketSettings();
            RemoteServers = new List<RemoteServer>();
        }

        public string TransferFolderPath { get; set; }
        public SocketSettings SocketSettings { get; set; }
        public List<RemoteServer> RemoteServers { get; set; }

        public static void Serialize(AppSettings settings, string filePath)
        {
            var serializer = new XmlSerializer(typeof(AppSettings));
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, settings);
            }
        }

        public void InitializeIpAddresses()
        {
            foreach (var server in RemoteServers)
            {
               var parseResult =
                    IpAddressHelper.ParseSingleIPv4Address(server.ConnectionInfo.LocalIpString);

                if (parseResult.Success)
                {
                    server.ConnectionInfo.LocalIpAddress = parseResult.Value;
                }
            }
        }

        public static Result<AppSettings> Deserialize(string filePath)
        {
            AppSettings settings;
            try
            {
                var deserializer = new XmlSerializer(typeof(AppSettings));
                using (var reader = new StreamReader(filePath))
                {
                    settings = (AppSettings)deserializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                return Result.Fail<AppSettings>($"{ex.Message} ({ex.GetType()})");
            }

            settings.InitializeIpAddresses();

            return Result.Ok(settings);
        }
    }
}
