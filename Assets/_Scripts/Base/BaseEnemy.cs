using UnityEngine;

public class BaseEnemy: MonoBehaviour {
    [SerializeField] private float speed = 2f;
    public Transform swanieTransform;
    private bool scoreAdded = false;
    protected virtual void Start() {
        if (!swanieTransform) {
            swanieTransform = GameObject.Find("Swanie").transform;
        }
    }
    protected virtual void Update() {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < -15) {
            Destroy(gameObject);
        }
        if (transform.position.x < swanieTransform.position.x && !scoreAdded) {
            GameManager.Instance.score += 1;
            scoreAdded = true;
        }
    }
}