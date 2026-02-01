using UnityEngine;

public class RandomBg : MonoBehaviour
{
    public Sprite[] Backgrounds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Helpers.GetRandom(Backgrounds);
    }
}
