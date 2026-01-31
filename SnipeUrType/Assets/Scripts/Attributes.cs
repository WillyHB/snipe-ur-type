using UnityEngine;

public class Attributes
{
    public static Color32[] SkinColors =
    {
        new Color(232,231,178,255), // White
        new Color(110,78,44,255), // Black
        new Color(64,129,217,255), // Blue
        new Color(71,207,48,255), // Green
        new Color(225,235,122,255), // Jaundice
        new Color(243,245,219,255), // Pale
        new Color(232,175,216,255), // Pink
    };

    public static Color32[] HairColors =
    {
        new(206,232,99, 255), // Yellow Blonde
        new(176,189,123,255), // Dirty Blonde
        new(241,245,226, 255), // Fair Blonde / White
        new(79,57,41, 255), // Brunette
        new(26,12,1,255), // Black
        new(212,109,31,255), // Redhead
        new(48,232,79, 255), // Green
        new(108,48,232,255), // Blue
        new(232,48,48,255), // Red
    };

    public HairStyle HairStyle { get; private set; }
    public BodyType BodyType { get; private set; }
    public EyeType EyeType { get; private set; }

    public Color HairColor { get; private set; }
    public Color SkinColor { get; private set; }
    public Color EyeColor { get; private set; }


    public bool Freckles { get; private set; }


    private static T GetRandomEnum<T>()
    {
        System.Array enums = System.Enum.GetValues(typeof(T));
        return (T)enums.GetValue(Random.Range(0, enums.Length - 1));
    }

    public static Attributes GetRandomAttr()
    {
        return new()
        {
            HairStyle = GameManager.instance.HairStyles.GetRandom(),
            BodyType = GameManager.instance.BodyTypes.GetRandom(),
            EyeType = GameManager.instance.EyeTypes.GetRandom(),

            HairColor = HairColors[Random.Range(0, HairColors.Length - 1)],
            SkinColor = SkinColors[Random.Range(0, SkinColors.Length - 1)],

            EyeColor = Random.ColorHSV(),
            Freckles = Random.Range(0f, 1f) < 0.5
        };
    }

}

