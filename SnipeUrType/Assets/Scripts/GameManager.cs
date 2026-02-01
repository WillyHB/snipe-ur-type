using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Vector2[] personSpawn;
    private bool roundResolved = false;
    public void SetRoundResolved(bool value) => roundResolved = value;
    [SerializeField] private Vector2 screenCenter;

    private float centerOffset = 2.0f;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }


    public Person SpawnPerson()
    {
        Attributes attr = Attributes.GetRandomAttr();
        Vector2 spawnPos = GetRandomPersonSpawn();
        Person person = Instantiate(attr.Special ? attr.SpecialBodyType.BodyPrefab : (attr.Female ? DataManager.instance.Female.BodyPrefab : DataManager.instance.Male.BodyPrefab), spawnPos, Quaternion.identity).GetComponent<Person>();
        if (spawnPos.x > screenCenter.x && !person.TryGetComponent<Animator>(out Animator a))
            person.transform.rotation = Quaternion.Euler(0, 180, 0);
        person.Initialize(attr);
        return person;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        personSpawn = FindPersonSpawnPoints();
        // blem
        SpawnPerson();
        SpawnPerson();
        SpawnPerson();
        SpawnPerson();
        SpawnPerson();
        SpawnPerson();
        SpawnPerson();
        SpawnPerson();
        // spawn initial number of people
    }


    private float timer = 3;
    // Update is called once per frame
    void Update()
    {
        if (roundResolved) return;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 3;
            SpawnPerson();
        }

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

    public void KeepOnly (Person keep)
    {
        roundResolved = true;
        GameObject[] persons = GameObject.FindGameObjectsWithTag("Person");

        keep.StopWalking();

        for (int i = 0; i < persons.Length; i++)
        {
            if (keep != null && persons[i] == keep.gameObject) continue;
            Destroy(persons[i]);


        }
    }

    public void ClearAllPeople()
    {
        roundResolved = true;
        GameObject[] persons = GameObject.FindGameObjectsWithTag("Person");

        for (int i = 0; i < persons.Length; i++)
        {
            Destroy(persons[i]);
        }
    }
}
