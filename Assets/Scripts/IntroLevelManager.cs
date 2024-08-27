using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroLevelManager : MonoBehaviour
{
    HealthPickUp health;

    [SerializeField] private TextMeshProUGUI welcomeText;
    [SerializeField] private GameObject introDoor;
    [SerializeField] private GameObject wandOutroDoor;
    [SerializeField] private GameObject startWand;
    [SerializeField] private GameObject lightningWand;
    [SerializeField] private GameObject enemyRoomCollider;
    [SerializeField] private GameObject enemyOutroDoor;
    [SerializeField] private GameObject henkRoomCollider;
    [SerializeField] private GameObject henkOutroDoor;
    [SerializeField] private GameObject healthRoomCollider;
    [SerializeField] private GameObject healthOutroDoor;

    private bool wandCoroutineStarted;
    private bool enemiesDefeatedCoroutineStarted;
    private bool enemyDoorsClosed;
    private bool henkDoorsClosed;
    private bool henkExplanationBegun;
    public bool henkCanAttack;
    private bool healthDoorClosed;
    private bool healthCoroutineStarted;

    private void Start()
    {
        StartCoroutine("Welcoming");
        health = FindObjectOfType<HealthPickUp>();
    }

    private void Update()
    {
        if (!wandCoroutineStarted)
        {
            CheckIfWandsPickedUp();
        }

        if (enemyRoomCollider.GetComponent<EnemyRoomCheck>().playerEntered == true && !enemyDoorsClosed)
        {
            CloseDoorsEnemyRoom();
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0 && enemiesDefeatedCoroutineStarted == false)
        {
            StartCoroutine("EnemiesDefeated");
            enemiesDefeatedCoroutineStarted = true;
        }

        if (henkRoomCollider.GetComponent<HenkRoomCheck>().playerEntered == true && !henkDoorsClosed)
        {
            CloseDoorsHenkRoom();
        }

        if (henkDoorsClosed == true && !henkExplanationBegun)
        {
            StartCoroutine("HenkExplanation");
            henkExplanationBegun = true;
        }

        if (healthRoomCollider.GetComponent<HealthRoomCheck>().playerEntered == true && !healthDoorClosed)
        {
            StartCoroutine("HealthCheck");
            healthDoorClosed = true;
        }

        if (health.healthPickedUp == true && !healthCoroutineStarted)
        {
            StartCoroutine("HealthPickedUp");
            healthCoroutineStarted = true;
        }
    }

    private IEnumerator Welcoming()
    {
        welcomeText.text = ("Welcome to Magic Mayhem!");

        yield return new WaitForSeconds(3f);

        welcomeText.text = ("In this intro level you will learn what you need to know for the game");

        yield return new WaitForSeconds(5f);

        welcomeText.text = ("Good luck...");

        yield return new WaitForSeconds(1f);

        welcomeText.text = null;

        introDoor.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine("HowWandsWork");
            introDoor.SetActive(true);
            wandOutroDoor.SetActive(true);
        }
    }

    private IEnumerator HowWandsWork()
    {

        welcomeText.text = ("In this game we use wands to kill enemies");

        yield return new WaitForSeconds(2.5f);

        welcomeText.text = ("Try picking up those 2 wands at the table with E");

        yield return new WaitForSeconds(2.5f);

        welcomeText.text = null;
    }

    private void CheckIfWandsPickedUp()
    {
        if (lightningWand.GetComponent<LightningStaff>().pickedUp == true && startWand.GetComponent<BasicWand>().pickedUp == true)
        {
            StartCoroutine("WandsPickedUp");
            wandCoroutineStarted = true;
        }
    }

    private IEnumerator WandsPickedUp()
    {
        welcomeText.text = ("Nicely done! With these 2 wands you can kill enemies that are in your way!");

        yield return new WaitForSeconds(3f);

        welcomeText.text = ("With the mouse scroll button you can switch weapons. You can always have a max of 2 staffs tho!");

        yield return new WaitForSeconds(4f);

        welcomeText.text = ("With the left mouse button you do a normal attack and with the right mouse button you do a special attack. Try it out!");

        yield return new WaitForSeconds(5f);

        welcomeText.text = null;

        yield return new WaitForSeconds(7);

        welcomeText.text = ("Keep a lookout for that blue bar down there tho! that is your mana");

        yield return new WaitForSeconds(4f);

        welcomeText.text = ("Mana regenerates automaticly after a few seconds. Each attack uses a different amount");

        yield return new WaitForSeconds(4f);

        welcomeText.text = ("Now try it out on the enemy in the next room!");

        yield return new WaitForSeconds(2.5f);

        welcomeText.text = null;

        wandOutroDoor.SetActive(false);
    }

    private void CloseDoorsEnemyRoom()
    {
        wandOutroDoor.SetActive(true);
        enemyOutroDoor.SetActive(true);
        enemyDoorsClosed = true;
    }

    private IEnumerator EnemiesDefeated()
    {
        welcomeText.text = ("You actually defeated him, well done!");

        yield return new WaitForSeconds(2f);

        welcomeText.text = ("As you can see, you got some EXP from that, with this you can lvl up your stats!");

        yield return new WaitForSeconds(3.5f);

        welcomeText.text = ("Health and mana are pretty self explanatory but strength means a higher damage multiplier, so more damage. Now go ahead and choose what you want :)");

        yield return new WaitForSeconds(5f);

        welcomeText.text = null;

        yield return new WaitForSeconds(4f);

        welcomeText.text = ("Now another important thing is dodging, you dont want to die really fast of course");

        yield return new WaitForSeconds(4f);

        welcomeText.text = ("In the next room we will practise this, so go ahead!");

        yield return new WaitForSeconds(2.5f);

        welcomeText.text = null;

        enemyOutroDoor.SetActive(false);
    }

    private void CloseDoorsHenkRoom()
    {
        enemyOutroDoor.SetActive(true);
        henkOutroDoor.SetActive(true);
        henkDoorsClosed = true;
    }

    private IEnumerator HenkExplanation()
    {
        welcomeText.text = ("This is henk, he will help you learn to dodge :)");

        yield return new WaitForSeconds(2f);

        welcomeText.text = ("You have 2 more movements options. While holding shift youre a bit faster, just like youre running");

        yield return new WaitForSeconds(4f);

        welcomeText.text = ("The other is an dodge, press spacebar to try it!");

        yield return new WaitForSeconds(2f);

        welcomeText.text = null;

        yield return new WaitForSeconds(5f);

        welcomeText.text = ("As you can see it has a cooldown, so you cant just spam it");

        yield return new WaitForSeconds(2.5f);

        welcomeText.text = ("Now try to survive for about half a minute, good luck :)");

        yield return new WaitForSeconds(2.5f);

        welcomeText.text = null;

        henkCanAttack = true;

        yield return new WaitForSeconds(30f);

        henkCanAttack = false;

        yield return new WaitForSeconds(1.5f);

        welcomeText.text = ("Heyyy well done! You actually survived, honestly didnt believe you could. Now you can go on to the next room");

        yield return new WaitForSeconds(5f);

        welcomeText.text = null;
        henkOutroDoor.SetActive(false);
    }

    private IEnumerator HealthCheck()
    {
        henkOutroDoor.SetActive(true);

        welcomeText.text = ("Youve most likely been hit, so its time for the next and last thing, healing!");

        yield return new WaitForSeconds(3.5f);

        welcomeText.text = ("When you are close to the healing item on the ground, press E to pick it up. EZ!");

        yield return new WaitForSeconds(4f);

        welcomeText.text = null;
    }

    private IEnumerator HealthPickedUp()
    {
        welcomeText.text = ("Well done, now youve regained some of your health back :)");

        yield return new WaitForSeconds(3.5f);

        welcomeText.text = ("This might not be the only way to get HP back tho, but that you will have to find out yourself!");

        yield return new WaitForSeconds(4f);

        welcomeText.text = ("Now off you go! Good luck my fren, i wish you well! :)");

        yield return new WaitForSeconds(3f);

        welcomeText.text = null;

        healthOutroDoor.SetActive(false);
    }
}
