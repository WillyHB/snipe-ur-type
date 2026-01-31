using UnityEngine;

[CreateAssetMenu(fileName = "HairStyles", menuName = "Attribute Collectors/HairStyles")]
public class HairStyles : ScriptableObject
{
    public HairStyle[] Styles;
    public HairStyle GetRandom() => Styles[Random.Range(0, Styles.Length)];
}
