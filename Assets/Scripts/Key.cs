using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Key : MonoBehaviour
{

    private List<string> bag = new List<string>();
    public Image IconKey1;
    public Image IconKey2;
    public Image IconHammer;
    public Image IconScrewdriver;
    public Image IconCheckMarkK1;
    public Image IconCheckMarkK2;
    public AudioClip SoundOpenDoor;
    public AudioClip GetKeys;



    private bool FirstDoorClosed = true;
    private bool SecondDoorClosed = true;
    private bool VentClosed = true;
    private bool WoodClosed = true;
    private bool GoBackToMenu = false;
    public Text msjPrincipal;
    private AudioSource SoundDoor;
    private AudioSource SoundKeys;
    private Collider objetoReciente = null;

    void Start()
    {
        Cursor.visible = false;
    }
    private void Update()
    {

        SoundDoor = GetComponent<AudioSource>();
        SoundKeys = GetComponent<AudioSource>();

        if (Input.GetKeyDown(KeyCode.Escape) && GoBackToMenu == true)
        {
            SceneManager.LoadScene("MainMenu");
            Time.timeScale = 1;
            Cursor.visible = true;
            GoBackToMenu = true;

        }

    }



    private void OnTriggerEnter(Collider objetoColisionado)
    {
        //Debug.Log ("choque contra un objeto");

        if (objetoColisionado.tag == "Key_1")
        {
            Debug.Log("I got the first key");
            bag.Add("Key_1");
            IconKey1.enabled = true;
            SoundKeys.PlayOneShot(GetKeys, 2.0f);
            Destroy(objetoColisionado.gameObject);
        }

        if (objetoColisionado.tag == "Door_1" && FirstDoorClosed == true)
        {
            Debug.Log("You're in the first door");
            if (bag.Contains("Key_1"))
            {
                objetoColisionado.gameObject.transform.Rotate(0, -140, 0);
                FirstDoorClosed = false;
                SoundDoor.PlayOneShot(SoundOpenDoor, 2.0f);
                IconKey1.enabled = false;
                IconCheckMarkK1.enabled = true;
            }
            else
            {
                //You dont have the first key
                msjPrincipal.text = "Objects needed: 1 key (Grey)";
                msjPrincipal.enabled = true;
                objetoReciente = objetoColisionado;
            }
        }

        if (objetoColisionado.tag == "Key_2")
        {
            Debug.Log("I got the second key");

            bag.Add("Key_2");
            IconKey2.enabled = true;
            SoundKeys.PlayOneShot(GetKeys, 2.0f);

            Destroy(objetoColisionado.gameObject);
        }

        if (objetoColisionado.tag == "Door_2" && SecondDoorClosed == true)
        {
            Debug.Log("You're in the second door");
            if (bag.Contains("Key_2"))
            {
                objetoColisionado.gameObject.transform.Rotate(0, 140, 0);
                SecondDoorClosed = false;
                SoundDoor.PlayOneShot(SoundOpenDoor, 2.0f);
                IconKey2.enabled = false;
                IconCheckMarkK2.enabled = true;
            }
            else
            {
                //You dont have the second key
                msjPrincipal.text = "Objects needed: 1 Key (Gold)";
                msjPrincipal.enabled = true;
                objetoReciente = objetoColisionado;
            }


        }
        if (objetoColisionado.tag == "Screwdriver")
        {
            Debug.Log("I got the third key");

            bag.Add("Screwdriver");
            IconScrewdriver.enabled = true;
            SoundKeys.PlayOneShot(GetKeys, 2.0f);
            Destroy(objetoColisionado.gameObject);
        }


        if (objetoColisionado.tag == "VentDoor" && VentClosed == true)
        {
            Debug.Log("You're in the third door");
            if (bag.Contains("Screwdriver"))
            {
                Destroy(objetoColisionado.gameObject);
            }
            else
            {
                //You dont have the first key
                msjPrincipal.text = "Objects needed: The Screwdriver";
                msjPrincipal.enabled = true;
                objetoReciente = objetoColisionado;
            }

           
            }
    
        if (objetoColisionado.tag == "Hammer")
        {
            Debug.Log("Hammer");
            bag.Add("Hammer");
            IconHammer.enabled = true;
            Destroy(objetoColisionado.gameObject);
        }
        if (objetoColisionado.tag == "Woods" && WoodClosed == true)
        {
            Debug.Log("stubid wood");
            if (bag.Contains("Hammer"))
            {
                Destroy(objetoColisionado.gameObject);
            }
            else
            {
                msjPrincipal.text = "Objects needed: 1 Hammer";
                msjPrincipal.enabled = true;
                objetoReciente = objetoColisionado;
            }

        }
        //trophy

        if (objetoColisionado.tag == "EndLv")
        {
            msjPrincipal.text = "Congrats!";
            msjPrincipal.enabled = true;
            Time.timeScale = 0;
            GoBackToMenu = true;

        }


    }
    private void OnTriggerExit(Collider objetoReciente)
    {
        msjPrincipal.enabled = false;
        objetoReciente = null;
    }


}