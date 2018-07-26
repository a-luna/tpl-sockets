﻿namespace AaronLuna.AsyncFileServer.Model
{
    public enum LogLevel
    {
        None,
        Info,
        Debug,
        Trace
    }

    public enum ServerEventType
    {
        None,

        ServerStartedListening,
        ServerStoppedListening,

        ConnectionAccepted,

        ConnectToRemoteServerStarted,
        ConnectToRemoteServerComplete,

        ReceiveRequestFromRemoteServerStarted,
        ReceiveRequestFromRemoteServerComplete,

        ReceiveRequestLengthStarted,
        ReceivedRequestLengthBytesFromSocket,
        ReceiveRequestLengthComplete,

        SaveUnreadBytesAfterRequestLengthReceived,
        CopySavedBytesToRequestData,

        ReceiveRequestBytesStarted,
        ReceivedRequestBytesFromSocket,
        ReceiveRequestBytesComplete,

        SaveUnreadBytesAfterAllRequestBytesReceived,
        CopySavedBytesToIncomingFile,

        DetermineRequestTypeStarted,
        DetermineRequestTypeComplete,

        ProcessRequestBacklogStarted,
        ProcessRequestBacklogComplete,
        PendingFileTransfer,
        ProcessRequestStarted,
        ProcessRequestComplete,

        SendTextMessageStarted,
        SendTextMessageComplete,
        ReceivedTextMessage,
        MarkTextMessageAsRead,

        FileTransferStatusChange,

        RequestOutboundFileTransferStarted,
        RequestOutboundFileTransferComplete,
        ReceivedOutboundFileTransferRequest,

        SendFileBytesStarted,
        SentFileChunkToRemoteServer,
        SendFileBytesComplete,

        MultipleFileWriteAttemptsNeeded,

        RequestInboundFileTransferStarted,
        RequestInboundFileTransferComplete,
        ReceivedInboundFileTransferRequest,

        SendFileTransferRejectedStarted,
        SendFileTransferRejectedComplete,
        RemoteServerRejectedFileTransfer,

        SendFileTransferAcceptedStarted,
        SendFileTransferAcceptedComplete,
        RemoteServerAcceptedFileTransfer,

        SendFileTransferCompletedStarted,
        SendFileTransferCompletedCompleted,
        RemoteServerConfirmedFileTransferCompleted,

        ReceiveFileBytesStarted,
        ReceivedFileBytesFromSocket,
        UpdateFileTransferProgress,
        ReceiveFileBytesComplete,

        SendFileTransferStalledStarted,
        SendFileTransferStalledComplete,
        FileTransferStalled,

        RetryOutboundFileTransferStarted,
        RetryOutboundFileTransferComplete,
        ReceivedRetryOutboundFileTransferRequest,

        SendRetryLimitExceededStarted,
        SendRetryLimitExceededCompleted,
        ReceivedRetryLimitExceeded,

        RequestFileListStarted,
        RequestFileListComplete,
        ReceivedFileListRequest,

        SendFileListStarted,
        SendFileListComplete,
        ReceivedFileList,

        SendNotificationNoFilesToDownloadStarted,
        SendNotificationNoFilesToDownloadComplete,
        ReceivedNotificationNoFilesToDownload,

        SendNotificationFolderDoesNotExistStarted,
        SendNotificationFolderDoesNotExistComplete,
        ReceivedNotificationFolderDoesNotExist,

        SendNotificationFileDoesNotExistStarted,
        SendNotificationFileDoesNotExistComplete,
        ReceivedNotificationFileDoesNotExist,

        ShutdownListenSocketStarted,
        ShutdownListenSocketCompletedWithoutError,
        ShutdownListenSocketCompletedWithError,

        SendShutdownServerCommandStarted,
        SendShutdownServerCommandComplete,
        ReceivedShutdownServerCommand,

        RequestServerInfoStarted,
        RequestServerInfoComplete,
        ReceivedServerInfoRequest,

        SendServerInfoStarted,
        SendServerInfoComplete,
        ReceivedServerInfo,

        ErrorOccurred
    }

    public static class ServerEventTypeExtensions
    {
        public static bool DoNotDisplayInLog(this ServerEventType eventType)
        {
            switch (eventType)
            {
                case ServerEventType.ProcessRequestStarted:
                case ServerEventType.ProcessRequestComplete:
                case ServerEventType.ConnectToRemoteServerStarted:
                case ServerEventType.ConnectToRemoteServerComplete:
                    return true;

                default:
                    return false;
            }
        }

        public static bool LogLevelIsTraceOnly(this ServerEventType eventType)
        {
            switch (eventType)
            {
                case ServerEventType.SentFileChunkToRemoteServer:
                case ServerEventType.UpdateFileTransferProgress:
                    return true;

                default:
                    return false;
            }
        }

        public static bool LogLevelIsDebugOnly(this ServerEventType eventType)
        {
            switch (eventType)
            {
                case ServerEventType.ConnectToRemoteServerStarted:
                case ServerEventType.ConnectToRemoteServerComplete:
                case ServerEventType.ReceiveRequestFromRemoteServerStarted:
                case ServerEventType.ReceiveRequestFromRemoteServerComplete:
                case ServerEventType.ReceiveRequestLengthStarted:
                case ServerEventType.ReceivedRequestLengthBytesFromSocket:
                case ServerEventType.SaveUnreadBytesAfterRequestLengthReceived:
                case ServerEventType.ReceiveRequestLengthComplete:
                case ServerEventType.ReceiveRequestBytesStarted:
                case ServerEventType.CopySavedBytesToRequestData:
                case ServerEventType.DetermineRequestTypeStarted:
                case ServerEventType.DetermineRequestTypeComplete:
                case ServerEventType.ReceivedRequestBytesFromSocket:
                case ServerEventType.ReceiveRequestBytesComplete:
                case ServerEventType.SaveUnreadBytesAfterAllRequestBytesReceived:
                case ServerEventType.ProcessRequestStarted:
                case ServerEventType.ProcessRequestComplete:
                case ServerEventType.SentFileChunkToRemoteServer:
                case ServerEventType.CopySavedBytesToIncomingFile:
                case ServerEventType.ReceivedFileBytesFromSocket:
                case ServerEventType.MultipleFileWriteAttemptsNeeded:
                case ServerEventType.UpdateFileTransferProgress:
                    return true;

                default:
                    return false;
            }
        }
    }
}
