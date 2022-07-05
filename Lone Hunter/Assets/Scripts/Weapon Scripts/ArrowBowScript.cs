using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBowScript : MonoBehaviour
{
    private Rigidbody myBody;
    public float speed = 30f;
    public float deactivate_Timer = 3f;
    public float damage = 50f;


    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Invoke("DeactivateGameObject", deactivate_Timer);
    }    

    void DeactivateGameObject()
    {
        if(gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }

    public void Launch(Camera mainCamera)
    {
        myBody.velocity = mainCamera.transform.forward * speed;
        transform.LookAt(transform.position + myBody.velocity);
    }

    private void OnTriggerEnter(Collider target)
    {
        //after touching the target deactivate the game object
    }
}
