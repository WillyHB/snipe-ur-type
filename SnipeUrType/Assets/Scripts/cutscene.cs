using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class cutscene : MonoBehaviour
{
    public string nextSceneName;

    private VideoPlayer videoPlayer;
    private bool loading = false;

    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoFinished;
        videoPlayer.Play();
    }

    private void Update()
    {
        if (loading) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            loading = true;
            videoPlayer.Stop();
            SceneManager.LoadScene(nextSceneName);
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName);
    }
}