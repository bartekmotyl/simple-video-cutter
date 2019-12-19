# simple-video-cutter

Windows-based tool for efficient browsing and cutting video footage

![Screenshot](screenshot.png)

## Goal

Let's imagine you have hours of video footage, dozens of files (videos from your vacations, material copied from your action camera or a drone etc.). 
Usually only a small portion of this material is worth keeping. So you would like to check the whole material and extract the most interesting/best 
parts as separate videos. And this is where the simple-video-cutter tool comes in. It helps you to quickly browse the videos, preview them and 
extract interesting parts into separate video files. 

The main goal is to make this process as efficient as possible. 
You don't have to select the next file from disk manually, just press "next" and next file (ordered by date) is loaded automatically. 
Location and filenames of created video cuts are assigned automatically basing on patterns specified in the configuration. 
The extraction process is done in background (by ffmpeg), so you can work with next material whilst the previous tasks are being processed. 

## How to use 

### Starting for the first time: 

- Download the release by [clicking here](https://github.com/bartekmotyl/simple-video-cutter/releases)
- Unzip release package into a directory 
- Start `SimpleVideoCutter.exe` in that directory
- Once prompted, select location of ffmpeg.exe (FFmpeg can be downloaded for free from [FFmpeg release page](https://ffmpeg.zeranoe.com/builds/)   
- You can also adjust other parameters in settings window, for example directory and filename pattern of the output files. Supported variables are: 
	- `{FileName}` - name of the input video file (with extension)
	- `{FileNameWithoutExtension}` - name of the input video file (without extension)
	- `{FileExtension}` - extension of the input video file (with dot)
	- `{FileDate}` - last modification date of the input file (in format `yyyy-MM-dd-HHmmss`)
	- `{Timestamp}` - current timestamp (in format `yyyyMMddHHmmss`)
	- `{UserVideos}` - shortcut for `Environment.SpecialFolder.MyVideos`
	- `{UserDocuments}` - shortcut for `Environment.SpecialFolder.MyDocuments`
	- `{MyComputer}` - shortcut for `Environment.SpecialFolder.MyComputer`
- Click OK to save settings. Setting are saved in `config.json` file and can be edited manually (but please be aware settings file is overwritten when program closes).  
	
### Working with the tool:
- Open a video file 
- The video playback starts automatically; press space to pause/resume (or click in the video area)
- You can navigate back and forth through video using timeline control at the botom of the screen. Use mouse wheel (with control key pressed) to zoom in and out the timeline. Mouse wheel without control key scrolls the timeline forward and backward. Press shift key for even faster scrolling/zooming. 
- Select a position and press `[` (or click the correspnding button) to mark start of your cut  
- Press `]` to mark end of your cut 
- Press `E` (or click 'Enqueue' button) to add task to the queue. 
  FFmpeg will be used to extract selected portion of the video and save it in a new file. 
- In tasks lists you can inspect pending and running tasks. Tasks are processed automatically and disappear once completed. 
Feel free to open next file (and add next tasks) while task is still in progress - they do not interfere with each other and just queue up. 
- Use Previos / Next buttons to quickly open next or previous file in the same directory. 

## To do
- support looseles cut 
- bundle ffmpeg with the program, do not require user to download it separatelly  
- allow to configure ffmpeg options (e.g. convert to a different format / size etc.) 
- extend list of variables that can be used in file patterns 
- jump to first/last video file in the current directory 
- jump to next/prev directory (sibling to current directory)
- ~~configure options in a dialog (currently one need to modify `config.json` file manually)~~
- ~~open dialog to select ffmpeg location~~ 
- ~~improve timeline control (show seconds ticks etc. )~~


## Known issues
- ~~sometimes the program freezes (how to fix: [see more here](https://github.com/ZeBobo5/Vlc.DotNet/wiki/Vlc.DotNet-freezes-(don't-call-Vlc.DotNet-from-a-Vlc.DotNet-callback)))~~
- lack of proper error handling in some border cases (IO errors etc.) 
- location on timeline not updated correctly when video reaches the end 
  (sometimes the marker stays a bit before the actual end). 
- small preview slide (on top to the hovered position) sometimes stucks and doesn't update with actual hovered frame any more. Known workaround: re-open the file.   

## Icons 

- [streamline icons](https://streamlineicons.com)
- [movie icon](https://www.freeiconspng.com/img/15157)
