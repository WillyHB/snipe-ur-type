using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Vector2[] personSpawn;
    private bool roundResolved = false;
    public void SetRoundResolved(bool value) => roundResolved = value;
    [SerializeField] private Vector2 screenCenter;

    private float centerOffset = 2.0f;

    public List<GameObject> _personContainer;
    
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        _personContainer = new List<GameObject>();
    }


    public Person SpawnPerson()
    {
        Attributes attr = Attributes.GetRandomAttr();
        Vector2 spawnPos = GetRandomPersonSpawn();
        Person person = Instantiate(attr.Special ? attr.SpecialBodyType.BodyPrefab : (attr.Female ? DataManager.instance.Female.BodyPrefab : DataManager.instance.Male.BodyPrefab), spawnPos, Quaternion.identity).GetComponent<Person>();
        if (spawnPos.x > screenCenter.x && !person.TryGetComponent<Animator>(out Animator a))
            person.transform.rotation = Quaternion.Euler(0, 180, 0);
        person.Initialize(attr);
        _personContainer.Add(person.gameObject);
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
        if (_personContainer == null) return;

        for (int i = _personContainer.Count - 1; i>=0; i--)
        {
            GameObject go = _personContainer[i];
            if (go == null)
            {
                _personContainer.RemoveAt(i);
                continue;
            }
            if (keep != null && go == keep.gameObject)
            {    
                keep.StopWalking();
                continue;
            }    
            Destroy(go); 
            _personContainer.RemoveAt(i);
        }
    }

    public void ClearAllPeople()
    {
        roundResolved = true;
        if (_personContainer == null) return;

        for (int i = _personContainer.Count - 1; i >= 0; i --)
        {
            GameObject go = _personContainer[i];
            if (go != null) Destroy(go);
        }
        _personContainer.Clear();
    }
}
