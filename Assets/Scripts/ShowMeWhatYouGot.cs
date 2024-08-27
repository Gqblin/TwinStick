using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMeWhatYouGot : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] private float moveSpeed;

    void Update()
    {
        transform.LookAt(player);
        transform.Rotate(0, 90, 0);
        transform.position -= transform.forward * moveSpeed * Time.deltaTime;
    }
}
