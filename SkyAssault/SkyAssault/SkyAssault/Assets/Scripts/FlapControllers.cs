using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum FlapType {
    Horizontal,
    Vertical
}

public enum FlapPosition {
    Center,
    Left,
    Right
}

public class FlapControllers : MonoBehaviour
{
    public FlapType flapType ;
    public FlapPosition flapPosition ;
    public float speed = 90f; 
    public float minAngle = -85f; 
    public float maxAngle = 85f; 
    private float currentAngle = 0f; 

    
    void Update()
    {
        
       
       this.currentAngle *= 0.95f;

        float inputV = Input.GetAxis("Vertical");
        float inputH = Input.GetAxis("Horizontal");

        if(this.flapType == FlapType.Horizontal){

            
            
            float angleY = inputV ;
            
        
            this.currentAngle += angleY;


                     
            float angleX = inputH * speed * Time.deltaTime;
            
            
            if(this.flapPosition == FlapPosition.Left){
                this.currentAngle -= angleX;
            }

            if(this.flapPosition == FlapPosition.Right){
                this.currentAngle += angleX;
            }


            
            currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);

            transform.localRotation = Quaternion.Euler(-currentAngle, 0f, 0f);


        }


        if(this.flapType == FlapType.Vertical){

            float angle = inputH ;//* speed * Time.deltaTime;
            
        
            this.currentAngle += angle;

            
            currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);

            
            transform.localRotation = Quaternion.Euler(0f, -currentAngle, 0f);
        }
    }
}
