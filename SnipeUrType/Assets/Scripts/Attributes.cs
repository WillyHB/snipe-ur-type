using UnityEngine;

public enum HairType
{
    Wavy,
    Curly,
    Flat,
}

public enum HairLength
{
    Short,
    Medium,
    Long
}
public enum Age
{
    Lively,
    Eldery,
}
public enum BodyType
{
    Thin,
    Normal,
    Muscular,
    Big
}

public enum Height
{
    ShortKing,
    Average,
    Monster,
}

public class Attributes
{
    public static Color[] SkinColors =
    {
        new Color(232,231,178), // White
        new Color(110,78,44), // Black
        new Color(64,129,217), // Blue
        new Color(71,207,48), // Green
        new Color(225,235,122), // Jaundice
        new Color(243,245,219), // Pale
        new Color(232,175,216), // Pink
    };

    public static Color[] HairColors =
    {
        new Color(206,232,99), // Yellow Blonde
        new Color(176,189,123), // Dirty Blonde
        new Color(241,245,226), // Fair Blonde / White
        new Color(79,57,41), // Brunette
        new Color(26,12,1), // Black
        new Color(212,109,31), // Redhead
        new Color(48,232,79), // Green
        new Color(108,48,232), // Blue
        new Color(232,48,48), // Red
    };


    public HairType HairType { get; private set; }
    public HairLength HairLength { get; private set; } 
    public BodyType BodyType { get; private set; }
    public Height Height { get; private set; } 
    public Age Age { get; private set; }

    public Color HairColor { get; private set; }
    public Color SkinColor { get; private set; }
    public Color EyeColor { get; private set; }


    public bool Freckles { get; private set; }


    private static T GetRandomEnum<T>()
    {
        System.Array enums = System.Enum.GetValues(typeof(T));
        return (T)enums.GetValue(UnityEngine.Random.Range(0, enums.Length - 1));
    }
    public static Attributes GetRandomAttr()
    {
        return new()
        {
            HairType = GetRandomEnum<HairType>(),
            BodyType = GetRandomEnum<BodyType>(),
            Age = GetRandomEnum<Age>(),
            Height = GetRandomEnum<Height>(),
            HairLength = GetRandomEnum<HairLength>(),

            HairColor = HairColors[Random.Range(0, HairColors.Length - 1)],
            SkinColor = SkinColors[Random.Range(0, SkinColors.Length -1)],

            EyeColor = Random.ColorHSV(),
            Freckles = Random.Range(0f, 1f) < 0.5

        };
    }

}
