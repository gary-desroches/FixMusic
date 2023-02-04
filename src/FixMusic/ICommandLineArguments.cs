using System.IO;

namespace FixMusic
{
    public interface ICommandLineArguments
    {
        bool AssignCoverArt { get; }
        bool FillInTotalTracks { get; }
        bool ConvertFiles { get; }
        string FileNameFormat { get; }
        bool FixArtistConflicts { get; }
        DirectoryInfo SourceDirectory { get; }
        bool MoveFiles { get; }
        bool MoveTheArgument { get; }
        bool OneDisc { get; }
        bool RenameFiles { get; }
    }
}