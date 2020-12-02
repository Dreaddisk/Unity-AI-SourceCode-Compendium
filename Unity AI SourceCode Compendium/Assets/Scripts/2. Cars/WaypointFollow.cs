using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollow : MonoBehaviour
{
    #region Variables
    // WaypointCircuit class powered by the Utility class of the Unity Standard Assets.
    public UnityStandardAssets.Utility.WaypointCircuit circuit;

    private int currentWP = 0;

    private float speed = 3.00f;
    private float accuracy = 1.0f;
    private float rotSpeed = 1.0f;

    #endregion

    private void LateUpdate()
    {
        if (circuit.Waypoints.Length == 0) return;

        Vector3 lookAtGoal = new Vector3(circuit.Waypoints[currentWP].position.x,
            this.transform.position.y,
            circuit.Waypoints[currentWP].position.z);

        Vector3 direction = lookAtGoal - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
            Quaternion.LookRotation(direction),
            Time.deltaTime * rotSpeed);

        if(direction.magnitude < accuracy)
        {
            currentWP++;
            if(currentWP >= circuit.Waypoints.Length)
            {
                currentWP = 0;
            }
        }

        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
