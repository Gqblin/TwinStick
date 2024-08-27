using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDodge : MonoBehaviour
{
    [SerializeField] GameObject parentEnemy;
    [SerializeField] private int randomDodgeChance = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBullet") || other.name == ("Lightning"))
        {
            float dodgeChange = Random.Range(0, randomDodgeChance);
            Debug.Log("random number = " + dodgeChange);

            if (dodgeChange == 0)
            {
                Debug.Log("dodged");
                //dodge
                parentEnemy.transform.position = new Vector3(parentEnemy.transform.position.x + Random.Range(-1, 2), parentEnemy.transform.position.y + Random.Range(-1, 2), parentEnemy.transform.position.z);
            }

            if (dodgeChange >= 1)
            {
                Debug.Log("Not dodged");
                //dont dodge
                return;
            }
        }
    }
}
