﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class EnemyController : MonoBehaviour
{
    public LayerMask movementMask;

    Camera cam;
    PlayerMotor motor;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            MoveMinion("RedTeam");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            MoveMinion("BlueTeam");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            MoveMinion("GreenTeam");
        }
    }
    public void MoveMinion(string tag)
    {
        if (gameObject.tag == tag)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);
            }
        }
    }
}