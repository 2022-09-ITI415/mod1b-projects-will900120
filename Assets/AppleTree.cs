using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]

    //Prefab for instantiating apples
    public GameObject applePrefabs;

    //Speed at which the AppleTree moves
    public float speed = 1f;

    //Distance where AppleTree turns around
    public float leftAndRightEdge = 20;

    //Chance that the AppleTree will change di
    public float chanceToChangeDirection;

    //Rate at which Apples will be instantiate
    public float secondsBetweenAppleDrop;

    // Start is called before the first frame update
    void Start()
    {
        //Dropping apples every second
        Invoke("DropApple", 2f);
    }

    void DropApple(){
        GameObject apple = Instantiate<GameObject> (applePrefabs);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrop);
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
       
        //Changing Direction
        if(pos.x < -leftAndRightEdge){
            speed = Mathf.Abs(speed);
        }
        else if(pos.x > leftAndRightEdge){
            speed = -Mathf.Abs(speed);
        }
    }

    void FixedUpdate(){
        //Changing Direction Randomly is not t
        if(Random.value < chanceToChangeDirection){
            speed *= -1;
        }
    }
}
