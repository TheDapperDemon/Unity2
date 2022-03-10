using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MouseManager : MonoBehaviour
{
    // Need to know what objects are clickable 
    public LayerMask ClickablePlayer;

    // Swap Cursors per Objects
    public Texture2D pointer; //Normal Pointer
    public Texture2D target; // Cursor for clickable objects
    public Texture2D doorway; // Cursor for doorways
    public Texture2D combat; // Cursor for Combat actions

    public EventVector3 OnClickEnvironment;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, ClickablePlayer.value))
        {
            bool door = false;
            if(hit.collider.gameObject.tag == "Doorway")
            {
                Cursor.SetCursor(doorway, new Vector2(16, 16), CursorMode.Auto);
                door = true;
            }
            else
            {
                Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
            }
            if(Input.GetMouseButtonDown(0))
            {
                OnClickEnvironment.Invoke(hit.point);
            }
        }

        else
        {
            Cursor.SetCursor(pointer, Vector2.zero, CursorMode.Auto);
        }
    }
}
[System.Serializable]
public class EventVector3 : UnityEvent<Vector3> { }