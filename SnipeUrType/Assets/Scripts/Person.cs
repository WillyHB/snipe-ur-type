using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private GameManager _gameManager;

    [SerializeField] private Animator _bodyAnim;
    [SerializeField] private Animator _topAnim;
    [SerializeField] private Animator _bottomAnim;


    private float walkSpeed = 1.0f;

    public Attributes Attributes { get; private set; }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Attributes = Attributes.GetRandomAttr();

        //if (Attributes.Special)
        //{
        //    GameObject special = Instantiate(Attributes.SpecialBodyType.BodyPrefab, transform);
        //    return;
        //}

        //Body body = Instantiate(Attributes.BodyType.BodyPrefab, transform).GetComponent<Body>();

        //body.Renderer.color = Attributes.SkinColor;

        //body.Hair.sprite = Attributes.HairStyle.Sprite;
        //body.Hair.color = Attributes.HairColor;

        //body.Eyes.sprite = Attributes.EyeType.Sprite;
        //body.Eyes.color = Attributes.EyeColor;

        //body.Freckles.enabled = Attributes.Freckles;

        _bodyAnim.runtimeAnimatorController = Attributes.BodyType._animator;
        _topAnim.runtimeAnimatorController = Attributes.TopType._animator;
        _bottomAnim.runtimeAnimatorController = Attributes.BottomType._animator;

        WalkToward();   // this will make the person start walking immediately upon spawn toward ~ center
    }
    
    // Update is called once per frame
    void Update()
    {
        // need to confirm with saad how to get shot
    }

    public void WalkToward(Vector2? direction = null)
    {
        //_animator.SetBool("isWalking", true);

        if (direction == null)
        {
            _rigidbody2D.linearVelocity = _gameManager.GetWalkDirection(transform.position) * walkSpeed;
        }
        else
        {
            _rigidbody2D.linearVelocity = direction.Value * walkSpeed;
        }
    }

    public void StopWalking()
    {
        //_animator.SetBool("isWalking", false);

        _rigidbody2D.linearVelocity = Vector2.zero;
    }

    private void OnBecameInvisible()    // Destroy person when they leave the screen    
    {
        Destroy(gameObject);
    }
}
