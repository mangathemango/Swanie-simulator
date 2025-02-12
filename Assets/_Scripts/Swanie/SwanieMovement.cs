using UnityEngine;

class SwanieMovement : MonoBehaviour
{   
    public Animator bodyAnimator;
    public Animator legAnimator;
    Rigidbody2D rb;
    public float jumpForce = 10;
    private bool jumping = false;
    private bool running = true;
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {   
        running = true;
        jumping = false;
        setAnimation();
        
    }
    
    private void Start()
    {
        jumping = false;
        running = true;
        setAnimation();
    }

    public void Jump() {
        Debug.Log("Jumping");
        jumping = true;
        setAnimation();
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void setAnimation() {
        if (jumping) {
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
}