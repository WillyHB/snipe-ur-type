using UnityEngine;

public class stebe : MonoBehaviour
{

    private float lastTime;
    private float interval = 0.25f;
    private float tiltAngle = 25f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastTime = Time.time;
        transform.rotation = Quaternion.Euler(0f, 0f, tiltAngle);
        tiltAngle = -tiltAngle;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastTime > interval)
        {
            lastTime = Time.time;
            transform.rotation = Quaternion.Euler(0f, 0f, tiltAngle);
            tiltAngle = -tiltAngle;

        }
    }
}
