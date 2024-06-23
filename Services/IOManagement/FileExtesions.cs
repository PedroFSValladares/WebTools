namespace MusicDownloader.Services.IOManagement {
    public readonly struct FileExtesions {
        public static (string extension, string directory) mpeg4 { get;} = (".mp4", Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));
        public static (string extension, string directory) mpeg3 { get; } = (".mp3", Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
    }
}
