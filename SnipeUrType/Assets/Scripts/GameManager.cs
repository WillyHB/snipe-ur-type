using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public BodyTypes BodyTypes;
    public HairStyles HairStyles;
    public EyeTypes EyeTypes;

    private void Awake()
    {
        instance = this;
    }
}
