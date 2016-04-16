using UnityEngine;
using System.Collections;
/*
    Author: Adil Hussain
    Date Created: 15th April 2016
    Description: Player Control, Movement and Animation     ||Audio to be added
    Last Modified: 15th April 2016
*/
[System.Serializable]
    public class VelocityRange
    {
        // Public Variables
        public float minimum;
        public float maximum;

        public VelocityRange(float minimum, float maximum)// Range for Player Speed
        {
            this.minimum = minimum;
            this.maximum = maximum;
        }
    }

public class PlayerController : MonoBehaviour {
    // Public Variables
    public GameController gameController;
    public VelocityRange velocityRange = new VelocityRange(300f, 1000f);
    public float moveForce = 50f;
    public float jumpForce = 500f;
    public Transform groundCheck;
    public Camera camera;

    // Private Variables
    private Animator _animator;
    private float _move;
    private float _jump;
    private bool _isFacingRight = true;
    private Transform _transform;
    private Rigidbody2D _rigidBody2D;
    private bool _isGrounded;

    // Use this for initialization
    void Start () {
        //initialize private variables
        this._rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        this._transform = gameObject.GetComponent<Transform>();
        this._animator = gameObject.GetComponent<Animator>();
        this._move = 0f;
        //set default animation state to 0
        this._animator.SetInteger("AnimState", 0);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this._isGrounded = Physics2D.Linecast(this._transform.position, this.groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        Debug.DrawLine(this._transform.position, this.groundCheck.position);

        float xForce = 0f;
        float yForce = 0f;

        //make sure that the camera is following the hero
        Vector3 currentPosition =
                new Vector3(this._transform.position.x, this._transform.position.y, -10f);
        this.camera.transform.position = currentPosition;

        //get absolute value of velocity for our gameObject
        float absVelX = Mathf.Abs(this._rigidBody2D.velocity.x);
        float absVelY = Mathf.Abs(this._rigidBody2D.velocity.y);

        //-1 -- 1 for Horizontal and Vertical Axis
        this._move = Input.GetAxis("Horizontal");
        this._jump = Input.GetAxis("Vertical");

        if (this._isGrounded)
        {
            Debug.Log("Grounded");
            if (this._move != 0)
            {
                if (this._move > 0)
                {
                    //movement
                    if (absVelX < this.velocityRange.maximum)
                    {
                        xForce = this.moveForce;
                    }
                    this._isFacingRight = true;
                    this._flip();
                }
                if (this._move < 0)
                {
                    //movement
                    if (absVelX < this.velocityRange.maximum)
                    {
                        xForce = -this.moveForce;
                    }
                    this._isFacingRight = false;
                    this._flip();
                }
                //change animation to walk when moving ie. AnimState = 1
                this._animator.SetInteger("AnimState", 1);
            }
            else
            {
                // Animation on Idle ie. AnimState = 0
                this._animator.SetInteger("AnimState", 0);
                this._rigidBody2D.velocity = new Vector2(0, 0);

            }
            if (this._jump > 0)
            {
                //jumping
                if (absVelY < this.velocityRange.maximum)
                {
                    yForce = this.jumpForce;
                }
            }
        }
        else
        {
            //change animation to jump when _jump is positive
            this._animator.SetInteger("AnimState", 2);
        }
        this._rigidBody2D.AddForce(new Vector2(xForce, yForce));
        
    }

    // Private Methods
    private void _flip() // To flip Player Sprite
    {
        if (this._isFacingRight)
        {
            this._transform.localScale = new Vector2(1, 1);
        }
        else
        {
            this._transform.localScale = new Vector2(-1, 1);
        }
    }

    void OnCollisionEnter2D(Collision2D other) // Player Takes Damage on Hit from Enemies
    {
        Debug.Log("Hit");
        if (other.gameObject.CompareTag("Enemy"))
        {
            //gameController.damage(1);
        }

    }
}
