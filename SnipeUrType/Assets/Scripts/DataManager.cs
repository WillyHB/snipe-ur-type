using UnityEngine;
using TMPro;

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

    public TMP_FontAsset[] HandwrittenFonts;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }
}
