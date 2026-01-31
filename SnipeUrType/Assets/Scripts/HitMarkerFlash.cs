using System.Collections;
using UnityEngine;

public class HitMarkerFlash : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float showTime = 0.15f;

    private Coroutine flashRoutine;

    private void Awake()
    {
        if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
        
        canvasGroup.alpha = 0f;
    }

    [ContextMenu("Flash")]
    public void Flash()
    {
        if (flashRoutine != null) StopCoroutine(flashRoutine);
        flashRoutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        canvasGroup.alpha = 1f;
        yield return new WaitForSeconds(showTime);
        canvasGroup.alpha = 0f;
        flashRoutine = null;
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
