using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jump : MonoBehaviour {
    public enum State
        {
        Idle,
        Crouch,
        Jump
    }
    public float JumpPower;
    public State state;
    public Rigidbody2D rigidbody;
    public int layerMask;
    public bool canJump;
    public float maxJumpPower;
    public Slider powerBar;
    public float jumpSpeed;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        layerMask = 1 << 8;
        layerMask = ~layerMask;
        canJump = true;
        powerBar = GameObject.Find("PowerBar").GetComponent<Slider>();
        powerBar.maxValue = maxJumpPower;
	}
	
	// Update is called once per frame
	void Update () {

        if (canJump)
        {
            state = State.Idle;
            if (Input.GetButtonDown("Jump"))
            {
                JumpPower = 0;
            }

            if (Input.GetButton("Jump"))
            {
                JumpPower += jumpSpeed * Time.deltaTime;
                if(JumpPower > maxJumpPower)
                {
                    JumpPower = maxJumpPower;
                }
                state = State.Crouch;
            }
            if (Input.GetButtonUp("Jump"))
            {
                rigidbody.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
                JumpPower = 0;
                canJump = false;
            }
        }
        else
        {
            state = State.Jump;
        }

        GetComponent<Animator>().SetInteger("State", (int) state);
        powerBar.value = JumpPower;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Floor")
        {
            canJump = true;
        }
    }
}
