using UnityEngine;

public class Person : MonoBehaviour
{
    public Attributes Attributes;
    
    void Awake()
    {
        Attributes ??= Attributes.GetRandomAttr();
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
