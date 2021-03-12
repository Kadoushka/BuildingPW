using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = 0;
    public float gravityOffTime = 4;
    public float cooldownTime = 8;
    Vector3 velocity;
    public bool gravityOff;
    public bool cooldown;


    // Start is called before the first frame update
    void Start()
    {
        gravityOff = false;
        cooldown = false;
        GravityController.SharedInstance.gravity = 2;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && cooldown == false)
        {
            StopCoroutine(Cooldown());
            StartCoroutine(Cooldown());
            Debug.Log("Space key was pressed.");
            if (gravityOff == false)
            {
                StartCoroutine(ChangeGravity());
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) && gravityOff == true)
        {
            StopCoroutine(Cooldown());
            StartCoroutine(Cooldown());

            Debug.Log("Space key was released.");
            
            
                StopCoroutine(ChangeGravity());
                GravityOff();
                gravityOff = false;
            
        }

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


    }

    private void GravityOn()
    {
        GravityController.SharedInstance.gravity = 1;
        gravity = -10;
    }
    private void GravityOff()
    {
        GravityController.SharedInstance.gravity = 3;
        gravity = 0;
        velocity.y = 0;
    }

    private IEnumerator ChangeGravity()
    {
        gravityOff = true;
        GravityOff();
        yield return new WaitForSeconds(gravityOffTime);

        GravityOn();
        gravityOff = false;


    }
    private IEnumerator Cooldown()
    {
        GravityController.SharedInstance.gravity = 1;
        cooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        cooldown = false;
        GravityController.SharedInstance.gravity = 2;

    }
}
//1 is herladen
//2 is vol
//3 is actief