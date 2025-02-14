using UnityEngine;

class SwanieInputHandler: MonoBehaviour {
    SwanieMovement swanieMovement;
    private void Start() {
        swanieMovement = GetComponent<SwanieMovement>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            swanieMovement.Jump();
        }
        if (swanieMovement.hasMango) {
            if (Input.GetKeyDown(KeyCode.Z)) {
                swanieMovement.Shoot();
            }
        }
    }
}