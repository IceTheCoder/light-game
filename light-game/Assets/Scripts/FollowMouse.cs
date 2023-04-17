using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    /// <summary>
    /// Called once per frame, this method gets the position of the cursor, and sets the object's (the light's)
    /// position to that of the cursor.
    /// </summary>
    public void Update() {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPos.x, cursorPos.y);
    }
}
