using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
    //Know what objects are clickable
    public LayerMask clickableLayer;

    //Swap cursos per object
    public Texture2D pointer;   //normal pointer
    public Texture2D target;    //Cursosr for clickable objects like the world
    public Texture2D doorway;   //Cursor for doorways
    public Texture2D combat;    //Cursor combat actions

    public EvenVecttor3 OnClickEvironment;

  

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, clickableLayer.value))
        {
            bool door = false;
            bool item = false;

            if (hit.collider.gameObject.tag == "Doorway")
            {
                Cursor.SetCursor(doorway, new Vector2(16, 16), CursorMode.Auto);
                door = true;
            }
            else if (hit.collider.gameObject.tag== "Item")
            {
                Cursor.SetCursor(combat, new Vector2(15,15), CursorMode.Auto);
                item = true;
            }
            else
            {
                Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                if (door)
                {
                    Transform doorway = hit.collider.gameObject.transform;
                    OnClickEvironment.Invoke(doorway.position);
                    Debug.Log("Door Log");
                }
                else if (item)
                {
                    Transform itemPos = hit.collider.gameObject.transform;
                    OnClickEvironment.Invoke(itemPos.position);
                    Debug.Log("Item Log");
                }
                else
                {
                    OnClickEvironment.Invoke(hit.point);
                }
                
            }
        }
        else
        {
            Cursor.SetCursor(pointer, Vector2.zero, CursorMode.Auto);
        }
    }
}
[System.Serializable]
public class EvenVecttor3 : UnityEvent<Vector3> { }