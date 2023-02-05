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
    public interface IFixMusicModel : IDisposable
    {
        bool ConvertFiles { get; set; }
        bool AssignCoverArt { get; set; }
        string CoverArtPath { get; set; }
        string CoverArtFileNameFormat { get; set; }
        string CoverArtExtensions { get; set; }
        string ConverterExtension { get; set; }
        string FileNameFormat { get; set; }
        string SourceFilter { get; set; }
        string FileNameFormatVariousArtists { get; set; }
        bool FixArtistConflicts { get; set; }
        bool FillInTotalTracks { get; set; }
        string SourcePath { get; set; }
        bool MoveFilesToMusicLibrary { get; set; }
        bool MoveThe { get; set; }
        string ConverterArgumentsFormat { get; set; }
        string ConverterExecutablePath { get; set; }
        string MusicLibraryPath { get; set; }
        string MusicLibraryPathFormat { get; set; }
        bool RenameFiles { get; set; }
        bool RollIntoOneDisc { get; set; }

        event EventHandler<ValueEventArgs<string>> MusicLibraryPathChanged;
        event EventHandler<ValueEventArgs<string>> MusicLibraryPathFormatChanged;
        event EventHandler<ValueEventArgs<string>> SourcePathChanged;
        event EventHandler<ValueEventArgs<string>> CoverArtPathChanged;
        event EventHandler<ValueEventArgs<string>> FileNameFormatChanged;
        event EventHandler<ValueEventArgs<string>> CoverArtFileNameFormatChanged;
        event EventHandler<ValueEventArgs<string>> CoverArtExtensionsChanged;
        event EventHandler<ValueEventArgs<string>> ConverterExtensionChanged;
        event EventHandler<ValueEventArgs<string>> SourceFilterChanged;
        event EventHandler<ValueEventArgs<string>> ConverterExecutablePathChanged;
        event EventHandler<ValueEventArgs<string>> ConverterArgumentsFormatChanged;
        event EventHandler<ValueEventArgs<string>> FileNameFormatVariousArtistsChanged;
        event EventHandler<ValueEventArgs<bool>> FixedArtistConflictsChanged;
        event EventHandler<ValueEventArgs<bool>> FillInTotalTracksChanged;
        event EventHandler<ValueEventArgs<bool>> MoveTheChanged;
        event EventHandler<ValueEventArgs<bool>> AssignCoverArtChanged;
        event EventHandler<ValueEventArgs<bool>> RollIntoOneDiscChanged;
        event EventHandler<ValueEventArgs<bool>> RenameFilesChanged;
        event EventHandler<ValueEventArgs<bool>> MoveFilesToMusicLibraryChanged;
        event EventHandler<ValueEventArgs<bool>> ConvertFilesChanged;

        void Start();
    }
}