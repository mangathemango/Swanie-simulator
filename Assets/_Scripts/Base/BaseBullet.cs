using UnityEngine;

public class BaseBullet: MonoBehaviour {
    public float speed = 10;
    public float lifeTime = 2;

    private void Start() {
        Invoke("DestroyBullet", lifeTime);
    }

    private void Update() {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<BaseEnemy>()) {
            GameManager.Instance.score += 10;
            Destroy(collision.gameObject);
            DestroyBullet();
        }
    }

    private void DestroyBullet() {
        Destroy(gameObject);
    }
}