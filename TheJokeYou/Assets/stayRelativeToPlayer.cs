using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stayRelativeToPlayer : MonoBehaviour {

    Vector3 playerPos;

	// Use this for initialization
	void Start ()
    {
        playerPos = GameObject.Find("Player").transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
		MeshRenderer mesh = GetComponent<MeshRenderer>();
        Material material = mesh.material;
        Vector2 materialOffset = material.mainTextureOffset;

        transform.position = playerPos + new Vector3(0, 4.39f, 0);

        materialOffset.x = transform.position.x / transform.localScale.x;
        materialOffset.y = transform.position.y / transform.localScale.y;
        material.mainTextureOffset = materialOffset;
	}
}
