using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] GameObject newPosition;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = newPosition.transform.position;
    }
}
