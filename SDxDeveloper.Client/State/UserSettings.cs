using System;

namespace SDxDeveloper.Client.State
{
    /// <summary>
    /// Serializable class to parsing user settings and read/write to app cfg file.
    /// </summary>
    [Serializable]
    public sealed class UserSettings
    {
        public string? DefaultFileExplorePath;

        public bool ExportPreserveWhitespace;

        public string? Site1_TargetPath;

        public string? Site2_TargetPath;

        public string? Site1_OAuthToken;

        public string? Site2_OAuthToken;

        public string? Site1_HomeDirectory;

        public string? Site2_HomeDirectory;
    }
}
