using UnityEngine;

public class Applicant
{
    private static string[] firstNames =
    {
        "Bob",
        "John",
        "Thomas",
        "Dylan",
        "Zhi",
        "Ben",
        "Davis",
        "David",
        "George",
        "Jared",
        "Jacob",
        "Felix",
        "Elias",
        "Hugo",
        "Tobias",
        "Orion",
        "Enzo",
        "Aleksandra",
        "Alexandra",
        "Sarah",
        "Hannah",
        "Olivia",
        "Emma",
        "Ava",
        "Eva",
        "Charlotte",
        "Abigail",
        "Addison",
        "Daisy",
        "Camila"
    };

    private static string[] lastNames =
    {
        "Smith",
        "Bush",
        "Martin",
        "Nguyen",
        "Johnson",
        "Brown",
        "Garcia",
        "Miller",
        "Taylor",
        "Baker",
        "Woods",
        "Baird",
        "McGill",
        "Horsey",
        "Adams",
        "Anderson",
        "Clark",
        "Jones",
        "Lewis",
        "Brook",
        "King"
    };

    private static string[] streetNames =
    {
        "Forest Row",
        "Monument Avenue",
        "Ocean Lane",
        "Royalty Way",
        "Mason Avenue",
        "Dew Street",
        "Shade Lane",
        "Rue Durocher",
        "University Street",
        "Pine Street",
        "Blossom Boulevard",
        "Summit Lane",
        "Broadway",
        "Grime Route",
        "The Horse Street",
        "River Lane"
    };

    private static string[] cities =
    {
        "Montreal",
        "New York City",
        "San Diego",
        "Los Angeles",
        "Brussels",
        "Tokyo",
        "Sydney",
        "Lagos",
        "Quebec City",
        "Labrador",
        "Ottawa",
        "Toronto",
        "Vancouver",
        "Calgary",
    };

    public Attributes IdealAttributes { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string City { get; private set; }
    public string Street { get; private set; }
    public int StreetNumber { get; private set; }
    
    public Sprite Signature { get; private set; }

    public string DesiredPhysical { get; private set; }

    private static T GetRandom<T>(T[] array)
        => array[Random.Range(0, array.Length)];
    

    public static Applicant GetNewApplicant()
    {
        Attributes attr = Attributes.GetRandomAttr();
        return new()
        {
            IdealAttributes = attr,
            FirstName = GetRandom(firstNames),
            LastName = GetRandom(lastNames),
            City = GetRandom(cities),
            Street = GetRandom(streetNames),
            StreetNumber = Random.Range(1,1000),
            Signature = GameManager.instance.Signatures[Random.Range(0, GameManager.instance.Signatures.Length)],
        };
    }
}
