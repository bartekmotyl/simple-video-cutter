# Video cutting challenges
This article explains why cutting (extracting) portions of a video file turns out not to be as simple as it seems. 


## Audio and video tracks
A typical digital video file usually consists of at least one video track and one audio track. Video and audio data in these tracks are encoded (compressed) by a codec - a special algorithm that performs compression of original audio/video data into format that requires much, much less space. (see [https://en.wikipedia.org/wiki/Video_coding_format]). Usually, codecs are lossy, but lossless codecs are also in use. 
Which codec is used to encode data in your file depends mainly on how the file was recorded (e.g. by your mobile phone, action camera, drone, etc.) and whether it was edited or not. 

## Lossless cut 


## Frames
Video track is a sequence of frames (still images), for example every second of video may contain 25 or 50 frames. As one can easily calculate, even a short video file contains plenty of frames. 
In most of codecs, it is possible to simply truncate video stream at any frame without problems, because each frame is encoded separately. For modern codecs (e.g. h264), this is unfortunately no longer true, because these codecs encode frames using only differential information between this frame and next/prev frame (see details in https://en.wikipedia.org/wiki/Video_compression_picture_types). In case of these codes  



`aaa`