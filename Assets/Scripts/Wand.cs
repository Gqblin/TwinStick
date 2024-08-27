using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    [SerializeField] protected GameObject basicSpellObject;
    [SerializeField] protected float basicSpellDamage;
    [SerializeField] protected float basicSpellSpeed;
    [SerializeField] protected float basicSpellCost;
    [SerializeField] protected float basicSpellCastInterval;
    [SerializeField] protected string basicSpellInfo = "LMB:";
    [SerializeField] protected bool basicIsAuto = false;

    [SerializeField] protected GameObject specialSpellObject;
    [SerializeField] protected float specialSpellDamage;
    [SerializeField] protected float specialSpellSpeed;
    [SerializeField] protected float specialSpellCost;
    [SerializeField] protected float specialSpellCastInterval;
    [SerializeField] protected string specialSpellInfo = "RMB:";
    [SerializeField ]protected bool specialIsAuto = false;

    public float damageMultiplier = 1;

    protected bool basicCooldownOver = true;
    protected bool specialCooldownOver = true;

    protected Player player;
    protected PlayerEquipment playerEquipment;
    protected PlayerHealth playerHealth;
    protected float pickupDistance = 1f;

    public bool pickedUp;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        playerEquipment = FindObjectOfType<PlayerEquipment>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    public virtual void Update()
    {
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

    public virtual void CastBasicSpell()
    {
        if (basicCooldownOver)
        {
            GameObject basicSpell = Instantiate(basicSpellObject, transform.position, transform.rotation);
            basicSpell.GetComponent<Bullet>().SetBulletStats(basicSpellDamage * damageMultiplier, basicSpellSpeed);
            StartCoroutine(BasicCooldown(basicSpellCastInterval));
            playerHealth.ChangeMana(-basicSpellCost);
        }
    }  
    
    public virtual void CastSpecialSpell()
    {
        if (specialCooldownOver)
        {
            GameObject specialSPell = Instantiate(specialSpellObject, transform.position, transform.rotation);
            specialSPell.GetComponent<Bullet>().SetBulletStats(specialSpellDamage * damageMultiplier, specialSpellSpeed);
            StartCoroutine(SpecialCooldown(specialSpellCastInterval));
            playerHealth.ChangeMana(-specialSpellCost);
        }
    }
    
    public virtual float ReturnBasicSpellCost()
    {
        return basicSpellCost;
    }

    public virtual float ReturnSpecialSpellCost()
    {
        return specialSpellCost;
    }

    public bool ReturnBasicSpellType()
    {
        return basicIsAuto;
    }

    public bool ReturnSpecialSpellType()
    {
        return specialIsAuto;
    }

    public string ReturnBasicSpellInfo()
    {
        return basicSpellInfo;
    }

    public string ReturnSpecialSpellInfo()
    {
        return specialSpellInfo;
    }

    public virtual void StopSpecialSpell()
    {

    }

    public virtual void LeftMouseReleased()
    {

    }

    public virtual void RightMouseReleased()
    {

    }

    public void DropWeapon()
    {
        pickedUp = false;
    }

    public void MultiplyDamage(float amount)
    {
        damageMultiplier = amount;
    }

    IEnumerator BasicCooldown(float cooldown)
    {
        basicCooldownOver = false;
        yield return new WaitForSeconds(cooldown);
        basicCooldownOver = true;
    }

    IEnumerator SpecialCooldown(float cooldown)
    {
        specialCooldownOver = false;
        yield return new WaitForSeconds(cooldown);
        specialCooldownOver = true;
    }
}
