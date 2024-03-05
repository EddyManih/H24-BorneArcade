using UnityEngine;

public class StayWithinCameraBounds : MonoBehaviour {
  private Camera mainCamera;
  private Vector2 screenBounds;
  private float objectWidth;
  private float objectHeight;

  void Start() {
    mainCamera = Camera.main;
    screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(
        Screen.width, Screen.height, mainCamera.transform.position.z));
    objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
    objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
  }

  void LateUpdate() {
    Vector3 viewPos = transform.position;
    viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth,
                            screenBounds.x - objectWidth);
    viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight,
                            screenBounds.y - objectHeight);
    transform.position = viewPos;
  }
}
