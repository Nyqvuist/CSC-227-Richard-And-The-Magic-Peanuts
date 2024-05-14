//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;

//public class PlayerController : MonoBehaviour
//{

//    public float speed;
//    public Rigidbody2D rb;
//    public float jumpForce;
//    public bool jump;
//    private bool facingRight;
//    private bool isWalking;
//    public Transform groundCheck;
//    private Animator anim;
//    public LayerMask groundLayers;
//    public bool isGrounded;

//    private float horizontalMotion, verticalMotion;

//    public static Action<float> OnUpgradeApply;

//    private void OnEnable()
//    {

//        OnUpgradeApply += upgradeApply;
//    }

//    private void OnDisable()
//    {

//        OnUpgradeApply -= upgradeApply;
//    }


//    // Use this for initialization
//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        jump = false;
//        facingRight = true;
//        anim = GetComponent<Animator>();

//        DontDestroyOnLoad(this.gameObject);
//    }

//    // Update is called once per frame - used for button/key presses
//    void Update()
//    {
//        horizontalMotion = Input.GetAxis("Horizontal");    //get the horizontal motion, if any
//        verticalMotion = Input.GetAxis("Vertical");        //get the vertical motion, if any
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            jump = true;
//        }
//    }

//    void FixedUpdate()
//    {
//        if (jump && isGrounded)   //space is pressed and the player isn't already jumping and the player is grounded
//        {
//            anim.SetBool("IsGrounded", false);
//            rb.AddForce(new Vector2(0, jumpForce));
//            //add the force to have the player jump            
//        }
//        else if (!isGrounded)
//        {
//            jump = false;
//            anim.SetBool("IsGrounded", true);
//        }
//        if (horizontalMotion > 0f || horizontalMotion < 0f)  //if the player is walking
//        {
//            anim.SetBool("isIdle", false);       //control the animation - change the boolean in the animator
//        }
//        else
//        {
//            anim.SetBool("isIdle", true);
//        }
//        //the following is for flipping the player sprite so it is always facing the right direction
//        if (horizontalMotion < 0 && facingRight) //need to change direction
//        {
//            Flip();
//        }
//        else if (horizontalMotion > 0 && !facingRight)
//        {
//            Flip();
//        }
//        Vector3 motion = new Vector3(speed * horizontalMotion * Time.deltaTime, 0, 0); //standard for vector motion (this is only for x axis)
//        this.transform.position = this.transform.position + motion;
//        isGrounded = Physics2D.OverlapCircle(groundCheck.position, .05f, groundLayers);
//    }

//    void Flip()
//    {
//        facingRight = !facingRight;
//        Vector3 playerScale = this.transform.localScale;
//        playerScale.x *= -1;
//        this.transform.localScale = playerScale;
//    }

//    // Power up code goes here to change player stats.
//    void upgradeApply(float f) {

//        switch (f) {

//            case 1:
//                Debug.Log(f);
//                break;
//            case 2:
//                Debug.Log(f);
//                break;
//            case 3:
//                Debug.Log(f);
//                break;
//            case 4:
//                Debug.Log(f);
//                break;
//            case 5:
//                Debug.Log(f);
//                break;
//            case 6:
//                Debug.Log(f);
//                break;
//            case 7:
//                Debug.Log(f);
//                break;
//            case 8:
//                Debug.Log(f);
//                break;
//            case 9:
//                Debug.Log(f);
//                break;
//            case 10:
//                Debug.Log(f);
//                break;
//            default:
//                Debug.Log("Nothing Happens");
//                break;

//        }

//    }

//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;
    public float jumpForce;
    public bool jump;
    private bool facingRight;
    private bool isWalking;
    public Transform groundCheck;
    private Animator anim;
    public LayerMask groundLayers;
    public bool isGrounded;

    private float horizontalMotion, verticalMotion;

    public static Action<float> OnUpgradeApply;

    private void OnEnable()
    {

        OnUpgradeApply += upgradeApply;
    }

    private void OnDisable()
    {

        OnUpgradeApply -= upgradeApply;
    }


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = false;
        facingRight = true;
        anim = GetComponent<Animator>();

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame - used for button/key presses
    void Update()
    {
        horizontalMotion = Input.GetAxis("Horizontal");    //get the horizontal motion, if any
        verticalMotion = Input.GetAxis("Vertical");        //get the vertical motion, if any
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetTrigger("Throwing");
        }
    }

    void FixedUpdate()
    {
        if (jump && isGrounded)   //space is pressed and the player isn't already jumping and the player is grounded
        {
            anim.SetBool("IsGrounded", false);
            rb.AddForce(new Vector2(0, jumpForce));
            //add the force to have the player jump            
        }
        else if (!isGrounded)
        {
            jump = false;
            anim.SetBool("IsGrounded", true);
        }

        // Update walking animation
        if (Mathf.Abs(horizontalMotion) > 0f) //if the player is walking
        {
            anim.SetBool("isIdle", false);       //control the animation - change the boolean in the animator
        }
        else
        {
            anim.SetBool("isIdle", true);
        }

        // Update running animation
        if (Mathf.Abs(horizontalMotion) > 0f) //if the player is moving
        {
            anim.SetBool("isRunning", true);       //control the animation - change the boolean in the animator
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        //the following is for flipping the player sprite so it is always facing the right direction
        if (horizontalMotion < 0 && facingRight) //need to change direction
        {
            Flip();
        }
        else if (horizontalMotion > 0 && !facingRight)
        {
            Flip();
        }
        Vector3 motion = new Vector3(speed * horizontalMotion * Time.deltaTime, 0, 0); //standard for vector motion (this is only for x axis)
        this.transform.position = this.transform.position + motion;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, .05f, groundLayers);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 playerScale = this.transform.localScale;
        playerScale.x *= -1;
        this.transform.localScale = playerScale;
    }

    void TriggerThrow() {

        BulletSpawner.OnThrow();
    }

    // Power up code goes here to change player stats.
    void upgradeApply(float f)
    {

        switch (f)
        {

            case 1:
                speed *= 1.2f;
                break;
            case 2:
                speed /= 1.2f;
                break;
            case 3:
                jumpForce *= 1.2f;
                break;
            /*case 4:
                Debug.Log(f);
                break;
            case 5:
                Debug.Log(f);
                break;
            case 6:
                Debug.Log(f);
                break;
            case 7:
                Debug.Log(f);
                break;
            case 8:
                Debug.Log(f);
                break;
            case 9:
                Debug.Log(f);
                break;
            case 10:
                Debug.Log(f);
                break;*/
            default:
                Debug.Log("Nothing Happens");
                break;

        }

    }

}
