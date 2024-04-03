using UnityEngine;

public class CameraBounds : MonoBehaviour {
  public Camera mainCamera;
  private Vector2 screenBounds;
  public float colliderDepth = 10f;
  private float colliderThickness = 0.1f;

  void Awake() {
    if (mainCamera == null)
      mainCamera = Camera.main;

    screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(
        Screen.width, Screen.height, mainCamera.transform.position.z));
    AddBoundaryCollider("Top", new Vector2(0, screenBounds.y),
                        new Vector2(screenBounds.x * 2, colliderThickness));
    AddBoundaryCollider("Bottom", new Vector2(0, -screenBounds.y),
                        new Vector2(screenBounds.x * 2, colliderThickness));
    AddBoundaryCollider("Left", new Vector2(-screenBounds.x, 0),
                        new Vector2(colliderThickness, screenBounds.y * 2));
    AddBoundaryCollider("Right", new Vector2(screenBounds.x, 0),
                        new Vector2(colliderThickness, screenBounds.y * 2));
  }

  private void AddBoundaryCollider(string name, Vector2 position,
                                   Vector2 size) {
    GameObject boundary = new GameObject(name + " Boundary");
    boundary.transform.position = position;
    boundary.transform.parent = transform;

    BoxCollider2D collider = boundary.AddComponent<BoxCollider2D>();
    collider.size = size;
    collider.isTrigger = false;

    Rigidbody2D rb = boundary.AddComponent<Rigidbody2D>();
    rb.isKinematic = true;
    rb.useFullKinematicContacts = true;
  }
}
