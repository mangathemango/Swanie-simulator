using UnityEngine;

public class CloudSwan : BaseEnemy {
    [SerializeField] private float _floatRange = 1f;
    private Rigidbody2D _rb;
    private float _centerY;
    private float startTime;
    protected override void Start() 
    {
        base.Start();
        _rb = GetComponent<Rigidbody2D>();
        if (!_rb) {
            _rb = gameObject.AddComponent<Rigidbody2D>();
        }
        transform.position = new Vector2(transform.position.x, Random.Range(2,4));
        _centerY = transform.position.y;
        startTime = Time.time;
        startTime += Random.Range(0, 2 * Mathf.PI);
    }
    protected override void Update() 
    {
        base.Update();
        float newY = _centerY + Mathf.Sin(Time.time - startTime) * _floatRange;
        transform.position = new Vector2(transform.position.x, newY);
    }
}