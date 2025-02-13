using UnityEngine;

class SwanieMovement : MonoBehaviour
{   
    public Animator bodyAnimator;
    public Animator legAnimator;
    public float jumpForce = 10;
    public int maxJumpCount = 2;
    private float _originalX;

    private Rigidbody2D _rb;
    private bool _jumping = false;
    private bool _running = true;
    private int _currentJumpCount = 0;

    
    private void Start()
    {
        setAnimation();
        resetJump();
        _originalX = transform.position.x;
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.x < _originalX) {
            Die();
        }
    }

    void Die() {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {   
        resetJump();
        _running = true;
        _jumping = false;
        setAnimation();
    }

    public void Jump() {
        if (_currentJumpCount <= 0) {
            return;
        }
        _currentJumpCount -= 1;
        _jumping = true;
        setAnimation();
        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, 0);
        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void setAnimation() {
        if (_jumping) {
            bodyAnimator.SetBool("Jumping", true);
            legAnimator.SetBool("Jumping", true);
            bodyAnimator.SetBool("Running", false);
            legAnimator.SetBool("Running", false);
        } else {
            bodyAnimator.SetBool("Jumping", false);
            legAnimator.SetBool("Jumping", false);
            bodyAnimator.SetBool("Running", true);
            legAnimator.SetBool("Running", true);
        }
    }

    private void resetJump() {
        _currentJumpCount = maxJumpCount;
        _jumping = false;
        setAnimation();
    }
}