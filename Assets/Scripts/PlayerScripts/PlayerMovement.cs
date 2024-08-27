using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float sprintSpeed = 3.0f;
    [SerializeField] private float sneakSpeed = 1.0f;
    [SerializeField] private float cooldown = 1.0f;
    [SerializeField] private float dashPower = 20.0f;
    [SerializeField] private GameObject dashParticles;
    [SerializeField] private Image dashUI;
    [SerializeField] private FirstPersonCam fpsCam;
    [SerializeField] private float coolTime;

    private float cooldownUI;

    PauseGame pause;
    private Rigidbody rb;

    private Camera mainCamera;

    private Vector3 input;
    private Vector3 velocity;

    private bool inFirstPerson;
    private bool dashing;
    private bool dashUICooldown = false;


    private void Start()
    {
        pause = FindObjectOfType<PauseGame>();
        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        Physics.IgnoreLayerCollision(6, 6);
        Physics.IgnoreLayerCollision(6, 7);
        Physics.IgnoreLayerCollision(7, 7);
    }

    void Update()
    {
        if (!dashUICooldown && dashing == true)
        {
            dashUICooldown = true;
            StartCoroutine("DashCoolDownUI");
        }

        if (Input.GetKeyDown(KeyCode.Space) && dashing == false && dashUICooldown == false)
        {
            StartCoroutine("Dash");
        }

        input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        if (!inFirstPerson)
        {  
            //Vector3 movement = input.normalized;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                velocity = input * sprintSpeed;
                //velocity = movement * sprintSpeed;
            }
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                velocity = input * sneakSpeed;
            }
            else
            {
                velocity = input * playerSpeed;
                //velocity = movement * sprintSpeed;

            }
            if (!pause.paused)
            {
                Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
                Plane plane = new Plane(Vector3.up, Vector3.zero);
                float rayLength;

                if (plane.Raycast(cameraRay, out rayLength))
                {
                    Vector3 lookPoint = cameraRay.GetPoint(rayLength);
                    Debug.DrawLine(cameraRay.origin, lookPoint, Color.blue);

                    transform.LookAt(new Vector3(lookPoint.x, transform.position.y, lookPoint.z));
                }
            }
        }
        else
        {
            //fpsCam.MouseAiming();
            input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            Vector3 normelized = input.normalized;
            Vector3 movement = normelized * Time.deltaTime * playerSpeed;
            transform.Translate(movement);
        }
    }

    private IEnumerator DashCoolDownUI()
    {
        cooldownUI = 0;

        while (true)
        {
            cooldownUI += Time.deltaTime;
            dashUI.fillAmount = cooldownUI / coolTime;

            if (cooldownUI >= coolTime)
            {
                dashUICooldown = false;
                new WaitForSeconds(0.1f);
                dashUI.fillAmount = 0;
                StopCoroutine("DashCoolDownUI");
            }
            yield return null;
        }
    }

    private void Dash()
    {
        dashing = true;
        playerSpeed += dashPower;
        sprintSpeed += dashPower;
        sneakSpeed += dashPower;
        dashParticles.SetActive(true);
        StartCoroutine("DashCoolDown");
    }

    private IEnumerator DashCoolDown()
    {
        yield return new WaitForSeconds(0.1f);
        playerSpeed -= dashPower;
        sprintSpeed -= dashPower;
        sneakSpeed -= dashPower;
        dashParticles.SetActive(false);
        yield return new WaitForSeconds(cooldown);
        dashing = false;
    }

    private void FixedUpdate()
    {
        rb.velocity = velocity;
    }

    public void FirstPersonCam()
    {
        inFirstPerson = true;
    }

    public void SetSpeed(float speed)
    {
        playerSpeed = speed;
    }
}
