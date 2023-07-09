using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    /// <summary>
    /// Called once per frame, this method retrieves the position of the cursor in world space and sets
    /// the position of the game object to match the cursor position. This allows the object to follow the
    /// movement of the mouse cursor on the screen.
    /// </summary>
    public void Update() {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPos.x, cursorPos.y);
    }
}
