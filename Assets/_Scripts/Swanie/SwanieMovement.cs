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

        jumping = false;
        bodyAnimator.SetBool("Jumping", false);
        legAnimator.SetBool("Jumping", false);
        bodyAnimator.SetBool("Running", true);
        legAnimator.SetBool("Running", true);
        
    }
    
    private void Start()
    {
        running = true;
        bodyAnimator.SetBool("Running", true);
        legAnimator.SetBool("Running", true);   
        bodyAnimator.SetBool("Jumping", false);
        legAnimator.SetBool( "Jumping", false); 
    }

    public void Jump() {
        Debug.Log("Jumping");
        jumping = true;
        bodyAnimator.SetBool("Jumping", true);
        legAnimator.SetBool("Jumping", true);
        bodyAnimator.SetBool("Running", false);
        legAnimator.SetBool("Running", false);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}