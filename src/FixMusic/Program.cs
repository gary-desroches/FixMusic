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
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace FixMusic
{
    class Program
    {
        public void Run()
        {
            Environment.CurrentDirectory =
                new FileInfo(Assembly.GetAssembly(typeof(Program))!.Location).Directory!.FullName;

            var model = new FixMusicModel(_appSettings, new FixMusicController(), new ConsoleErrorPresenter())
            {
                ConvertFiles = _arguments.ConvertFiles,
                AssignCoverArt = _arguments.AssignCoverArt,
                CoverArtPath = _appSettings.CoverArtPath,
                CoverArtFileNameFormat = _appSettings.CoverArtFileNameFormat,
                CoverArtExtensions = _appSettings.CoverArtExtensions,
                ConverterExtension = _appSettings.ConverterExtension,
                FileNameFormatVariousArtists = _appSettings.FileNameFormat,
                FixArtistConflicts = _arguments.FixArtistConflicts,
                ConverterArgumentsFormat = _appSettings.ConverterArgumentsFormat,
                FileNameFormat = FileNameFormat,
                SourcePath = _arguments.SourceDirectory.FullName,
                SourceFilter = _appSettings.SourceFilter,
                MoveFilesToMusicLibrary = _arguments.MoveFiles,
                MoveThe = _arguments.MoveTheArgument,
                ConverterExecutablePath = _appSettings.ConverterExecutablePath,
                MusicLibraryPath = _appSettings.MusicLibraryPath,
                MusicLibraryPathFormat = _appSettings.MusicLibraryPathFormat,
                RenameFiles = _arguments.RenameFiles,
                RollIntoOneDisc = _arguments.OneDisc,
                FillInTotalTracks = _arguments.FillInTotalTracks
            };

            model.Start();
        }

        private Program(string[] args)
        {
            Debug.Assert(args != null);

            _arguments = new CommandLineArguments(args);
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfigurationRoot configurarion = builder.Build();
            _appSettings = configurarion.GetSection("AppSettings").Get<AppSettings>();
        }

        static void Main(string[] args)
        {
            new Program(args).Run();
        }

        private string FileNameFormat =>
            _arguments.FileNameFormat.Length > 0
                ? _arguments.FileNameFormat
                : _appSettings.FileNameFormat;

        private readonly CommandLineArguments _arguments;
        private readonly AppSettings _appSettings;
    }
}
