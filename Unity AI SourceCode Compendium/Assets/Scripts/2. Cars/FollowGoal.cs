using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGoal : MonoBehaviour
{
    #region variables
    // object that is the goal of the player to follow.
    public Transform goal;

    /// <summary>
    /// speed, accuracy and rotation speed for the
    /// player to.
    /// </summary>
    private float speed = 2.0f;
    private float accuracy = 1.0f;
    private float rotSpeed = 1.0f;
    #endregion


    private void LateUpdate()
    {

        Vector3 lookAtGoal = new Vector3(goal.position.x,
            this.transform.position.y,
            goal.position.z);

        Vector3 direction = lookAtGoal - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
            Quaternion.LookRotation(direction),
            Time.deltaTime * rotSpeed);

        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }

} // FollowGoal class
