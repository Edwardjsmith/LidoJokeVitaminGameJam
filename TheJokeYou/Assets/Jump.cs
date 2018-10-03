using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public AnimationClip jump;
    public AnimationClip crouch;
    public AnimationClip idle;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.position, Vector2.down, Color.red, 0.5f);
        if(Physics2D.Raycast(transform.position, Vector2.down, GetComponent<SpriteRenderer>().sprite.rect.height /2))
        {
            state = State.Idle;
            if (Input.GetButtonDown("Jump"))
            {
                JumpPower = 0;
            }

            if (Input.GetButton("Jump"))
            {
                JumpPower += 5 * Time.deltaTime;
                if(JumpPower > 13)
                {
                    JumpPower = 13;
                }
                state = State.Crouch;
            }
            if (Input.GetButtonUp("Jump"))
            {
                rigidbody.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            }
        }
        else
        {
            state = State.Jump;
        }

        GetComponent<Animator>().SetInteger("State", (int) state);
        print(GetComponent<SpriteRenderer>().sprite.rect.height / 2);
	}
}
