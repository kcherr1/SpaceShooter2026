using UnityEngine;

public class Player : MonoBehaviour {
  // set in inspector
  public float speed = 0.1f;
  public GameObject bulletPrefab;
  public Transform bulletSpawnPoint;

  private SpaceShooterInputActions.StandardActions input;
  


  private const float Y_LIMIT = 4.6f;

  private void Start() {
    var inputActions = new SpaceShooterInputActions();
    inputActions.Enable();
    input = inputActions.Standard;
    input.Enable();
  }

  private void Update() {
    if (input.Fire.WasPressedThisFrame()) {
      GameObject bulletObj = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
    }


        var vertMove = input.MoveVertically.ReadValue<float>();
      this.transform.Translate(Vector3.up * speed * Time.deltaTime * vertMove);

    if (this.transform.position.y > Y_LIMIT) {
      this.transform.position = new Vector3(transform.position.x, Y_LIMIT);
    }
    else if (this.transform.position.y < -Y_LIMIT) {
      this.transform.position = new Vector3(transform.position.x, -Y_LIMIT);
    }
  }
}
