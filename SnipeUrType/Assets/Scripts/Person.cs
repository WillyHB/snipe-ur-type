using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameManager _gameManager;

    [SerializeField] private SpriteRenderer _bodyRenderer;
    [SerializeField] private SpriteRenderer _hairRenderer;
    // basically every part should have its own renderer so I can just animate
    // body in animator and snap other part's animation to the body's manually in Update()

    private float walkSpeed = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // pick outfit and body size prefab here
    }

    // Update is called once per frame
    void Update()
    {
        // update sprites based on body's current animation frame
    }

    public void WalkToward(Vector2? direction = null)
    {
        _animator.SetBool("isWalking", true);

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
        _animator.SetBool("isWalking", false);

        _rigidbody2D.linearVelocity = Vector2.zero;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
