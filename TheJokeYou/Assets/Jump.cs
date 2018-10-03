using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    public float JumpPower;

    public Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if(Physics2D.Raycast(transform.position, Vector2.down, 1))
        {
            if (Input.GetButtonDown("Jump"))
            {
                JumpPower = 0;
            }

            if (Input.GetButton("Jump"))
            {
                JumpPower += 1 * Time.deltaTime;
                Mathf.Clamp(JumpPower, 0, 15);
            }

            if (Input.GetButtonUp("Jump"))
            {
                rigidbody.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            }
        }
	}
}
