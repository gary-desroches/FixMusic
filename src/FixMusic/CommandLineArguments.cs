using System.Collections.Generic;
using System.IO;
using CommandLineParser.Arguments;

namespace FixMusic
{
    public class CommandLineArguments : ICommandLineArguments
    {
        public CommandLineArguments(string[] args)
        {
            new CommandLineParser.CommandLineParser()
            {
                AcceptHyphen = true,
                AcceptSlash = false,
                IgnoreCase = true,
                Arguments = new List<Argument>
                {
                    _sourceDirectoryArgument,
                    _fileNameFormatArgument,
                    _fixArtistConflictsArgument,
                    _moveTheArgument,
                    _assignCoverArtArgument,
                    _oneDiscArgument,
                    _renameFilesArgument,
                    _moveFilesArgument,
                    _convertFilesArgument,
                    _fillInTotalTracksArgument
                }
            }.ParseCommandLine(args);
        }

        private readonly DirectoryArgument _sourceDirectoryArgument =
            new DirectoryArgument("input")
            {
                Description = "A directory path containing music files to fix.",
                DirectoryMustExist = true,
                Optional = false
            };
        public DirectoryInfo SourceDirectory => _sourceDirectoryArgument.Value;

        private readonly ValueArgument<string> _fileNameFormatArgument =
            new ValueArgument<string>("file-name-format")
            {
                DefaultValue = string.Empty,
                Optional = true
            };
        public string FileNameFormat => _fileNameFormatArgument.Value;

        private readonly SwitchArgument _fixArtistConflictsArgument =
            new SwitchArgument("fix-artist-conflicts", false)
            {
                Description = "Makes sure both Artist and Album Artist are both filled in."
            };
        public bool FixArtistConflicts => _fixArtistConflictsArgument.Value;

        private readonly SwitchArgument _fillInTotalTracksArgument =
            new SwitchArgument("total-tracks", false)
            {
                Description = "Make sure total tracks is filled in."
            };
        public bool FillInTotalTracks => _fillInTotalTracksArgument.Value;

        private readonly SwitchArgument _moveTheArgument =
            new SwitchArgument("move-the", false)
            {
                Description = "Move \"The\" from the front to the back of artist and album fields."
            };
        public bool MoveTheArgument => _moveTheArgument.Value;

        private readonly SwitchArgument _assignCoverArtArgument =
            new SwitchArgument("assign-cover-art", false)
            {
                Description = "Assign cover art to all tracks."
            };
        public bool AssignCoverArt => _assignCoverArtArgument.Value;

        private readonly SwitchArgument _oneDiscArgument =
            new SwitchArgument("one-disc", false)
            {
                Description = "For multi-disc albums, flatten tracks into 1 disc."
            };
        public bool OneDisc => _oneDiscArgument.Value;

        private readonly SwitchArgument _renameFilesArgument =
            new SwitchArgument("rename-files", false)
            {
                Description = "Rename files according to file name format."
            };
        public bool RenameFiles => _renameFilesArgument.Value;

        private readonly SwitchArgument _moveFilesArgument =
            new SwitchArgument("move-files", false)
            {
                Description = "Move files to music library folder."
            };
        public bool MoveFiles => _moveFilesArgument.Value;

        private readonly SwitchArgument _convertFilesArgument =
            new SwitchArgument("convert-files", false)
            {
                Description = "Rename files according to file name format."
            };
        public bool ConvertFiles => _convertFilesArgument.Value;
    }
}
