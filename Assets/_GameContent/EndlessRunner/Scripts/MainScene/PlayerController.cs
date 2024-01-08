using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private MainGameUI mainGameUI;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;

    private int desiredLane = 1; //o:Left, 1:Center, 2:Right
    // public int laneChangeLerp = 50;
    public float laneDistance = 4; // Distance between two lanes

    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;

    public float jumpForce;
    public float gravity = -20;

    public Animator animator;
    public bool isSliding = false;
    AudioManager audioManager;
    public float score = 0;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    private void Update() {
        if(!PlayerManager.isGameStarted){
            return;
        }

        score += 10f * Time.deltaTime;
        mainGameUI.ShowScore((int)score);

        //Increase speed with time
        if(forwardSpeed < maxSpeed){
            forwardSpeed += 0.1f * Time.deltaTime;
        }
        animator.SetBool("isGameStarted", true);
        direction.z = forwardSpeed;

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        animator.SetBool("isGrounded",isGrounded);

        if(isGrounded){
            if(SwipeManager.swipeUp){
            // if(Input.GetKeyDown(KeyCode.UpArrow)){
                Jump();
            }
            if(SwipeManager.swipeDown && !isSliding){
                StartCoroutine(Slide());
            }
        }
        else{
            direction.y += gravity * Time.deltaTime; 
            if(SwipeManager.swipeDown && !isSliding){
                StartCoroutine(Slide());
                direction.y = -8;
            }
        }

        //Gather the inputs on which lane we should be
        if(SwipeManager.swipeRight){
        // if(Input.GetKeyDown(KeyCode.RightArrow)){
            desiredLane++;
            if(desiredLane == 3 ){
                desiredLane = 2;
            }
        }

        if(SwipeManager.swipeLeft){
        // if(Input.GetKeyDown(KeyCode.LeftArrow)){
            desiredLane--;
            if(desiredLane == -1 ){
                desiredLane = 0;
            }
        }

        //calculate where we should be in the future

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desiredLane == 0){
            targetPosition += Vector3.left * laneDistance;
        }
        else if(desiredLane == 2){
            targetPosition += Vector3.right * laneDistance;
        }

        // transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.deltaTime);
        // controller.center = controller.center;

        if(transform.position != targetPosition){
            Vector3 diff = targetPosition - transform.position;
            Vector3 movDir = diff.normalized * 25 * Time.deltaTime;
            if(movDir.sqrMagnitude < diff.sqrMagnitude){
                controller.Move(movDir);
            }
            else{
                controller.Move(diff);
            }
        }

        //Move player
        controller.Move(direction * Time.deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit hit){
        if(hit.transform.tag == "Obstacle"){
            playerManager.GameOver();
            audioManager.PlaySound("GameOver");
        }
    }

    private void FixedUpdate() {
        
        
    }

    private void Jump(){
        direction.y = jumpForce;
    }

    private IEnumerator Slide(){
        isSliding = true;

        animator.SetBool("isSliding",true);
        controller.center = new Vector3(0, -0.5f, 0f);
        controller.height = 1;

        yield return new WaitForSeconds(1.3f);

        
        controller.center = new Vector3(0, 0, 0);
        controller.height = 2;
        animator.SetBool("isSliding",false);

        isSliding = false;
    }
}
