using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerRotation : MonoBehaviour
{
    // auto rotation speed decrease by time

    [SerializeField] private float speed = 400f;
    public float lerpTime = 0.01f;
    public float rePossitionTime = 3f;


    private Vector3 pressPosition;
    private Vector3 actualPosition;
    private Vector3 preActualPosition;

    private Vector3 rotationValue; 
    private Quaternion initialRotation;
    private bool isRotating = false;
    private float timer;
    private float speedOfRotation = 0;

    private float difference = 0f;
    private float differencePauseDrag = 1f;

    private float distanceOfTouch ;
    private bool isDragOver = false ;



    private float afterTouchRotateSpeed = 500f;

    private void Start() {
        initialRotation = transform.rotation;
    }

    private void Update() {

        if(!isRotating)
        {
            if( ( difference < 0 && differencePauseDrag < 0 ) || ( difference > 0 && differencePauseDrag < 0 ) )
            {   //here condition if difference is increasing
                rotationValue = Vector3.up;
                DecideAfterTouchRotateSpeed();
            }
            else if( ( difference > 0 && differencePauseDrag > 0 ) || ( difference < 0 && differencePauseDrag > 0 ) )
            {   //here condition if difference is decreasing
                rotationValue = Vector3.down;
                DecideAfterTouchRotateSpeed();
            }
            else
            {                    
                StartCoroutine(ResetPosition());
            }
            
        }
            
    }
    private void OnMouseDown() {
        //for on object collition
        isRotating = true;
        pressPosition = Input.mousePosition;
        isDragOver = false;
        timer = Time.time;
        StopAllCoroutines();
    }

    private void OnMouseDrag() {
        if(Input.GetMouseButton(0) && isRotating)
        {
            actualPosition = Input.mousePosition;

            difference = (actualPosition.x - pressPosition.x);
            
            differencePauseDrag = actualPosition.x - preActualPosition.x; 


            if(!isDragOver){

                if(differencePauseDrag == 0){
                    pressPosition = actualPosition;
                    actualPosition = Input.mousePosition;
                    timer = Time.time;
                }
                if(actualPosition.x < preActualPosition.x){
                    timer = Time.time;
                }

                distanceOfTouch = Vector3.Distance(pressPosition, actualPosition);
                speedOfRotation = distanceOfTouch / (Time.time - timer);
                // Debug.Log("speed is      " + speedOfRotation);
                // Debug.Log("Time is      " + (Time.time - timer));
            }


            if((difference < 0 && differencePauseDrag < 0) || ( difference > 0 && differencePauseDrag < 0 ))
            {
                rotationValue = Vector3.up;
                RotatePlayer();
                
                preActualPosition = actualPosition;
            }
            else if( ( difference > 0 && differencePauseDrag > 0 ) || ( difference < 0 && differencePauseDrag > 0 ) )
            {
                rotationValue = Vector3.down;
                RotatePlayer();
                
                preActualPosition = actualPosition;
            }
        }
    }

    private void OnMouseUp() {

        isRotating=false;
        isDragOver = true;
    }
    private void DecideAfterTouchRotateSpeed()
    {

        if(speedOfRotation > 0 && speedOfRotation < 200){
            afterTouchRotateSpeed = 1f;
        }
        else if(speedOfRotation >= 200 && speedOfRotation < 400){
            afterTouchRotateSpeed = 200f;
        }
        else if(speedOfRotation >= 400 && speedOfRotation < 700){
            afterTouchRotateSpeed = 300f;
        }
        else if(speedOfRotation >= 700 && speedOfRotation < 1000){
            afterTouchRotateSpeed = 400f;
        }
        else if(speedOfRotation >= 1000 && speedOfRotation < 2000){
            afterTouchRotateSpeed = 500f;
        }
        else if(speedOfRotation >= 2000){
            afterTouchRotateSpeed = 550f;
        }

        StartCoroutine(AutoRotation());
        StartCoroutine(ResetPosition());
    }  

    IEnumerator ResetPosition(){

        StopCoroutine(AutoRotation());

        yield return new WaitForSeconds(rePossitionTime);

        initialRotation = new Quaternion(0, 180, 0, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, initialRotation, Time.deltaTime * lerpTime);
    }    

    IEnumerator AutoRotation(){

        isRotating = false;
        transform.Rotate(rotationValue * afterTouchRotateSpeed * Time.deltaTime );

        yield return new WaitForSeconds(1f);
        isRotating=true;
    }    

    public void RotatePlayer(){

        if(speedOfRotation > 0 && speedOfRotation < 200){
            speed = 100f;
        }
        else if(speedOfRotation >= 200 && speedOfRotation < 400){
            speed = 200f;
        }
        else if(speedOfRotation >= 400 && speedOfRotation < 700){
            speed = 250f;
        }
        else if(speedOfRotation >= 700 && speedOfRotation < 1000){
            speed = 300f;
        }
        else if(speedOfRotation >= 1000 && speedOfRotation < 2000){
            speed = 350f;
        }
        else if(speedOfRotation >= 2000){
            speed = 400f;
        }
        transform.Rotate(rotationValue * speed * Time.deltaTime);

    }
}
