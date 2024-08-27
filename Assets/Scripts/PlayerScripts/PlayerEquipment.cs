using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public List<GameObject> currentWand = new List<GameObject>();
    [SerializeField] private List<GameObject> equipment = new List<GameObject>();

    [SerializeField] private GameObject weaponGameobject;
    private PlayerHealth playerHealth;

    private SpellInfo spellInfo;
    private Wand wand;
    private PlayerLevel playerLevel;

    public int selectedWeapon;

    PauseGame pause;

    void Start()
    {
        pause = FindObjectOfType<PauseGame>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        spellInfo = FindObjectOfType<SpellInfo>();
        playerLevel = FindObjectOfType<PlayerLevel>();
    }

    void Update()
    {
        //if(currentWeapon != null && !pause.paused)
        //{
        //    if (wand.ReturnWeaponType() == "SemiAuto")
        //    {
        //        if (Input.GetButtonDown("Fire1"))
        //        {
        //            weapon.Shoot();
        //        }
        //    }
        //    if (weapon.ReturnWeaponType() == "Auto")
        //    {
        //        if (Input.GetButton("Fire1"))
        //        {
        //            weapon.Shoot();
        //        }
        //    }
        //}

        if(Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWand[0] != null && currentWand[1] != null)
            {
                SwapWeapon();
            }
        }

        if(currentWand.Count > 1 && !pause.paused)
        {
            if (wand.ReturnBasicSpellType() == true)
            {
                if (Input.GetButton("Fire1"))
                {
                    if (playerHealth.RetunManaAmount() >= wand.ReturnBasicSpellCost())
                    {
                        wand.CastBasicSpell();
                    }
                }
                else if (Input.GetButtonUp("Fire1"))
                {
                    wand.LeftMouseReleased();
                }
            }
            else
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    if (playerHealth.RetunManaAmount() >= wand.ReturnBasicSpellCost())
                    {
                        wand.CastBasicSpell();
                    }
                }
            } 
        }

        if (currentWand.Count > 1 && !pause.paused)
        {
            if(wand.ReturnSpecialSpellType() == true)
            {
                if (Input.GetButton("Fire2"))
                {
                    if (playerHealth.RetunManaAmount() >= wand.ReturnSpecialSpellCost())
                    {
                        wand.CastSpecialSpell();
                    }
                    else
                    {
                        wand.StopSpecialSpell();
                    }
                }
                else if (Input.GetButtonUp("Fire2"))
                {
                    wand.RightMouseReleased();
                }
            }
            else
            {
                if (Input.GetButtonDown("Fire2"))
                {
                    if (playerHealth.RetunManaAmount() >= wand.ReturnSpecialSpellCost())
                    {
                        wand.CastSpecialSpell();
                    }
                }
            } 
        }

    }

    public void PickUp(GameObject item)
    {
        if (item.gameObject.CompareTag("Weapon"))
        {
            if (currentWand[0] == null)
            {
                currentWand[0] = item;
                currentWand[0].transform.parent = weaponGameobject.transform;
                currentWand[0].transform.localRotation = new Quaternion(0, 0, 0, 0);
                currentWand[0].transform.localPosition = new Vector3(0, 0, 0);
                wand = currentWand[0].gameObject.GetComponent<Wand>();
                currentWand.Add(null);
                playerLevel.ChangeWand(currentWand[0]);
                spellInfo.UpdateSpellInfo(wand);
            }
            else if(currentWand[1] == null)
            {
                currentWand[1] = item;
                currentWand[1].transform.parent = weaponGameobject.transform;
                currentWand[1].transform.localRotation = new Quaternion(0, 0, 0, 0);
                currentWand[1].transform.localPosition = new Vector3(0, 0, 0);
                selectedWeapon = 1;
                wand = currentWand[selectedWeapon].gameObject.GetComponent<Wand>();
                currentWand[0].GetComponent<MeshRenderer>().enabled = false;
                spellInfo.UpdateSpellInfo(wand);
            }
            else if(currentWand[selectedWeapon] != null)
            {
                GameObject WeaponToPickUp = item;
                currentWand[selectedWeapon].transform.parent = null;
                currentWand[selectedWeapon].transform.position = WeaponToPickUp.transform.position;
                currentWand[selectedWeapon].transform.rotation = WeaponToPickUp.transform.rotation;
                currentWand[selectedWeapon] = WeaponToPickUp;
                StartCoroutine("SwtichWeapon");
            }
            
            
        }
        else if (item.gameObject.CompareTag("Equipment"))
        {
            equipment.Add(item);
        }
        
    }

    public bool ItemCheck(GameObject item)
    {
        //print(equipment.Count);
        bool foundItem = false;
        for(int i = 0; i < equipment.Count; i++)
        {
            //print(i);
            if (equipment[i] == item)
            {
                foundItem = true;
            }
        }
        return foundItem;
    }

    public Wand ReturnWand()
    {
        return wand;
    }

    public GameObject ReturnWeapon()
    {
        return currentWand[0];
    }

    private void SwapWeapon(/*int weaponToSwap*/)
    {
        if (selectedWeapon == 0)
        {
            currentWand[0].GetComponent<MeshRenderer>().enabled = false;
            selectedWeapon = 1;
            currentWand[1].GetComponent<MeshRenderer>().enabled = true;
            wand = currentWand[selectedWeapon].gameObject.GetComponent<Wand>();
            spellInfo.UpdateSpellInfo(wand);
        }
        else
        {
            currentWand[1].GetComponent<MeshRenderer>().enabled = false;
            selectedWeapon = 0;
            currentWand[0].GetComponent<MeshRenderer>().enabled = true;
            wand = currentWand[selectedWeapon].gameObject.GetComponent<Wand>();
            spellInfo.UpdateSpellInfo(wand);
        }
    }

    IEnumerator SwtichWeapon()
    {
        //print("gvdfb");
        yield return new WaitForSeconds(0.01f);
        wand.DropWeapon();

        currentWand[selectedWeapon].transform.parent = weaponGameobject.transform;
        currentWand[selectedWeapon].transform.rotation = new Quaternion(0, 0, 0, 0);
        currentWand[selectedWeapon].transform.localPosition = new Vector3(0, 0, 0);
        playerLevel.ChangeWand(currentWand[selectedWeapon]);
        wand = currentWand[selectedWeapon].gameObject.GetComponent<Wand>();
        spellInfo.UpdateSpellInfo(wand);
    }

}
