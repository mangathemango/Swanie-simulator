using System.Collections;
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
    private bool _running = false;
    private int _currentJumpCount = 0;
    public bool hasMango = false;
    public Transform shootPoint;
    public GameObject bulletPrefab;
    public bool shootReady = true;
    
    private void Start()
    {
        setAnimation();
        resetJump();
        _originalX = transform.position.x;
        _rb = GetComponent<Rigidbody2D>();

        if (shootPoint == null) {
            shootPoint = GameObject.Find("Shoot Point").transform;
        }
    }

    void Update()
    {           
        if (transform.position.x < _originalX) {
            Die();
        }
        UiManager.Instance.UpdateMangoStatus(hasMango, shootReady);
    }

    public void StartRunning() {
        resetJump();
        _running = true;
        setAnimation();
    }
    void Die() {
        GameManager.Instance.EndGame();
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {   
        if (!GameManager.Instance.gameStarted) {
            return;
        }
        resetJump();
        _running = true;
        _jumping = false;
        setAnimation();
    }

    public void Jump() {
        if (!GameManager.Instance.gameStarted) {
            return;
        }
        if (_currentJumpCount <= 0) {
            return;
        }
        _currentJumpCount -= 1;
        _jumping = true;
        _running = false;
        setAnimation();
        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, 0);
        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        AudioManager.Instance.PlayJumpSound();
    }

    public void setAnimation() {
        bodyAnimator.SetBool("Jumping", _jumping);
        legAnimator.SetBool("Jumping", _jumping);
        bodyAnimator.SetBool("Running", _running);
        legAnimator.SetBool("Running", _running);
        bodyAnimator.SetBool("HasMango", hasMango);
    }

    private void resetJump() {
        if (!GameManager.Instance.gameStarted) {
            return;
        }
        _currentJumpCount = maxJumpCount;
        _jumping = false;
        _running = true;
        setAnimation();
    }

    public void Shoot() {
        if (!shootReady) {
            return;
        }
        AudioManager.Instance.PlayShootSound();
        shootReady = false;
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 10, ForceMode2D.Impulse);
        StartCoroutine(resetShoot());
    }

    private IEnumerator resetShoot() {
        yield return new WaitForSeconds(3);
        shootReady = true;
        setAnimation();
    }
}