using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Vector2[] personSpawn;
    [SerializeField] private Vector2 screenCenter;

    private float centerOffset = 2.0f;

    private List<GameObject> _personContainer;
    
    public static GameManager instance;

    public BodyType Male, Female;
    public BodyTypes SpecialBodyTypes;
    public HairStyles HairStyles;
    public EyeTypes EyeTypes;
    public TopTypes TopTypes;
    public BottomTypes BottomTypes;
    public FacialHairs FacialHairs;
    public ShoeTypes ShoeTypes;

    public Sprite[] Signatures;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;
        _personContainer = new List<GameObject>();
    }


    public Person SpawnPerson()
    {
        Attributes attr = Attributes.GetRandomAttr();
        Person person = Instantiate(attr.Special ? attr.SpecialBodyType.BodyPrefab : (attr.Female ? Female.BodyPrefab : Male.BodyPrefab), GetRandomPersonSpawn(), Quaternion.identity).GetComponent<Person>();
        person.Initialize(attr);
        _personContainer.Add(person.gameObject);
        return person;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        personSpawn = FindPersonSpawnPoints();
        SpawnPerson();
        SpawnPerson();
        // spawn initial number of people
    }

    // Update is called once per frame
    void Update()
    {
        // spawn people periodically
    }

    public Vector3 GetRandomPersonSpawn()
    {
        int index = Random.Range(0, personSpawn.Length);
        Vector2 spawnPoint = personSpawn[index];
        return new Vector3(spawnPoint.x + screenCenter.x, spawnPoint.y + screenCenter.y, 0);
    }

    public Vector2 GetWalkDirection(Vector3 personPosition)
    { 
        Vector2 target = new Vector2(screenCenter.x + Random.Range(-centerOffset, centerOffset), screenCenter.y + Random.Range(-centerOffset, centerOffset));
        return (target - new Vector2(personPosition.x, personPosition.y)).normalized;
    }
        
    public Vector2[] FindPersonSpawnPoints()
    {
        Camera cam = Camera.main;

        float halfHeightY = cam.orthographicSize;
        float halfWidthX = cam.orthographicSize * cam.aspect;

        float ratio = 1.2f;

        Vector2[] spawnPoints = new Vector2[]
        {
            new Vector2(-halfWidthX*ratio, -halfHeightY/ratio), // Left
            new Vector2(-halfWidthX*ratio, 0), // Left
            new Vector2(-halfWidthX*ratio, halfHeightY/ratio), // Left

            
            new Vector2(halfWidthX*ratio, -halfHeightY/ratio),  // Right
            new Vector2(halfWidthX*ratio, 0),  // Right
            new Vector2(halfWidthX*ratio, halfHeightY/ratio),  // Right
        };

        return spawnPoints;
    }
}
