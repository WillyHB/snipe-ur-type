using UnityEngine;

public class Attributes
{
    private static Color32[] SkinColors =
    {
        new Color(232,231,178,255), // White
        new Color(110,78,44,255), // Black
        new Color(64,129,217,255), // Blue
        new Color(71,207,48,255), // Green
        new Color(225,235,122,255), // Jaundice
        new Color(243,245,219,255), // Pale
        new Color(232,175,216,255), // Pink
    };

    private static Color32[] HairColors =
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

    private static string[] personalities =
    {
        "Love horse riding",
        "Be a big fan of bowling",
        "Be just like so awesome",
        "Be a biiig fan of gacha games",
        "Have a car??",
        "Be not like weird",
        "Look like they'd maybe know a thing or two about the anatomy of a horse (Important)",
        "Look cool",
        "Be Alive?",
        "Idk?",
        "Have a JOB",
        "Be Funny",
        "Not act the way they look.",
        "DONATE TO CHARITY",
        "Not want me",
        "Not hate me",
        "Be able to walk"
    };

    public HairStyle HairStyle { get; private set; }
    public BodyType BodyType { get; private set; }
    public EyeType EyeType { get; private set; }

    public float Height { get; private set; }
    public float Mass { get; private set; }

    public Color HairColor { get; private set; }
    public Color SkinColor { get; private set; }
    public Color EyeColor { get; private set; }


    public bool Freckles { get; private set; }

    public bool Special { get; private set; }
    public BodyType SpecialBodyType { get; private set; }

    public string Personality { get; private set; }

    private static T GetRandom<T>(T[] array)
        => array[Random.Range(0, array.Length)];

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
            Freckles = Random.Range(0f, 1f) < 0.5,
            Special = Random.Range(0f, 1f) < 0.5,//Random.Range(0, 100) == 1,
            SpecialBodyType = GameManager.instance.SpecialBodyTypes.GetRandom(),
            Height = Random.Range(0.5f, 2f),
            Mass = Random.Range(0.5f, 2f),
            Personality = GetRandom(personalities),
        };
    }
}

