using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public bool isOn = false;
    public bool failSafe = false;

    public GameObject spotLight;
    public Flashlight scriptFlashlight;
    public Transform equipPosition;
    public Transform equipKeyPosition;
    private float distance = 1.3f;
    GameObject currentItem;
    GameObject wp;
    GameObject currentKey;
    GameObject wk;

    bool canGrab;
    bool canGrabKey;

    private float LayerKey;

    void Start()
    {
        LayerKey = LayerMask.NameToLayer("Keys");
    }
    private void Update()
    {
        CheckItems();

        if (canGrab)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (currentItem != null)
                {
                    Drop();
                }

                Pickup();

            }
        }
        if (canGrabKey)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (currentKey != null)
                {
                    //DropKey();
                }

                PickupKey();
            }
        }

        if (currentItem != null)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Drop();
                spotLight.gameObject.SetActive(false);
            }

            scriptFlashlight.enabled = true;
        }

    }
    IEnumerator FailSafe()
    {
        yield return new WaitForSeconds(0.1f);
        failSafe = false;
    }

    private void CheckItems()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "FlashLight")
            {
                //Debug.Log("Bisa di ambil");
                canGrab = true;
                wp = hit.transform.gameObject;
            }
            else
            {
                canGrab = false;
            }
            
            if (hit.transform.gameObject.layer == LayerKey)
            {
                //Debug.Log("Kunci di ambil");
                canGrabKey = true;
                wk = hit.transform.gameObject;
            }
            else
            {
                canGrabKey = false;
            }
        }
    }

    private void Pickup()
    {
        currentItem = wp;
        currentItem.transform.position = equipPosition.position;
        currentItem.transform.parent = equipPosition;
        currentItem.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        currentItem.GetComponent<Rigidbody>().isKinematic = true;
    }
    private void PickupKey()
    {
        currentKey = wk;
        currentKey.transform.position = equipKeyPosition.position;
        currentKey.transform.parent = equipKeyPosition;
        currentKey.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        //currentKey.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void Drop()
    {
        currentItem.transform.parent = null;
        currentItem.GetComponent<Rigidbody>().isKinematic = false;
        currentItem = null;
    }

    private void DropKey()
    {
        currentKey.transform.parent = null;
        currentKey = null;
    }
}
