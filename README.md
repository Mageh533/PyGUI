<div align="center">
  <p>
    <img src="images/pytubelogotext.png" width="512" height="251" alt="pygui logo" />
  </p>
</div>

# PyGUI

A PyGUI is a dot net based GUI application that uses tools such as Pytube and FFmpeg to download and convert videos from YouTube. The purpose of this is to provide a simple and easy to use GUI for downloading and converting videos from YouTube all within a single application and without having to rely on external sites or cmd based tools.

## Features

	- Download videos from YouTube using Pytube
	- Convert videos to whatever format you want using FFmpeg
	- Simple and easy to use GUI
	- No need to install any dependencies or external tools, everything is already included

## Installation

To install the PyGUI, simply download the latest release from the [releases page](https://github.com/Mageh533/PyGUI/releases) and run PyGUI.exe.

## Building

If you want to build the PyGUI yourself, you can do so by cloning the repository, ensure that you have the latest version of Python 3 and Pip and install PyInstaller using the following command:

```bash
pip install pyinstaller
```

Then open the solution in Visual Studio 2022 and build the project. It should compile all the required python files into a single executable file from the pytube submodule and the FFmpeg binaries.

## Credits

	- Pytube: https://pytube.io/en/latest/
	- FFmpeg: https://ffmpeg.org/
