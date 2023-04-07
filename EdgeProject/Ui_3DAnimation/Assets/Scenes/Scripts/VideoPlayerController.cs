using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private void Start()
    {
        // Make sure the video player is set to play on awake
        videoPlayer.playOnAwake = false;
    }

    public void Play()
    {
        videoPlayer.Play();
    }

    public void Pause()
    {
        videoPlayer.Pause();
    }

    public void Resume()
    {
        videoPlayer.Play();
    }

    public void Stop()
    {
        videoPlayer.Stop();
    }
}
