/*

Copyright (c) 2023 Gary Des Roches

Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation files
(the "Software"), to deal in the Software without restriction,
including without limitation the rights to use, copy, modify, merge,
publish, distribute, sublicense, and/or sell copies of the Software,
and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

Any person wishing to distribute modifications to the Software is
asked to send the modifications to the original developer so that
they can be incorporated into the canonical version.  This is,
however, not a binding provision of this license.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR
ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/

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
