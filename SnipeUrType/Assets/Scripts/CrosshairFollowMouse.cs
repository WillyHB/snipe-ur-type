using UnityEngine;

public class CrosshairFollowMouse : MonoBehaviour
{
    private RectTransform rect;

    private void Awake()
    {
            rect = GetComponent<RectTransform>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        ApplyCursorState();
        StartCoroutine(ApplyNextFrame());
    }

    private System.Collections.IEnumerator ApplyNextFrame()
    {
        yield return null;
        ApplyCursorState();
    }

    private void ApplyCursorState()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
    // Update is called once per frame
    private void Update()
    {
        rect.position = Input.mousePosition;
    }
}
