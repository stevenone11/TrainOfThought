﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrap : MonoBehaviour {

    public float distance = 1.0f;
    public float directionX = 0.0f;
    public float directionY = 0.0f;
    public Object spawn;
    public bool once = false;

    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Detect())
        {
            Instantiate(spawn);
            if (once == true)
            {
                this.enabled = false;
            }
        }
	}

    public bool Detect()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, new Vector2(directionX, directionY), distance);
        if (hitInfo.collider != null) //if the ray hits, do the following
        {
            Debug.DrawLine(transform.position, transform.position + new Vector3(directionX, directionY, 0) * distance, Color.red);
            return true;
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + new Vector3(directionX, directionY, 0) * distance, Color.green);
            return false;
        }
    }
}
