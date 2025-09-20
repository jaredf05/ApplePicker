using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Scripting.APIUpdating;

public class AppleTree : MonoBehaviour {
    [Header("Inscribed")]
    //Prefab for instantiating apples
    public GameObject applePrefab;

    //Speed at which the AppleTree moves
    public float speed = 1f;

    //Distance where AppleTree moves
    public float leftAndRightEdge = 10f;

    //Chance that the AppleTree will change directions
    public float changeDirChance = 0.1f;

    //Seconds between Apples instantiations
    public float appleDropDelay = 1f;

    public GameObject branchPrefab;
    public float branchDropChance = 0.1f;


    void Start()
    {
        //Start dropping apples
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject obj;

        // Random chance to drop a branch instead of an apple
        if (Random.value < branchDropChance)  //  0.1 = 10% chance
        {
            obj = Instantiate<GameObject>(branchPrefab);
        }
        else
        {
            obj = Instantiate<GameObject>(applePrefab);
        }

        obj.transform.position = transform.position;

        // Keep calling this method repeatedly
        Invoke("DropApple", appleDropDelay);
    }


    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //Move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //Move left
        // }
        // else if (Random.value < changeDirChance)
        // {
        //     speed *= -1; //Change direction
    }
}

    void FixedUpdate()
    {
        //Random direction changes are now time-based due to FixedUpdate()
        if (Random.value < changeDirChance)
        {
            speed *= -1; //Change direction
        }
    }
}
