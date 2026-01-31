using UnityEngine;

public class Person : MonoBehaviour
{
    public Attributes Attributes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Attributes = Attributes.GetRandomAttr();

        Body body = Instantiate(Attributes.BodyType.BodyPrefab, transform).GetComponent<Body>();

        body.Renderer.color = Attributes.SkinColor;

        body.Hair.sprite = Attributes.HairStyle.Sprite;
        body.Hair.color = Attributes.HairColor;

        body.Eyes.sprite = Attributes.EyeType.Sprite;
        body.Eyes.color = Attributes.EyeColor;

        body.Freckles.enabled = Attributes.Freckles;
    }
}
