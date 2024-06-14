import sys
from pytube import YouTube

first = str(sys.argv[1])
second = str(sys.argv[2])

def download_video(url, path):
    yt = YouTube(url)
    yt.streams.filter(progressive=True, file_extension='mp4').order_by('resolution').desc().first().download(path)

if __name__ == '__main__':
    download_video(first, second)

