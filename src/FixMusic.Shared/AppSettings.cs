namespace FixMusic
{
    public class AppSettings : IAppSettings
    {
        public string MusicLibraryPath { get; set; } = string.Empty;
        public string MusicLibraryPathFormat { get; set; } = string.Empty;
        public string CoverArtPath { get; set; } = string.Empty;
        public string FileNameFormat { get; set; } = string.Empty;
        public string ConverterExecutablePath { get; set; } = string.Empty;
        public string FileNameFormatVariousArtists { get; set; } = string.Empty;
        public string ConverterArgumentsFormat { get; set; } = string.Empty;
        public string SourceFilter { get; set; } = string.Empty;
        public string CoverArtFileNameFormat { get; set; } = string.Empty;
        public string CoverArtExtensions { get; set; } = string.Empty;
        public string ConverterExtension { get; set; } = string.Empty;
        public MetadataFieldFileNameReplacement[] MetadataFieldFileNameReplacements { get; set; } = new MetadataFieldFileNameReplacement[0];
        public bool FixArtistConflicts { get; set; }
        public bool MoveThe { get; set; }
        public bool RollIntoOneDisc { get; set; }
        public bool FillInTotalTracks { get; set; }
        public bool RenameFiles { get; set; }
        public bool MoveFilesToMusicLibrary { get; set; }
        public bool ConvertFiles { get; set; }
        public bool AssignCoverArt { get; set; }
    }
}
