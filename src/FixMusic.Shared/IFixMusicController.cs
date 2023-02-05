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

using System;

namespace FixMusic
{
    public interface IFixMusicController
    {
        string MusicLibraryPath { set; }
        event EventHandler<ValueEventArgs<string>> MusicLibraryPathChanged;
        string MusicLibraryPathFormat { set; }
        event EventHandler<ValueEventArgs<string>> MusicLibraryPathFormatChanged;
        string SourcePath { set; }
        event EventHandler<ValueEventArgs<string>> SourcePathChanged;
        string CoverArtPath { set; }
        event EventHandler<ValueEventArgs<string>> CoverArtPathChanged;
        string CoverArtFileNameFormat { set; }
        event EventHandler<ValueEventArgs<string>> CoverArtFileNameFormatChanged;
        string FileNameFormat { set; }
        event EventHandler<ValueEventArgs<string>> FileNameFormatChanged;
        string SourceFilter { set; }
        event EventHandler<ValueEventArgs<string>> SourceFilterChanged;
        string ConverterExecutablePath { set; }
        event EventHandler<ValueEventArgs<string>> ConverterExecutablePathChanged;
        string ConverterArgumentsFormat { set; }
        event EventHandler<ValueEventArgs<string>> ConverterArgumentsFormatChanged;
        string FileNameFormatVariousArtists { set; }
        event EventHandler<ValueEventArgs<string>> FileNameFormatVariousArtistsChanged;
        string CoverArtExtensions { set; }
        event EventHandler<ValueEventArgs<string>> CoverArtExtensionsChanged;
        string ConverterExtension { set; }
        event EventHandler<ValueEventArgs<string>> ConverterExtensionChanged;
        bool FixArtistConflicts { set; }
        event EventHandler<ValueEventArgs<bool>> FixedArtistConflictsChanged;
        bool FillInTotalTracks { set; }
        event EventHandler<ValueEventArgs<bool>> FillInTotalTracksChanged;
        bool MoveThe { set; }
        event EventHandler<ValueEventArgs<bool>> MoveTheChanged;
        bool AssignCoverArt { set; }
        event EventHandler<ValueEventArgs<bool>> AssignCoverArtChanged;
        bool RollIntoOneDisc { set; }
        event EventHandler<ValueEventArgs<bool>> RollIntoOneDiscChanged;
        bool RenameFiles { set; }
        event EventHandler<ValueEventArgs<bool>> RenameFilesChanged;
        bool MoveFilesToMusicLibrary { set; }
        event EventHandler<ValueEventArgs<bool>> MoveFilesToMusicLibraryChanged;
        bool ConvertFiles { set; }
        event EventHandler<ValueEventArgs<bool>> ConvertFilesChanged;
    }
}
