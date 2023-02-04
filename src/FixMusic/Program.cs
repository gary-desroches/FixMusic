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
