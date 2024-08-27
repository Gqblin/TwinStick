using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardDoor : MonoBehaviour
{
    [SerializeField] GameObject doorRight;
    [SerializeField] GameObject doorLeft;
    [SerializeField] GameObject neededKeyCard;
    [SerializeField] float speed = 1f;

    private Player player;
    private PlayerEquipment playerEquipment;
    private float interactDistance = 1f;

    private float maxOpenDoorRight = 1.5f;
    private float maxCloseDoorRight = 0.5f;

    private float maxOpenDoorLeft = -1.5f;
    private float maxCloseDoorLeft = -0.5f;

    private bool isOpen = false;
    private bool open = false;
    private bool isOpenedWithKeyCard;
    //private bool playerIsClose;

    private float counter;
    private float timeBeforeClose = 2f;

    void Start()
    {
        player = FindObjectOfType<Player>();
        playerEquipment = FindObjectOfType<PlayerEquipment>();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < interactDistance)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.F))
            {
                if (!isOpen)
                {
                    if (playerEquipment.ItemCheck(neededKeyCard) == true || neededKeyCard == null)
                    {
                        open = true;
                    }
                }
                else
                {
                    open = false;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if(open == true)
        {
            OpenDoor();
        }

        if(open == false)
        {
            CloseDoor();
        }
    }

    private void OpenDoor()
    {
        isOpen = true;
        if (doorRight.transform.localPosition.z < maxOpenDoorRight)
        {
            doorRight.transform.Translate(-speed * Time.deltaTime, 0f, 0f);
            if (doorRight.transform.localPosition.z >= maxOpenDoorRight)
            {
                doorRight.transform.localPosition = new Vector3(doorRight.transform.localPosition.x, doorRight.transform.localPosition.y, maxOpenDoorRight);
            }
        }

        if (doorLeft.transform.localPosition.z > maxOpenDoorLeft)
        {
            doorLeft.transform.Translate(speed * Time.deltaTime, 0f, 0f);
            if (doorLeft.transform.localPosition.z <= maxOpenDoorLeft)
            {
                doorLeft.transform.localPosition = new Vector3(doorLeft.transform.localPosition.x, doorLeft.transform.localPosition.y, maxOpenDoorLeft);
                StartCoroutine("AutoCloseDoor");
            }
        }
    }

    private void CloseDoor()
    {
        isOpen = false;
        if (doorRight.transform.localPosition.z > maxCloseDoorRight)
        {
            doorRight.transform.Translate(speed * Time.deltaTime, 0f, 0f);
            if (doorRight.transform.localPosition.z <= maxCloseDoorRight)
            {
                doorRight.transform.localPosition = new Vector3(doorRight.transform.localPosition.x, doorRight.transform.localPosition.y, maxCloseDoorRight);
            }
        }

        if (doorLeft.transform.localPosition.z < maxCloseDoorLeft)
        {
            doorLeft.transform.Translate(-speed * Time.deltaTime, 0f, 0f);
            if (doorLeft.transform.localPosition.z >= maxCloseDoorLeft)
            {
                doorLeft.transform.localPosition = new Vector3(doorLeft.transform.localPosition.x, doorLeft.transform.localPosition.y, maxCloseDoorLeft);
                StopCoroutine("AutoCloseDoor");
            }
        }
    }

    IEnumerator AutoCloseDoor()
    {
        yield return new WaitForSeconds(timeBeforeClose);
        open = false;
    }

}
