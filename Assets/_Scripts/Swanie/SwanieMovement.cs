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
    private bool _running = true;
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

    public void setAnimation() {
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
        if (hasMango) {
            bodyAnimator.SetBool("HasMango", true);
        } else {
            bodyAnimator.SetBool("HasMango", false);
        }
    }

    private void resetJump() {
        _currentJumpCount = maxJumpCount;
        _jumping = false;
        setAnimation();
    }

    public void Shoot() {
        if (!shootReady) {
            return;
        }
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