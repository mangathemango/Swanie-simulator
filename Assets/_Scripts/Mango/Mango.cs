using Unity.VisualScripting;
using UnityEngine;

public class Mango: BaseEnemy {
    private SwanieMovement swanie;
    protected override void Start() {
        base.Start();
        if (!GetComponent<Rigidbody2D>()) {
            gameObject.AddComponent<Rigidbody2D>();
            return;
        }
        swanie = GameObject.Find("Swanie").GetComponent<SwanieMovement>();
    }

    protected override void Update()
    {
        base.Update();
        if (transform.position.x < (swanieTransform.position.x - 3)) {
            swanie.hasMango = true;
            swanie.setAnimation();
            GameManager.Instance.score += 10;
            Destroy(gameObject);
        }
    }
}