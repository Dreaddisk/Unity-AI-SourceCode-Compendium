using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleAICar : MonoBehaviour
{

    #region Varaibles
    public Transform goal;
    public Text readout;

    public float rotSpeed = 1.0f;

    private float acceleration = 5f;
    private float deceleration = 5f;
    private float minSpeed = 0.0f;
    private float maxSpeed = 100.0f;
    private float brakeAngle = 20.0f;

    float speed = 0;


    #endregion

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 lookAtGoal = new Vector3(goal.position.x,
                                        this.transform.position.y,
                                        goal.position.z);
        Vector3 direction = lookAtGoal - this.transform.position;

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                Quaternion.LookRotation(direction),
                                                Time.deltaTime * rotSpeed);

      //  speed = Mathf.Clamp(speed + (acceleration * Time.deltaTime), minSpeed, maxSpeed);

        if(Vector3.Angle(goal.forward, this.transform.forward) > brakeAngle)
        {
            speed = Mathf.Clamp(speed - (deceleration * Time.deltaTime), minSpeed, maxSpeed);
        }
        else
        {
            speed = Mathf.Clamp(speed + (acceleration * Time.deltaTime), minSpeed, maxSpeed);
        }

        this.transform.Translate(0, 0, speed * Time.deltaTime);
        AnalogueSpeedConverter.ShowSpeed(speed, 0, 100);
        readout.text = "" + speed;
    }
}
