using UnityEngine;

public class NPCVisual : MonoBehaviour
{   
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite taggedSprite;

    private bool tagged;

    private void Awake()
    {
        if (sr == null) sr = GetComponent<SpriteRenderer>();
        if (normalSprite == null && sr != null) normalSprite = sr.sprite;
    }

    public void SetTagged(bool value)
    {
        tagged = value;
        if (sr == null) return;

        sr.sprite = tagged ? taggedSprite : normalSprite;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
