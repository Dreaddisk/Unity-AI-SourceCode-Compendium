using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slerping : MonoBehaviour
{
    #region Variables
    [SerializeField] private Transform goal;
    float speed = 0.5f;
    float accuracy = 1.0f;
    #endregion

    void LateUpdate()
    {
        Vector3 lookAtGoal = new Vector3(goal.position.x,
                                    this.transform.position.y,
                                    goal.position.z);
        this.transform.LookAt(lookAtGoal);
        if (Vector3.Distance(transform.position, lookAtGoal) > accuracy) ;
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
