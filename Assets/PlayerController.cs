using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Set Dynamically")]
    [Header("Set Dynamically")]
    public float speed = 0;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public Text scoreGT;
    public Text livesGT;
    
    
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        GameObject scoreGO = GameObject.Find("CountText");
        GameObject liveGO = GameObject.Find("Lives");
        scoreGT = scoreGO.GetComponent<Text>();
        livesGT = liveGO.GetComponent<Text>();
        scoreGT.text = "0";
        livesGT.text = "5";
    }

    void OnMove(InputValue movementValue){
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }


    void FixedUpdate(){
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void Update(){
          if (Input.GetKeyDown ("space")){
                  transform.Translate(Vector3.up * 260 * Time.deltaTime, Space.World);
          }
    }
    
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("PickUp")){
            other.gameObject.SetActive(false);

            int score = int.Parse( scoreGT.text );
            score += 100;
            scoreGT.text = score.ToString();
        }
    }

    void OnCollisionEnter(Collision coll){
        GameObject collidedWith = coll.gameObject;
        if(collidedWith.tag == "Apple"){
            Destroy(collidedWith);

            int lives = int.Parse( livesGT.text );
            lives -= 1;
            livesGT.text = lives.ToString();
            
        }
    }
}
