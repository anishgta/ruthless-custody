using UnityEngine;
using UnityEngine.Video;

public class IntroManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer.loopPointReached += VideoFinished;
    }

    private void VideoFinished(VideoPlayer video)
    {
        TransitionManager.Instance.DissolveToScene("Menu");
    }

    private void OnDestroy()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= VideoFinished;
        }
    }
}