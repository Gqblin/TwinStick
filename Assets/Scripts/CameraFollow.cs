using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float offsetDistance = 1;
    private Transform camHeight;
    //[SerializeField] private Camera cam;

    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        camHeight = this.transform;
    }

    void Update()
    {
        this.transform.position = new Vector3(player.position.x, camHeight.position.y, player.position.z - offsetDistance);
    }
}
