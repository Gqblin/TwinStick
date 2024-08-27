using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerEquipment playerEquipment;

    private float interactDistance = 1.5f;
    private MeshRenderer meshRenderer;
    
    void Start()
    {
        player = FindObjectOfType<Player>();
        playerEquipment = FindObjectOfType<PlayerEquipment>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if(distance < interactDistance)
        {
            //show message

            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.F))
            {
                playerEquipment.PickUp(this.gameObject);
                meshRenderer.enabled = false;
            }
        }
    }
}
