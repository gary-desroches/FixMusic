namespace FixMusic
{
    public interface IAppSettings
    {
        string MusicLibraryPath { get; set; }
        string MusicLibraryPathFormat { get; set; }
        string CoverArtPath { get; set; }
        string FileNameFormat { get; set; }
        string ConverterExecutablePath { get; set; }
        string FileNameFormatVariousArtists { get; set; }
        string ConverterArgumentsFormat { get; set; }
        string SourceFilter { get; set; }
        string CoverArtFileNameFormat { get; set; }
        string CoverArtExtensions { get; set; }
        string ConverterExtension { get; set; }
        MetadataFieldFileNameReplacement[] MetadataFieldFileNameReplacements { get; set; }
        bool FixArtistConflicts { get; set; }
        bool MoveThe { get; set; }
        bool RollIntoOneDisc { get; set; }
        bool FillInTotalTracks { get; set; }
        bool RenameFiles { get; set; }
        bool MoveFilesToMusicLibrary { get; set; }
        bool ConvertFiles { get; set; }
        bool AssignCoverArt { get; set; }
    }
}
