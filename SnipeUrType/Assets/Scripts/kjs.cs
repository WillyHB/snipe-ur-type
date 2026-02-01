using UnityEngine;
using UnityEngine.SceneManagement;

public class kjs : MonoBehaviour
{

    AudioSource audioSource;

    float timer = 0f;
    float speed = 5f;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        timer = 0f;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timer > 2.4f)
        {
            transform.localScale += Vector3.one * speed * Time.deltaTime;
        }

        if (Time.time - timer > 3.9f)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
