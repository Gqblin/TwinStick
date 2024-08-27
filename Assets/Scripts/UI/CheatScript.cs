using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheatScript : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Camera firstPersonCamera;
    [SerializeField] private Camera topDownCam;
    [SerializeField] private PlayerMovement playerMovement;

    private void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && inputField.text == ("ShootForDays"))
        {
            Wand wand = FindObjectOfType<Wand>();
            Debug.Log("Got unlimited ammo");
            inputField.text = null;
        }
        if (Input.GetKeyDown(KeyCode.Return) && inputField.text == ("Undying"))
        {
            PlayerHealth health = FindObjectOfType<PlayerHealth>();
            health.infiniteHealth = true;
            Debug.Log("No dying today");
            inputField.text = null;
        }
        if (Input.GetKeyDown(KeyCode.Return) && inputField.text == ("SanicMode"))
        {
            PlayerMovement movement = FindObjectOfType<PlayerMovement>();
            movement.SetSpeed(20);
            Debug.Log("Sanic speed");
            inputField.text = null;
        }
        if (Input.GetKeyDown(KeyCode.Return) && inputField.text == ("GodMode"))
        {
            Player player = FindObjectOfType<Player>();
            player.GetComponent<CapsuleCollider>().isTrigger = true;
            PlayerHealth health = FindObjectOfType<PlayerHealth>();
            health.infiniteHealth = true;
            Debug.Log("Jesus is back");
            inputField.text = null;
        }
        if (Input.GetKeyDown(KeyCode.Return) && inputField.text == ("GodModeOff"))
        {
            Player player = FindObjectOfType<Player>();
            player.GetComponent<CapsuleCollider>().isTrigger = false;
            PlayerHealth health = FindObjectOfType<PlayerHealth>();
            health.infiniteHealth = false;
            Debug.Log("Jesus is back");
            inputField.text = null;
        }
        if (Input.GetKeyDown(KeyCode.Return) && inputField.text == ("FirstPerson"))
        {
            //Player player = FindObjectOfType<Player>();
            topDownCam.gameObject.SetActive(false);
            firstPersonCamera.gameObject.SetActive(true);
            playerMovement.FirstPersonCam();
            //Debug.Log("Jesus is back");
            inputField.text = null;
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Invalid Cheat");
            inputField.text = null;
        }
    }
}