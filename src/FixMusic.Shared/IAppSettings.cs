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
