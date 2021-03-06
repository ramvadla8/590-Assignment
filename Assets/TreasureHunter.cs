﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureHunter : MonoBehaviour
{
    // Start is called before the first frame update

    

    public TextMesh text1; 

    public TextMesh text2; 

    public TextMesh text3;

    public TextMesh text4;
    public TextMesh text5;

    public TextMesh text6;

    public TextMesh text7;

    public TextMesh text8;



    

    public Inventory myInventory; 

    List<GameObject> myList ; 

    //public Camera mainCam; 

    private int scoreCounter = 0; 

    private int numItems = 0; 

    private int SphereCount = 0;
    private int CubeCount = 0;
    private int CapsuleCount = 0;
    private int CylinderCount = 0;

    public GameObject root;

    bool trapHit = false;

    public Rigidbody gameObjectsRigidBody; 

    // private int SphereScore = 0;
    // private int CubeScore = 0;
    // private int CapsuleScore = 0;
    // private int CylinderScore = 0;




    void Start()
    {
        myList = myInventory.list; 
    }

    // Update is called once per frame
    void Update()
    {
        
        
     
        
    }

    void OnTriggerExit(Collider other)
    {
       if(other.gameObject.name.Contains("Sphere")){
                numItems++; 
                SphereCount++;
                

                text1.text = "Items: " + numItems; 

                scoreCounter = scoreCounter + other.gameObject.GetComponent<Score>().points; 

                text2.text = "Score: " + scoreCounter;

                Debug.Log(other.gameObject.GetComponent<Score>().prefabName);

                myInventory.list.Add(Resources.Load(other.gameObject.GetComponent<Score>().prefabName, typeof(GameObject)) as GameObject);

                text3.text = "Speheres Collected (1 Point): " + SphereCount ;
               

                Destroy(other.gameObject);

            }

        if(other.gameObject.name.Contains("Cube")){
            numItems++; 
            CubeCount++;
            


            text1.text = "Items: " + numItems; 

            scoreCounter = scoreCounter + other.gameObject.GetComponent<Score>().points; 

            text2.text = "Score: " + scoreCounter;


            Debug.Log(other.gameObject.GetComponent<Score>().prefabName);

            myInventory.list.Add(Resources.Load(other.gameObject.GetComponent<Score>().prefabName, typeof(GameObject)) as GameObject);

       

            text4.text = "Cube Collected (2 Points): " + CubeCount;


            Destroy(other.gameObject);
        }

        if(other.gameObject.name.Contains("Capsule")){
             numItems++; 
            CapsuleCount++;

            text1.text = "Items: " + numItems; 

            scoreCounter = scoreCounter + other.gameObject.GetComponent<Score>().points; 

            text2.text = "Score: " + scoreCounter;

            Debug.Log(other.gameObject.GetComponent<Score>().prefabName);

            myInventory.list.Add(Resources.Load(other.gameObject.GetComponent<Score>().prefabName, typeof(GameObject)) as GameObject);

         

            text5.text = "Capsules Collected (3 Points): " + CapsuleCount;


            Destroy(other.gameObject);
        }
        

        if(other.gameObject.name.Contains("Cylinder")){
                 numItems++; 
                    CylinderCount++;
                text1.text = "Items: " + numItems; 

                scoreCounter = scoreCounter + other.gameObject.GetComponent<Score>().points; 

                text2.text = "Score: " + scoreCounter;

                Debug.Log(other.gameObject.GetComponent<Score>().prefabName);

                myInventory.list.Add(Resources.Load(other.gameObject.GetComponent<Score>().prefabName, typeof(GameObject)) as GameObject);

               

                text6.text = "Cylinders Collected (4 Points): " + CylinderCount++;


                Destroy(other.gameObject);
            }


        // COde to add rigid body: https://answers.unity.com/questions/19466/how-do-i-add-a-rigidbody-in-script.html

        if (numItems == 5)
        {
            gameObjectsRigidBody = root.AddComponent<Rigidbody>(); //Add the rigidbody.
            gameObjectsRigidBody.mass = 5; // Set the GO's mass to 5 via the Rigidbody.
            trapHit = true; 
        }
    }

    void FixedUpdate()
    {
        if (trapHit)
        {
            gameObjectsRigidBody.AddForce(transform.up * 0.3f);
        }
        
    }
}
