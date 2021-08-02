using System.Collections;
using UnityEngine;

public class Door1 : MonoBehaviour
{
    public GameObject keyDestroy;
    public Animation openDoor;
    public AnimationClip closeDoor;
    public GameObject uiDoor;
    public static bool doorKey;
    public bool open;
    public bool close;
    public bool inTrigger;

    void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
        Debug.Log("Masuk");
    }

    void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

    void Update()
    {
        if (inTrigger)
        {
            if (close)
            {
                if (doorKey)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        openDoor.Play();
                        open = true;
                        close = false;
                        keyDestroy.SetActive(false);
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    close = true;
                    open = false;
                }
            }
        }

    }

    void OnGUI()
    {
        if (inTrigger)
        {
            if (open)
            {
                //GUI.Box(new Rect(0, 0, 200, 25), "Press E to close");
                
            }
            else
            {
                if (doorKey)
                {
                    GUI.Box(new Rect(0, 0, 200, 25), "Press E to open");
                }
                else
                {
                    GUI.Box(new Rect(0, 0, 200, 25), "Need a key!");
                }
            }
        }
    }
}
