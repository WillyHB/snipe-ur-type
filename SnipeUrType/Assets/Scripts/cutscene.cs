using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class cutscene : MonoBehaviour
{
    public string nextSceneName;

    private VideoPlayer videoPlayer;

    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoFinished;
        videoPlayer.Play();
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName);
    }
}