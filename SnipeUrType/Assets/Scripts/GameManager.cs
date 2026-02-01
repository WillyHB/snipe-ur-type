using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Vector2[] personSpawn;
    [SerializeField] private Vector2 screenCenter;

    [SerializeField] private GameObject personPrefab;

    private float centerOffset = 2.0f;

    private List<GameObject> _personContainer;
    
    public static GameManager instance;

    public BodyTypes BodyTypes;
    public BodyTypes SpecialBodyTypes;
    public HairStyles HairStyles;
    public EyeTypes EyeTypes;
    public TopTypes TopTypes;
    public BottomTypes BottomTypes;
    public FacialHairs FacialHairs;

    public Sprite[] Signatures;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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

    public void SpawnPerson()
    {
        GameObject person = Instantiate(personPrefab, GetRandomPersonSpawn(), Quaternion.identity);
        _personContainer.Add(person);
    }
        
}
