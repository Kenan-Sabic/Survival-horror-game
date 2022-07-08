using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankControls2 : MonoBehaviour
{
     //reference variable declarations
   PlayerTankControls playerTankControls;
   InputAction movement;
   InputAction turning;
   Rigidbody rigidbody;


   //variables that store player input
   float currentMovementInput;
   float currentRotationInput;
   
   Vector3 currentMovement;
   float currentRotation;

   bool isMovementPressed;
   bool isRotationPressed;

   void Awake(){
  // rigidbody = GetComponent<Rigidbody>();  //character controller




   }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
