import sys
from pytube import YouTube

mode = int(sys.argv[1])

def download_video(url, iRes, path):
    yt = YouTube(url)
    streamToDl = yt.streams.filter(resolution=iRes).order_by('resolution').first()
    if streamToDl.is_adaptive:
        yt.streams.filter(type="audio").first().download(path, "AUDIO-" + streamToDl.default_filename)
    streamToDl.download(path)

def get_video_details(url):
    yt = YouTube(url)
    video_res = []

    for stream in yt.streams:
        if not(stream.resolution in video_res):
            video_res.append(stream.resolution)

    # Make it easier to split this in c#
    stringToOutput = "title=" + yt.title + ";" + "thumb_url=" + yt.thumbnail_url + ";" + "resolutions=" + str(video_res)
     
    return stringToOutput

if __name__ == '__main__':
    if mode == 0:
        download_video(str(sys.argv[2]), str(sys.argv[3]), str(sys.argv[4]))
    elif mode == 1:
        print(get_video_details(sys.argv[2]))
