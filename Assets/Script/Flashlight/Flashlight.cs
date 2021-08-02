using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    //Audio
    AudioSource gameSound;
    AudioClip flashClick;
    public Transform equipPosition;
    GameObject currentItem;
    GameObject wp;
    public GameObject spotLight;
    public bool isOn = false;
    public bool failSafe = false;

    void Start()
    {
        gameSound = GetComponent<AudioSource>();
        flashClick = Resources.Load<AudioClip>("Audio/Flashlight/FlashlightClick");
        spotLight.gameObject.SetActive(false);
        GetComponent<Flashlight>().enabled= false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (wp = transform.gameObject)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (isOn == false && failSafe == false)
                {
                    gameSound.clip = flashClick;
                    gameSound.Play();
                    failSafe = true;
                    spotLight.SetActive(true);
                    isOn = true;
                    StartCoroutine(FailSafe());
                }
                if (isOn == true && failSafe == false)
                {
                    gameSound.clip = flashClick;
                    gameSound.Play();
                    failSafe = true;
                    spotLight.SetActive(false);
                    isOn = false;
                    StartCoroutine(FailSafe());
                }
            }
            if (GetComponent<Rigidbody>().isKinematic == false)
            {
                GetComponent<Flashlight>().enabled= false;
            }
        }

    }

    IEnumerator FailSafe()
    {
        yield return new WaitForSeconds(0.1f);
        failSafe = false;
    }
}
