using UnityEngine;
using UnityEngine.Rendering;

public class Person : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private GameManager _gameManager;

    [SerializeField] private Animator _bodyAnim;
    [SerializeField] private Animator _topAnim;
    [SerializeField] private Animator _bottomAnim;
    [SerializeField] private Animator _shoeAnim;
    [SerializeField] private SpriteRenderer _bodyRenderer;
    [SerializeField] private SpriteRenderer _hairRenderer;
    [SerializeField] private SpriteRenderer _beardRenderer;

    [SerializeField] private SortingGroup _sortingGroup;

    private float walkSpeed;

    public Attributes Attributes { get; private set; }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Initialize(Attributes attr)
    {
        walkSpeed = attr.Special ? Random.Range(1.6f, 3.5f) : Random.Range(1f, 2.5f); 
        
        Attributes = attr;

        _gameManager = GameManager.instance;

        if (TryGetComponent<stebe>(out stebe s)) return;
        _bodyAnim.runtimeAnimatorController = attr.Special ? Attributes.SpecialBodyType._animator : Attributes.BodyType._animator;
          
        if (attr.Special) return;
        _topAnim.runtimeAnimatorController = Attributes.TopType._animator;
        _bottomAnim.runtimeAnimatorController = Attributes.BottomType._animator;
        _shoeAnim.runtimeAnimatorController = Attributes.ShoeType._animator;


        _bodyRenderer.color = Attributes.SkinColor;
        _hairRenderer.sprite = Attributes.HairStyle.Sprite;
        _hairRenderer.color = Attributes.HairColor;

        if (!Attributes.Female)
        {
            _beardRenderer.sprite = Attributes.FacialHair.Sprite;
            _beardRenderer.color = Attributes.HairColor;
        }

        transform.localScale = new Vector3(Attributes.Mass, Attributes.Height, 1);

    }

    private void Start()
    {
        WalkToward();   // this will make the person start walking immediately upon spawn toward ~ center
    }

    // Update is called once per frame
    void Update()
    {
        // need to confirm with saad how to get shot
        _sortingGroup.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);
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
        Debug.Log("WHYY GOD DEAR GOD WHY");
        Destroy(gameObject);
    }
}
