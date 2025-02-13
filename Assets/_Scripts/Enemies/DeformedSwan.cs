using UnityEngine;

public class DeforemdSwan : BaseEnemy {
    public float jumpForce = 10f;
    public float jumpDistance = 2f;
    private Rigidbody2D _rb;
    private bool _jumped = false;
    protected override void Start() 
    {
        base.Start();
        if (!swanieTransform) {
            swanieTransform = GameObject.Find("Swanie").transform;
        }
        _rb = GetComponent<Rigidbody2D>();
        if (!_rb) {
            _rb = gameObject.AddComponent<Rigidbody2D>();
        }
    }
    protected override void Update() 
    {
        base.Update();
        if (transform.position.x < swanieTransform.position.x + jumpDistance) {
            Jump();
        }   
    }

    void Jump() {
        if (_jumped) {
            return;
        }
        _jumped = true;
        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, 0);
        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}