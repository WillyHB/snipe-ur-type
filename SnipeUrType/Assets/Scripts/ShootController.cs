using UnityEngine;
using UnityEngine.SceneManagement;


public class ShootController : MonoBehaviour
{
    public static System.Action<Person> OnPersonShot;  
    private bool hasShot;
    public GameObject BgMusicGameObject;

    [Header("Raycast")]
    [SerializeField] private Camera cam;
    [SerializeField] private float maxDistance = 100f;
    [SerializeField] private LayerMask hittableLayers = ~0;
    [SerializeField] private RectTransform crosshairUI;

    [Header("Feedback")]
    [SerializeField] private HitMarkerFlash hitMarker;
    [SerializeField] private GameObject LoveSplatter;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip hitSfx;
    [SerializeField] private AudioClip missSfx;

    void Awake ()
    {
        if (cam == null) cam = Camera.main;

        if (audioSource == null) audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    private void Shoot()
    {
        if (hasShot) return;
        Destroy(BgMusicGameObject);
        hasShot = true;

        if (cam == null)
        {
            Debug.LogError("ShootController: No camera assigned and no Camera.main found.");
            return;
        }

        Vector3 aimPos = crosshairUI != null ? crosshairUI.position : Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(aimPos);

        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, maxDistance, hittableLayers);

        if (hit.collider == null)
        {
            if (audioSource != null && missSfx != null) audioSource.PlayOneShot(missSfx);
            Debug.Log("Shot missed.");
            Timer timer1 = FindFirstObjectByType<Timer>();
            if (timer1 != null)
                timer1.StopTimer();

            var s = FindFirstObjectByType<ScoringSystem>();
            Debug.Log("ScoringSystem is " + (s == null ? "NULL" : "FOUND"));
            s?.Miss();
            return;
        }

        Person person = hit.collider.GetComponentInParent<Person>();

        if (person == null)
        {
            if (audioSource != null && missSfx != null) audioSource.PlayOneShot(missSfx);
            Debug.Log($"Hit {hit.collider.name}, but it has no Person component.");
            FindFirstObjectByType<ScoringSystem>()?.Miss();
            return;
        }

        if (audioSource != null && hitSfx != null) audioSource.PlayOneShot(hitSfx);
        Timer timer = FindFirstObjectByType<Timer>();
        if (timer != null)
            timer.StopTimer();

        OnPersonShot?.Invoke(person);

        Debug.Log("About to flash hit marker, hitMarker is " + (hitMarker == null ? "NULL" : "SET"));
        if (hitMarker != null) hitMarker.Flash();
        

        var vis = person.GetComponentInChildren<NPCVisual>();
        if (vis != null) vis.SetTagged(true);
        
        foreach (var col in person.GetComponentsInChildren<Collider2D>())
            col.enabled = false;

        Instantiate(LoveSplatter, hit.transform.position, Quaternion.identity);
        Debug.Log($"HIT PERSON: {hit.collider.name} | HairType={person.Attributes.HairStyle} | Height={person.Attributes.Height}");
     
    }
}
