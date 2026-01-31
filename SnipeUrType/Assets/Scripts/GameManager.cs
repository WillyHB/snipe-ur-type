using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public BodyTypes BodyTypes;
    public BodyTypes SpecialBodyTypes;
    public HairStyles HairStyles;
    public EyeTypes EyeTypes;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;
    }
}
