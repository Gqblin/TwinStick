using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStaff : Wand
{
    [SerializeField] private ParticleSystem part;
    [SerializeField] AudioClip POWAAAA;

    private AudioSource audio2;

    private float manaGone = 1;

    // Start is called before the first frame update
    void Start()
    {
        audio2 = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButtonUp("Fire1") || playerHealth.RetunManaAmount() <= manaGone)
        {
            part.Stop();
            audio2.Stop();
        }

        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < pickupDistance)
        {

            if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.F)) && !pickedUp)
            {
                pickedUp = true;
                playerEquipment.PickUp(this.gameObject);
            }
        }
    }

    public override void CastBasicSpell()
    {
        if (playerHealth.RetunManaAmount() > ReturnBasicSpellCost() * Time.deltaTime)
        {
            part.Play();
            if (!audio2.isPlaying)
            {
                audio2.PlayOneShot(POWAAAA);
            }
            playerHealth.ChangeMana(-basicSpellCost * Time.deltaTime);
        }
    }
    public override float ReturnBasicSpellCost()
    {
        return basicSpellCost * Time.deltaTime;
    }
}
