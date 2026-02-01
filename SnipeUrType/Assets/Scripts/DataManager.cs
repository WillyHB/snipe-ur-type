using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public BodyType Male, Female;
    public BodyTypes SpecialBodyTypes;
    public HairStyles HairStyles;
    public TopTypes TopTypes;
    public BottomTypes BottomTypes;
    public FacialHairs FacialHairs;
    public ShoeTypes ShoeTypes;

    public Sprite[] Signatures;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
