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


namespace FixMusic.WinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _model.ConvertFilesChanged += _model_ConvertFilesChanged;
                _model.AssignCoverArtChanged += _model_AssignCoverArtChanged;
                _model.CoverArtPathChanged += _model_CoverArtPathChanged;
                _model.FileNameFormatChanged += _model_FileNameFormatChanged;
                _model.FileNameFormatVariousArtistsChanged += _model_FileNameFormatVariousArtistsChanged;
                _model.FixedArtistConflictsChanged += _model_FixedArtistConflictsChanged;
                _model.SourcePathChanged += _model_SourcePathChanged;
                _model.MoveFilesToMusicLibraryChanged += _model_MoveFilesToMusicLibraryChanged;
                _model.MoveTheChanged += _model_MoveTheChanged;
                _model.ConverterArgumentsFormatChanged += _model_ConverterArgumentsFormatChanged;
                _model.ConverterExecutablePathChanged += _model_ConverterExecutableChanged;
                _model.MusicLibraryPathFormatChanged += _model_MusicLibraryDirectoryFormatChanged;
                _model.RenameFilesChanged += _model_RenameFilesChanged;
                _model.RollIntoOneDiscChanged += _model_RollIntoOneDiscChanged;
                _model.FillInTotalTracksChanged += _model_FillInTotalTracksChanged;
            }

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._sourceDirectoryGroupBox = new System.Windows.Forms.GroupBox();
            this._sourceDirectoryBrowseButton = new System.Windows.Forms.Button();
            this._sourceDirectoryTextBox = new System.Windows.Forms.TextBox();
            this._musicLibraryDirectoryFormatGroupBox = new System.Windows.Forms.GroupBox();
            this._musicLibraryPathFormatTextBox = new System.Windows.Forms.TextBox();
            this._coverArtGroupBox = new System.Windows.Forms.GroupBox();
            this._coverArtBrowseButton = new System.Windows.Forms.Button();
            this._coverArtTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this._converterGroupBox = new System.Windows.Forms.GroupBox();
            this._converterBrowseButton = new System.Windows.Forms.Button();
            this._converterExecutableTextBox = new System.Windows.Forms.TextBox();
            this._converterCommandLineGroupBox = new System.Windows.Forms.GroupBox();
            this._converterCommandLineTextBox = new System.Windows.Forms.TextBox();
            this._fileNameFormatGroupBox = new System.Windows.Forms.GroupBox();
            this._fileNameFormatTextBox = new System.Windows.Forms.TextBox();
            this._fileNameFormatVariousArtistsGroupBox = new System.Windows.Forms.GroupBox();
            this._fileNameFormatVariousArtistsTextBox = new System.Windows.Forms.TextBox();
            this._startButton = new System.Windows.Forms.Button();
            this._metadataFixesGroupBox = new System.Windows.Forms.GroupBox();
            this._oneDiscCheckBox = new System.Windows.Forms.CheckBox();
            this._coverArtCheckBox = new System.Windows.Forms.CheckBox();
            this._moveTheCheckBox = new System.Windows.Forms.CheckBox();
            this._artistConflictFixerCheckBox = new System.Windows.Forms.CheckBox();
            this._convertCheckBox = new System.Windows.Forms.CheckBox();
            this._moveToLibraryCheckBox = new System.Windows.Forms.CheckBox();
            this._renameCheckBox = new System.Windows.Forms.CheckBox();
            this._sourceFilterGroupBox = new System.Windows.Forms.GroupBox();
            this._sourceFilterTextBox = new System.Windows.Forms.TextBox();
            this._coverArtFileNameFormatGroupBox = new System.Windows.Forms.GroupBox();
            this._coverArtFileNameFormatTextBox = new System.Windows.Forms.TextBox();
            this._coverArtExtensionsGroupBox = new System.Windows.Forms.GroupBox();
            this._coverArtExtensionsTextBox = new System.Windows.Forms.TextBox();
            this._converterExtensionGroupBox = new System.Windows.Forms.GroupBox();
            this._converterExtensionTextBox = new System.Windows.Forms.TextBox();
            this._musicLibraryDirectoryGroupBox = new System.Windows.Forms.GroupBox();
            this._musicLibraryDirectoryBrowseButton = new System.Windows.Forms.Button();
            this._musicLibraryDirectoryTextBox = new System.Windows.Forms.TextBox();
            this._fillInTotalTracksCheckBox = new System.Windows.Forms.CheckBox();
            this._sourceDirectoryGroupBox.SuspendLayout();
            this._musicLibraryDirectoryFormatGroupBox.SuspendLayout();
            this._coverArtGroupBox.SuspendLayout();
            this._converterGroupBox.SuspendLayout();
            this._converterCommandLineGroupBox.SuspendLayout();
            this._fileNameFormatGroupBox.SuspendLayout();
            this._fileNameFormatVariousArtistsGroupBox.SuspendLayout();
            this._metadataFixesGroupBox.SuspendLayout();
            this._sourceFilterGroupBox.SuspendLayout();
            this._coverArtFileNameFormatGroupBox.SuspendLayout();
            this._coverArtExtensionsGroupBox.SuspendLayout();
            this._converterExtensionGroupBox.SuspendLayout();
            this._musicLibraryDirectoryGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _sourceDirectoryGroupBox
            // 
            this._sourceDirectoryGroupBox.Controls.Add(this._sourceDirectoryBrowseButton);
            this._sourceDirectoryGroupBox.Controls.Add(this._sourceDirectoryTextBox);
            this._sourceDirectoryGroupBox.Location = new System.Drawing.Point(12, 12);
            this._sourceDirectoryGroupBox.Name = "_sourceDirectoryGroupBox";
            this._sourceDirectoryGroupBox.Size = new System.Drawing.Size(530, 74);
            this._sourceDirectoryGroupBox.TabIndex = 0;
            this._sourceDirectoryGroupBox.TabStop = false;
            this._sourceDirectoryGroupBox.Text = "Source Directory";
            // 
            // _sourceDirectoryBrowseButton
            // 
            this._sourceDirectoryBrowseButton.Location = new System.Drawing.Point(430, 29);
            this._sourceDirectoryBrowseButton.Name = "_sourceDirectoryBrowseButton";
            this._sourceDirectoryBrowseButton.Size = new System.Drawing.Size(94, 34);
            this._sourceDirectoryBrowseButton.TabIndex = 1;
            this._sourceDirectoryBrowseButton.Text = "&Browse...";
            this._sourceDirectoryBrowseButton.UseVisualStyleBackColor = true;
            this._sourceDirectoryBrowseButton.Click += new System.EventHandler(this._sourceDirectoryBrowseButton_Click);
            // 
            // _sourceDirectoryTextBox
            // 
            this._sourceDirectoryTextBox.Location = new System.Drawing.Point(7, 31);
            this._sourceDirectoryTextBox.Name = "_sourceDirectoryTextBox";
            this._sourceDirectoryTextBox.Size = new System.Drawing.Size(417, 31);
            this._sourceDirectoryTextBox.TabIndex = 0;
            this._sourceDirectoryTextBox.TextChanged += new System.EventHandler(this._sourceDirectoryTextBox_TextChanged);
            // 
            // _musicLibraryDirectoryFormatGroupBox
            // 
            this._musicLibraryDirectoryFormatGroupBox.Controls.Add(this._musicLibraryPathFormatTextBox);
            this._musicLibraryDirectoryFormatGroupBox.Location = new System.Drawing.Point(555, 92);
            this._musicLibraryDirectoryFormatGroupBox.Name = "_musicLibraryDirectoryFormatGroupBox";
            this._musicLibraryDirectoryFormatGroupBox.Size = new System.Drawing.Size(524, 74);
            this._musicLibraryDirectoryFormatGroupBox.TabIndex = 1;
            this._musicLibraryDirectoryFormatGroupBox.TabStop = false;
            this._musicLibraryDirectoryFormatGroupBox.Text = "Sub-directory Format";
            // 
            // _musicLibraryPathFormatTextBox
            // 
            this._musicLibraryPathFormatTextBox.Location = new System.Drawing.Point(7, 31);
            this._musicLibraryPathFormatTextBox.Name = "_musicLibraryPathFormatTextBox";
            this._musicLibraryPathFormatTextBox.Size = new System.Drawing.Size(511, 31);
            this._musicLibraryPathFormatTextBox.TabIndex = 0;
            this._musicLibraryPathFormatTextBox.TextChanged += new System.EventHandler(this._musicLibraryDirectoryFormatTextBox_TextChanged);
            // 
            // _coverArtGroupBox
            // 
            this._coverArtGroupBox.Controls.Add(this._coverArtBrowseButton);
            this._coverArtGroupBox.Controls.Add(this._coverArtTextBox);
            this._coverArtGroupBox.Location = new System.Drawing.Point(12, 172);
            this._coverArtGroupBox.Name = "_coverArtGroupBox";
            this._coverArtGroupBox.Size = new System.Drawing.Size(524, 74);
            this._coverArtGroupBox.TabIndex = 2;
            this._coverArtGroupBox.TabStop = false;
            this._coverArtGroupBox.Text = "Cover Art Directory";
            // 
            // _coverArtBrowseButton
            // 
            this._coverArtBrowseButton.Location = new System.Drawing.Point(424, 28);
            this._coverArtBrowseButton.Name = "_coverArtBrowseButton";
            this._coverArtBrowseButton.Size = new System.Drawing.Size(94, 34);
            this._coverArtBrowseButton.TabIndex = 1;
            this._coverArtBrowseButton.Text = "&Browse...";
            this._coverArtBrowseButton.UseVisualStyleBackColor = true;
            this._coverArtBrowseButton.Click += new System.EventHandler(this._coverArtBrowseButton_Click);
            // 
            // _coverArtTextBox
            // 
            this._coverArtTextBox.Location = new System.Drawing.Point(7, 31);
            this._coverArtTextBox.Name = "_coverArtTextBox";
            this._coverArtTextBox.Size = new System.Drawing.Size(411, 31);
            this._coverArtTextBox.TabIndex = 0;
            this._coverArtTextBox.TextChanged += new System.EventHandler(this._coverArtTextBox_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 31);
            this.textBox1.TabIndex = 0;
            // 
            // _converterGroupBox
            // 
            this._converterGroupBox.Controls.Add(this._converterBrowseButton);
            this._converterGroupBox.Controls.Add(this._converterExecutableTextBox);
            this._converterGroupBox.Location = new System.Drawing.Point(12, 252);
            this._converterGroupBox.Name = "_converterGroupBox";
            this._converterGroupBox.Size = new System.Drawing.Size(524, 74);
            this._converterGroupBox.TabIndex = 3;
            this._converterGroupBox.TabStop = false;
            this._converterGroupBox.Text = "Converter Executable";
            // 
            // _converterBrowseButton
            // 
            this._converterBrowseButton.Location = new System.Drawing.Point(424, 29);
            this._converterBrowseButton.Name = "_converterBrowseButton";
            this._converterBrowseButton.Size = new System.Drawing.Size(94, 34);
            this._converterBrowseButton.TabIndex = 1;
            this._converterBrowseButton.Text = "&Browse...";
            this._converterBrowseButton.UseVisualStyleBackColor = true;
            this._converterBrowseButton.Click += new System.EventHandler(this._converterBrowseButton_Click);
            // 
            // _converterExecutableTextBox
            // 
            this._converterExecutableTextBox.Location = new System.Drawing.Point(7, 31);
            this._converterExecutableTextBox.Name = "_converterExecutableTextBox";
            this._converterExecutableTextBox.Size = new System.Drawing.Size(411, 31);
            this._converterExecutableTextBox.TabIndex = 0;
            this._converterExecutableTextBox.TextChanged += new System.EventHandler(this._converterTextBox_TextChanged);
            // 
            // _converterCommandLineGroupBox
            // 
            this._converterCommandLineGroupBox.Controls.Add(this._converterCommandLineTextBox);
            this._converterCommandLineGroupBox.Location = new System.Drawing.Point(549, 254);
            this._converterCommandLineGroupBox.Name = "_converterCommandLineGroupBox";
            this._converterCommandLineGroupBox.Size = new System.Drawing.Size(300, 74);
            this._converterCommandLineGroupBox.TabIndex = 4;
            this._converterCommandLineGroupBox.TabStop = false;
            this._converterCommandLineGroupBox.Text = "Converter Command Line";
            // 
            // _converterCommandLineTextBox
            // 
            this._converterCommandLineTextBox.Location = new System.Drawing.Point(7, 31);
            this._converterCommandLineTextBox.Name = "_converterCommandLineTextBox";
            this._converterCommandLineTextBox.Size = new System.Drawing.Size(287, 31);
            this._converterCommandLineTextBox.TabIndex = 0;
            this._converterCommandLineTextBox.TextChanged += new System.EventHandler(this._converterCommandLineTextBox_TextChanged);
            // 
            // _fileNameFormatGroupBox
            // 
            this._fileNameFormatGroupBox.Controls.Add(this._fileNameFormatTextBox);
            this._fileNameFormatGroupBox.Location = new System.Drawing.Point(12, 332);
            this._fileNameFormatGroupBox.Name = "_fileNameFormatGroupBox";
            this._fileNameFormatGroupBox.Size = new System.Drawing.Size(524, 74);
            this._fileNameFormatGroupBox.TabIndex = 5;
            this._fileNameFormatGroupBox.TabStop = false;
            this._fileNameFormatGroupBox.Text = "File Name Format";
            // 
            // _fileNameFormatTextBox
            // 
            this._fileNameFormatTextBox.Location = new System.Drawing.Point(7, 31);
            this._fileNameFormatTextBox.Name = "_fileNameFormatTextBox";
            this._fileNameFormatTextBox.Size = new System.Drawing.Size(511, 31);
            this._fileNameFormatTextBox.TabIndex = 0;
            this._fileNameFormatTextBox.TextChanged += new System.EventHandler(this._fileNameFormatTextBox_TextChanged);
            // 
            // _fileNameFormatVariousArtistsGroupBox
            // 
            this._fileNameFormatVariousArtistsGroupBox.Controls.Add(this._fileNameFormatVariousArtistsTextBox);
            this._fileNameFormatVariousArtistsGroupBox.Location = new System.Drawing.Point(549, 334);
            this._fileNameFormatVariousArtistsGroupBox.Name = "_fileNameFormatVariousArtistsGroupBox";
            this._fileNameFormatVariousArtistsGroupBox.Size = new System.Drawing.Size(524, 74);
            this._fileNameFormatVariousArtistsGroupBox.TabIndex = 6;
            this._fileNameFormatVariousArtistsGroupBox.TabStop = false;
            this._fileNameFormatVariousArtistsGroupBox.Text = "File Name Format (Various Artists)";
            // 
            // _fileNameFormatVariousArtistsTextBox
            // 
            this._fileNameFormatVariousArtistsTextBox.Location = new System.Drawing.Point(7, 31);
            this._fileNameFormatVariousArtistsTextBox.Name = "_fileNameFormatVariousArtistsTextBox";
            this._fileNameFormatVariousArtistsTextBox.Size = new System.Drawing.Size(511, 31);
            this._fileNameFormatVariousArtistsTextBox.TabIndex = 0;
            this._fileNameFormatVariousArtistsTextBox.TextChanged += new System.EventHandler(this._fileNameFormatVariousArtistsTextBox_TextChanged);
            // 
            // _startButton
            // 
            this._startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._startButton.Location = new System.Drawing.Point(483, 505);
            this._startButton.Name = "_startButton";
            this._startButton.Size = new System.Drawing.Size(112, 34);
            this._startButton.TabIndex = 7;
            this._startButton.Text = "&Start";
            this._startButton.UseVisualStyleBackColor = true;
            this._startButton.Click += new System.EventHandler(this._startButton_Click);
            // 
            // _metadataFixesGroupBox
            // 
            this._metadataFixesGroupBox.Controls.Add(this._fillInTotalTracksCheckBox);
            this._metadataFixesGroupBox.Controls.Add(this._convertCheckBox);
            this._metadataFixesGroupBox.Controls.Add(this._oneDiscCheckBox);
            this._metadataFixesGroupBox.Controls.Add(this._coverArtCheckBox);
            this._metadataFixesGroupBox.Controls.Add(this._moveToLibraryCheckBox);
            this._metadataFixesGroupBox.Controls.Add(this._moveTheCheckBox);
            this._metadataFixesGroupBox.Controls.Add(this._artistConflictFixerCheckBox);
            this._metadataFixesGroupBox.Controls.Add(this._renameCheckBox);
            this._metadataFixesGroupBox.Location = new System.Drawing.Point(12, 412);
            this._metadataFixesGroupBox.Name = "_metadataFixesGroupBox";
            this._metadataFixesGroupBox.Size = new System.Drawing.Size(1061, 82);
            this._metadataFixesGroupBox.TabIndex = 8;
            this._metadataFixesGroupBox.TabStop = false;
            this._metadataFixesGroupBox.Text = "Fixes";
            // 
            // _oneDiscCheckBox
            // 
            this._oneDiscCheckBox.AutoSize = true;
            this._oneDiscCheckBox.Location = new System.Drawing.Point(412, 31);
            this._oneDiscCheckBox.Name = "_oneDiscCheckBox";
            this._oneDiscCheckBox.Size = new System.Drawing.Size(86, 29);
            this._oneDiscCheckBox.TabIndex = 3;
            this._oneDiscCheckBox.Text = "1 Disc";
            this._oneDiscCheckBox.UseVisualStyleBackColor = true;
            this._oneDiscCheckBox.CheckedChanged += new System.EventHandler(this._oneDiscCheckBox_CheckedChanged);
            // 
            // _coverArtCheckBox
            // 
            this._coverArtCheckBox.AutoSize = true;
            this._coverArtCheckBox.Location = new System.Drawing.Point(298, 31);
            this._coverArtCheckBox.Name = "_coverArtCheckBox";
            this._coverArtCheckBox.Size = new System.Drawing.Size(113, 29);
            this._coverArtCheckBox.TabIndex = 2;
            this._coverArtCheckBox.Text = "Cover Art";
            this._coverArtCheckBox.UseVisualStyleBackColor = true;
            this._coverArtCheckBox.CheckedChanged += new System.EventHandler(this._coverArtCheckBox_CheckedChanged);
            // 
            // _moveTheCheckBox
            // 
            this._moveTheCheckBox.AutoSize = true;
            this._moveTheCheckBox.Location = new System.Drawing.Point(167, 31);
            this._moveTheCheckBox.Name = "_moveTheCheckBox";
            this._moveTheCheckBox.Size = new System.Drawing.Size(124, 29);
            this._moveTheCheckBox.TabIndex = 1;
            this._moveTheCheckBox.Text = "Move \'The\'";
            this._moveTheCheckBox.UseVisualStyleBackColor = true;
            this._moveTheCheckBox.CheckedChanged += new System.EventHandler(this._moveTheCheckBox_CheckedChanged);
            // 
            // _artistConflictFixerCheckBox
            // 
            this._artistConflictFixerCheckBox.AutoSize = true;
            this._artistConflictFixerCheckBox.Location = new System.Drawing.Point(7, 31);
            this._artistConflictFixerCheckBox.Name = "_artistConflictFixerCheckBox";
            this._artistConflictFixerCheckBox.Size = new System.Drawing.Size(153, 29);
            this._artistConflictFixerCheckBox.TabIndex = 0;
            this._artistConflictFixerCheckBox.Text = "Artist Conflicts";
            this._artistConflictFixerCheckBox.UseVisualStyleBackColor = true;
            this._artistConflictFixerCheckBox.CheckedChanged += new System.EventHandler(this._artistConflictFixerCheckBox_CheckedChanged);
            // 
            // _convertCheckBox
            // 
            this._convertCheckBox.AutoSize = true;
            this._convertCheckBox.Location = new System.Drawing.Point(955, 31);
            this._convertCheckBox.Name = "_convertCheckBox";
            this._convertCheckBox.Size = new System.Drawing.Size(100, 29);
            this._convertCheckBox.TabIndex = 2;
            this._convertCheckBox.Text = "Convert";
            this._convertCheckBox.UseVisualStyleBackColor = true;
            this._convertCheckBox.CheckedChanged += new System.EventHandler(this._convertCheckBox_CheckedChanged);
            // 
            // _moveToLibraryCheckBox
            // 
            this._moveToLibraryCheckBox.AutoSize = true;
            this._moveToLibraryCheckBox.Location = new System.Drawing.Point(786, 31);
            this._moveToLibraryCheckBox.Name = "_moveToLibraryCheckBox";
            this._moveToLibraryCheckBox.Size = new System.Drawing.Size(163, 29);
            this._moveToLibraryCheckBox.TabIndex = 1;
            this._moveToLibraryCheckBox.Text = "Move to Library";
            this._moveToLibraryCheckBox.UseVisualStyleBackColor = true;
            this._moveToLibraryCheckBox.CheckedChanged += new System.EventHandler(this._moveToLibraryCheckBox_CheckedChanged);
            // 
            // _renameCheckBox
            // 
            this._renameCheckBox.AutoSize = true;
            this._renameCheckBox.Location = new System.Drawing.Point(679, 31);
            this._renameCheckBox.Name = "_renameCheckBox";
            this._renameCheckBox.Size = new System.Drawing.Size(101, 29);
            this._renameCheckBox.TabIndex = 0;
            this._renameCheckBox.Text = "Rename";
            this._renameCheckBox.UseVisualStyleBackColor = true;
            this._renameCheckBox.CheckedChanged += new System.EventHandler(this._renameCheckBox_CheckedChanged);
            // 
            // _sourceFilterGroupBox
            // 
            this._sourceFilterGroupBox.Controls.Add(this._sourceFilterTextBox);
            this._sourceFilterGroupBox.Location = new System.Drawing.Point(556, 12);
            this._sourceFilterGroupBox.Name = "_sourceFilterGroupBox";
            this._sourceFilterGroupBox.Size = new System.Drawing.Size(172, 77);
            this._sourceFilterGroupBox.TabIndex = 10;
            this._sourceFilterGroupBox.TabStop = false;
            this._sourceFilterGroupBox.Text = "Source Filter";
            // 
            // _sourceFilterTextBox
            // 
            this._sourceFilterTextBox.Location = new System.Drawing.Point(7, 31);
            this._sourceFilterTextBox.Name = "_sourceFilterTextBox";
            this._sourceFilterTextBox.Size = new System.Drawing.Size(159, 31);
            this._sourceFilterTextBox.TabIndex = 0;
            // 
            // _coverArtFileNameFormatGroupBox
            // 
            this._coverArtFileNameFormatGroupBox.Controls.Add(this._coverArtFileNameFormatTextBox);
            this._coverArtFileNameFormatGroupBox.Location = new System.Drawing.Point(549, 172);
            this._coverArtFileNameFormatGroupBox.Name = "_coverArtFileNameFormatGroupBox";
            this._coverArtFileNameFormatGroupBox.Size = new System.Drawing.Size(300, 76);
            this._coverArtFileNameFormatGroupBox.TabIndex = 11;
            this._coverArtFileNameFormatGroupBox.TabStop = false;
            this._coverArtFileNameFormatGroupBox.Text = "Cover Art File Name Format";
            // 
            // _coverArtFileNameFormatTextBox
            // 
            this._coverArtFileNameFormatTextBox.Location = new System.Drawing.Point(6, 30);
            this._coverArtFileNameFormatTextBox.Name = "_coverArtFileNameFormatTextBox";
            this._coverArtFileNameFormatTextBox.Size = new System.Drawing.Size(288, 31);
            this._coverArtFileNameFormatTextBox.TabIndex = 0;
            this._coverArtFileNameFormatTextBox.TextChanged += new System.EventHandler(this._coverArtFileNameFormatTextBox_TextChanged);
            // 
            // _coverArtExtensionsGroupBox
            // 
            this._coverArtExtensionsGroupBox.Controls.Add(this._coverArtExtensionsTextBox);
            this._coverArtExtensionsGroupBox.Location = new System.Drawing.Point(855, 178);
            this._coverArtExtensionsGroupBox.Name = "_coverArtExtensionsGroupBox";
            this._coverArtExtensionsGroupBox.Size = new System.Drawing.Size(218, 70);
            this._coverArtExtensionsGroupBox.TabIndex = 12;
            this._coverArtExtensionsGroupBox.TabStop = false;
            this._coverArtExtensionsGroupBox.Text = "Covert Art Extensions";
            // 
            // _coverArtExtensionsTextBox
            // 
            this._coverArtExtensionsTextBox.Location = new System.Drawing.Point(6, 25);
            this._coverArtExtensionsTextBox.Name = "_coverArtExtensionsTextBox";
            this._coverArtExtensionsTextBox.Size = new System.Drawing.Size(206, 31);
            this._coverArtExtensionsTextBox.TabIndex = 0;
            this._coverArtExtensionsTextBox.TextChanged += new System.EventHandler(this._coverArtExtensionsTextBox_TextChanged);
            // 
            // _converterExtensionGroupBox
            // 
            this._converterExtensionGroupBox.Controls.Add(this._converterExtensionTextBox);
            this._converterExtensionGroupBox.Location = new System.Drawing.Point(857, 256);
            this._converterExtensionGroupBox.Name = "_converterExtensionGroupBox";
            this._converterExtensionGroupBox.Size = new System.Drawing.Size(216, 72);
            this._converterExtensionGroupBox.TabIndex = 13;
            this._converterExtensionGroupBox.TabStop = false;
            this._converterExtensionGroupBox.Text = "Extension";
            // 
            // _converterExtensionTextBox
            // 
            this._converterExtensionTextBox.Location = new System.Drawing.Point(6, 27);
            this._converterExtensionTextBox.Name = "_converterExtensionTextBox";
            this._converterExtensionTextBox.Size = new System.Drawing.Size(204, 31);
            this._converterExtensionTextBox.TabIndex = 0;
            this._converterExtensionTextBox.TextChanged += new System.EventHandler(this._converterExtensionTextBox_TextChanged);
            // 
            // _musicLibraryDirectoryGroupBox
            // 
            this._musicLibraryDirectoryGroupBox.Controls.Add(this._musicLibraryDirectoryBrowseButton);
            this._musicLibraryDirectoryGroupBox.Controls.Add(this._musicLibraryDirectoryTextBox);
            this._musicLibraryDirectoryGroupBox.Location = new System.Drawing.Point(18, 92);
            this._musicLibraryDirectoryGroupBox.Name = "_musicLibraryDirectoryGroupBox";
            this._musicLibraryDirectoryGroupBox.Size = new System.Drawing.Size(524, 74);
            this._musicLibraryDirectoryGroupBox.TabIndex = 14;
            this._musicLibraryDirectoryGroupBox.TabStop = false;
            this._musicLibraryDirectoryGroupBox.Text = "Music Library Directory";
            // 
            // _musicLibraryDirectoryBrowseButton
            // 
            this._musicLibraryDirectoryBrowseButton.Location = new System.Drawing.Point(424, 29);
            this._musicLibraryDirectoryBrowseButton.Name = "_musicLibraryDirectoryBrowseButton";
            this._musicLibraryDirectoryBrowseButton.Size = new System.Drawing.Size(94, 34);
            this._musicLibraryDirectoryBrowseButton.TabIndex = 1;
            this._musicLibraryDirectoryBrowseButton.Text = "&Browse...";
            this._musicLibraryDirectoryBrowseButton.UseVisualStyleBackColor = true;
            this._musicLibraryDirectoryBrowseButton.Click += new System.EventHandler(this._musicLibraryDirectoryBrowseButton_Click);
            // 
            // _musicLibraryDirectoryTextBox
            // 
            this._musicLibraryDirectoryTextBox.Location = new System.Drawing.Point(7, 31);
            this._musicLibraryDirectoryTextBox.Name = "_musicLibraryDirectoryTextBox";
            this._musicLibraryDirectoryTextBox.Size = new System.Drawing.Size(411, 31);
            this._musicLibraryDirectoryTextBox.TabIndex = 0;
            this._musicLibraryDirectoryTextBox.TextChanged += new System.EventHandler(this._musicLibraryDirectoryTextBox_TextChanged);
            // 
            // _fillInTotalTracksCheckBox
            // 
            this._fillInTotalTracksCheckBox.AutoSize = true;
            this._fillInTotalTracksCheckBox.Location = new System.Drawing.Point(504, 31);
            this._fillInTotalTracksCheckBox.Name = "_fillInTotalTracksCheckBox";
            this._fillInTotalTracksCheckBox.Size = new System.Drawing.Size(127, 29);
            this._fillInTotalTracksCheckBox.TabIndex = 4;
            this._fillInTotalTracksCheckBox.Text = "Total Tracks";
            this._fillInTotalTracksCheckBox.UseVisualStyleBackColor = true;
            this._fillInTotalTracksCheckBox.CheckedChanged += new System.EventHandler(this._fillInTotalTracksCheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 551);
            this.Controls.Add(this._musicLibraryDirectoryGroupBox);
            this.Controls.Add(this._converterExtensionGroupBox);
            this.Controls.Add(this._coverArtExtensionsGroupBox);
            this.Controls.Add(this._coverArtFileNameFormatGroupBox);
            this.Controls.Add(this._sourceFilterGroupBox);
            this.Controls.Add(this._metadataFixesGroupBox);
            this.Controls.Add(this._startButton);
            this.Controls.Add(this._fileNameFormatVariousArtistsGroupBox);
            this.Controls.Add(this._fileNameFormatGroupBox);
            this.Controls.Add(this._converterCommandLineGroupBox);
            this.Controls.Add(this._converterGroupBox);
            this.Controls.Add(this._coverArtGroupBox);
            this.Controls.Add(this._musicLibraryDirectoryFormatGroupBox);
            this.Controls.Add(this._sourceDirectoryGroupBox);
            this.Name = "MainForm";
            this.Text = "Fix Music";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this._sourceDirectoryGroupBox.ResumeLayout(false);
            this._sourceDirectoryGroupBox.PerformLayout();
            this._musicLibraryDirectoryFormatGroupBox.ResumeLayout(false);
            this._musicLibraryDirectoryFormatGroupBox.PerformLayout();
            this._coverArtGroupBox.ResumeLayout(false);
            this._coverArtGroupBox.PerformLayout();
            this._converterGroupBox.ResumeLayout(false);
            this._converterGroupBox.PerformLayout();
            this._converterCommandLineGroupBox.ResumeLayout(false);
            this._converterCommandLineGroupBox.PerformLayout();
            this._fileNameFormatGroupBox.ResumeLayout(false);
            this._fileNameFormatGroupBox.PerformLayout();
            this._fileNameFormatVariousArtistsGroupBox.ResumeLayout(false);
            this._fileNameFormatVariousArtistsGroupBox.PerformLayout();
            this._metadataFixesGroupBox.ResumeLayout(false);
            this._metadataFixesGroupBox.PerformLayout();
            this._sourceFilterGroupBox.ResumeLayout(false);
            this._sourceFilterGroupBox.PerformLayout();
            this._coverArtFileNameFormatGroupBox.ResumeLayout(false);
            this._coverArtFileNameFormatGroupBox.PerformLayout();
            this._coverArtExtensionsGroupBox.ResumeLayout(false);
            this._coverArtExtensionsGroupBox.PerformLayout();
            this._converterExtensionGroupBox.ResumeLayout(false);
            this._converterExtensionGroupBox.PerformLayout();
            this._musicLibraryDirectoryGroupBox.ResumeLayout(false);
            this._musicLibraryDirectoryGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _sourceDirectoryGroupBox;
        private System.Windows.Forms.TextBox _sourceDirectoryTextBox;
        private System.Windows.Forms.Button _sourceDirectoryBrowseButton;
        private System.Windows.Forms.GroupBox _musicLibraryDirectoryFormatGroupBox;
        private System.Windows.Forms.TextBox _musicLibraryPathFormatTextBox;
        private System.Windows.Forms.GroupBox _coverArtGroupBox;
        private System.Windows.Forms.Button _coverArtBrowseButton;
        private System.Windows.Forms.TextBox _coverArtTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox _converterGroupBox;
        private System.Windows.Forms.Button _converterBrowseButton;
        private System.Windows.Forms.TextBox _converterExecutableTextBox;
        private System.Windows.Forms.GroupBox _converterCommandLineGroupBox;
        private System.Windows.Forms.TextBox _converterCommandLineTextBox;
        private System.Windows.Forms.GroupBox _fileNameFormatGroupBox;
        private System.Windows.Forms.TextBox _fileNameFormatTextBox;
        private System.Windows.Forms.GroupBox _fileNameFormatVariousArtistsGroupBox;
        private System.Windows.Forms.TextBox _fileNameFormatVariousArtistsTextBox;
        private System.Windows.Forms.Button _startButton;
        private System.Windows.Forms.GroupBox _metadataFixesGroupBox;
        private System.Windows.Forms.CheckBox _artistConflictFixerCheckBox;
        private System.Windows.Forms.CheckBox _moveTheCheckBox;
        private System.Windows.Forms.CheckBox _oneDiscCheckBox;
        private System.Windows.Forms.CheckBox _coverArtCheckBox;
        private System.Windows.Forms.CheckBox _convertCheckBox;
        private System.Windows.Forms.CheckBox _moveToLibraryCheckBox;
        private System.Windows.Forms.CheckBox _renameCheckBox;
        private System.Windows.Forms.GroupBox _sourceFilterGroupBox;
        private System.Windows.Forms.TextBox _sourceFilterTextBox;
        private System.Windows.Forms.GroupBox _coverArtFileNameFormatGroupBox;
        private System.Windows.Forms.TextBox _coverArtFileNameFormatTextBox;
        private System.Windows.Forms.GroupBox _coverArtExtensionsGroupBox;
        private System.Windows.Forms.TextBox _coverArtExtensionsTextBox;
        private System.Windows.Forms.GroupBox _converterExtensionGroupBox;
        private System.Windows.Forms.TextBox _converterExtensionTextBox;
        private System.Windows.Forms.GroupBox _musicLibraryDirectoryGroupBox;
        private System.Windows.Forms.Button _musicLibraryDirectoryBrowseButton;
        private System.Windows.Forms.TextBox _musicLibraryDirectoryTextBox;
        private System.Windows.Forms.CheckBox _fillInTotalTracksCheckBox;
    }
}