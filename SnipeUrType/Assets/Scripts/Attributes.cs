using System.Linq;
using UnityEngine;
using static Helpers;

public class Attributes
{
    private static readonly Color32[] SkinColors =
    {
        new(245,215,171,255), // White
        new(245,215,171,255), // White
        new(245,215,171,255), // White
        new(245,215,171,255), // White
        new(245,215,171,255), // White
        new(245,215,171,255), // White
        new(110,78,44,255), // Blackk
        new(110,78,44,255), // Blackk
        new(110,78,44,255), // Blackk
        new(110,78,44,255), // Blackk
        new(110,78,44,255), // Blackk
        new(110,78,44,255), // Blackk
        new(110,78,44,255), // Blackk
        new(110,78,44,255), // Blackk
        new(64,129,217,255), // Blue
        new(71,207,48,255), // Green
        new(225,235,122,255), // Jaundice
        new(243,245,219,255), // Pale
        new(243,245,219,255), // Pale
        new(243,245,219,255), // Pale
        new(243,245,219,255), // Pale
        new(232,175,216,255), // Pink
    };

    private static readonly Color32[] HairColors =
    {
        new(206,232,99, 255), // Yellow Blonde
        new(206,232,99, 255), // Yellow Blonde
        new(206,232,99, 255), // Yellow Blonde
        new(176,189,123,255), // Dirty Blonde
        new(176,189,123,255), // Dirty Blonde
        new(176,189,123,255), // Dirty Blonde
        new(176,189,123,255), // Dirty Blonde
        new(241,245,226, 255), // Fair Blonde / White
        new(241,245,226, 255), // Fair Blonde / White
        new(241,245,226, 255), // Fair Blonde / White
        new(79,57,41, 255), // Brunette
        new(79,57,41, 255), // Brunette
        new(79,57,41, 255), // Brunette
        new(79,57,41, 255), // Brunette
        new(26,12,1,255), // Black
        new(26,12,1,255), // Black
        new(26,12,1,255), // Black
        new(26,12,1,255), // Black
        new(212,109,31,255), // Redhead
        new(212,109,31,255), // Redhead
        new(212,109,31,255), // Redhead
        new(156,204,101,255), // Zorb
        new(108,48,232,255), // Blue
        new(232,48,48,255), // Red
    };

    private static string[] personalities =
    {
        "Loves horse riding",
        "Is a big fan of bowling",
        "Is just like so awesome",
        "Is a biiig fan of gacha games",
        "Has a car??",
        "Is not like weird",
        "Looks like they'd maybe know a thing or two about the anatomy of a horse (Important)",
        "Looks cool",
        "Is Alive?",
        "Idk?",
        "Has a JOB",
        "Is Funny",
        "Doesn't act the way they look.",
        "DONATES TO CHARITY",
        "Doesn't want me",
        "Doesn't hate me",
        "Is able to walk"
    };

    public HairStyle HairStyle { get; private set; }
    public BodyType BodyType { get; private set; }
    public TopType TopType { get; private set; }
    public BottomType BottomType { get; private set; }
    public FacialHair FacialHair { get; private set; }
    public ShoeType ShoeType { get; private set; }

    public float Height { get; private set; }
    public float Mass { get; private set; }

    public Color32 HairColor { get; private set; }
    public Color32 SkinColor { get; private set; }

    public bool Special { get; private set; }
    public bool Female { get; private set; } // #Equality
    public BodyType SpecialBodyType { get; private set; }

    public string Personality { get; private set; }

    public static Attributes GetRandomAttr()
    {
        Attributes attr = new Attributes();

        attr.Personality = GetRandom(personalities);
        attr.Special = Random.Range(0, 100) == 5;//true; 

        if (attr.Special)
        {
            attr.SpecialBodyType = GetRandom(DataManager.instance.SpecialBodyTypes.Types);
            return attr;
        }
        attr.Female = Random.Range(0f, 1f) < 0.5;

        if (!attr.Female)
        {
            attr.FacialHair = GetRandom(DataManager.instance.FacialHairs.Styles);
        }

        attr.HairStyle = GetRandom(DataManager.instance.HairStyles.Styles.Where(t => (t.Male && !attr.Female)||(t.Female&&attr.Female)).ToArray());
        attr.ShoeType = GetRandom(DataManager.instance.ShoeTypes.Types.Where(t => (t.Male && !attr.Female)||(t.Female&&attr.Female)).ToArray());
        attr.BodyType = attr.Female ? DataManager.instance.Female : DataManager.instance.Male;
        attr.TopType = GetRandom(DataManager.instance.TopTypes.Types.Where(t => (t.Male && !attr.Female)||(t.Female&&attr.Female)).ToArray());
        attr.BottomType = GetRandom(DataManager.instance.BottomTypes.Types.Where(t => (t.Male && !attr.Female)||(t.Female&&attr.Female)).ToArray());

        attr.HairColor = GetRandom(HairColors);
        attr.SkinColor = GetRandom(SkinColors);


        attr.Height = Random.Range(0.75f, 1.2f);
        attr.Mass = 1;// Random.Range(0.75f, 1.5f);

        return attr;
    }
}

