# MediaWrapper

[![Coverage Status](https://coveralls.io/repos/github/jgozner/MediaWrapper/badge.svg?branch=master)](https://coveralls.io/github/jgozner/MediaWrapper?branch=master)  ![Nuget](https://img.shields.io/nuget/v/MediaWrapper) 

## Install

Install from Github nuget.org 

```xml
PM> Install-Package MediaWrapper
```

## Usage

### Get Media (Audio/Video/Subtitle) Properties 
```csharp
IMediaInfo info = await MediaInfo.Get(@"A:\clip.mkv");

var audio = info.AudioTrack.First();
var video = info.VideoTracks.First();
var subtitle = info.SubtitleTracks.First();
```

### Extract Tracks
```csharp
IMediaInfo info = await MediaInfo.Get(@"A:\clip.mkv");

var videoTrack = info.VideoTracks.First();

IExtractionResult result = await Extraction.New(ExtractionMode.Tracks)
                                        .SetInputFile(info.FileInfo.FullName)
                                        .AddTrack(videoTrack)
                                        .Start()
                                        .ConfigureAwait(false);

// Can access the extracted file like this.
var file = videoTrack.FileInfo. 
```