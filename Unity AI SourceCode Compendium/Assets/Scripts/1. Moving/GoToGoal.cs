using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToGoal : MonoBehaviour
{
    public float speed = 2.0f;  // Speed of the Character
    public float accuracy = 0.01f;  // 
    public Transform goal;  // Game Object that the character will pursue.

    void LateUpdate()
    {
        this.transform.LookAt(goal.position);
        Vector3 direction = goal.position - this.transform.position; // Substract the distance of the character 
                                                                     //with the distance of the goal Game Object
        
        // Draws a Ray that makes the programmer see the direction traveled.
        Debug.DrawRay(this.transform.position, direction, Color.red);
        

        if(direction.magnitude > accuracy)
        {
            this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
    }
}
