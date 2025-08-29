using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class playercontroler : MonoBehaviour
{
    public float speed=0;
    private Rigidbody rb;
    private int cnt;
    public TextMeshProUGUI cnttxt;
    private float movementX;
    private float movementY;
    public GameObject winTextObject;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cnt=0;
        Setcnttxt();
        winTextObject.SetActive(false);
    }
    

    void OnMove(InputValue momentValue)
    {
        Vector2 movementVector = momentValue.Get<Vector2>();
        movementX = movementVector.x; // lowercase x
        movementY = movementVector.y; // lowercase y
    }
    void Setcnttxt()
    {
        cnttxt.text= "Count : " + cnt.ToString();
        if(cnt>=11)
        {
            winTextObject.SetActive(true);
            
            Destroy(GameObject.FindGameObjectWithTag("enemy"));
            

        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement*speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
            

            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "LOSE!!";
          

        }
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.CompareTag("pickup"))
        {
             other.gameObject.SetActive(false);
             cnt++;
             Setcnttxt();

        }
    }
}
