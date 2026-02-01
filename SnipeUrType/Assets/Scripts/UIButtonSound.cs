using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class UIButtonSound : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip clickSound;
    public AudioClip hoverSound;

    private AudioSource audioSource;
    private Button button;

    void Awake()
    {
        audioSource = FindObjectOfType<AudioSource>(); // global UI audio source
        button = GetComponent<Button>();

        button.onClick.AddListener(PlayClick);
    }

    void PlayClick()
    {
        if (clickSound != null)
            audioSource.PlayOneShot(clickSound);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSound != null)
            audioSource.PlayOneShot(hoverSound);
    }
}