using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HenkScript : MonoBehaviour
{
    public bool activated = false;
    [SerializeField] private GameObject bone;
    [SerializeField] private GameObject player;
    [SerializeField] private float boneSpeed = 2f;
    [SerializeField] private float Cooldown = 0.5f;
    [SerializeField] private Transform throwLocation;
    private bool CooldownOver = true;
    IntroLevelManager introlvlManager;


    // Start is called before the first frame update
    void Start()
    {
        introlvlManager = FindObjectOfType<IntroLevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activated && introlvlManager.henkCanAttack)
        {
            if (CooldownOver)
            {
                StartCoroutine("YeetBones");
            }
        }
    }

    private void YeetBone()
    {
        Vector3 playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        Vector3 direction = (playerPosition - throwLocation.localPosition).normalized;

        GameObject tempBone = Instantiate(bone, throwLocation.localPosition, Quaternion.LookRotation(direction)) as GameObject;
        Rigidbody tempRigidBodyBone = tempBone.GetComponent<Rigidbody>();
        tempRigidBodyBone.AddForce(direction * boneSpeed);
    }

    private IEnumerator YeetBones()
    {
        CooldownOver = false;
        yield return new WaitForSeconds(Cooldown);
        YeetBone();
        CooldownOver = true;
    }

    //IEnumerator BasicCooldown(float cooldown)
    //{
    //    CooldownOver = false;
    //    yield return new WaitForSeconds(cooldown);
    //    CooldownOver = true;
    //}
}
