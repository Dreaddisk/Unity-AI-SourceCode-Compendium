// In this script, we are going to create a file that makes the player 
// move towards a respective object, and if the object changes its position
// the player will update the trajecotry to the new object position.

using UnityEngine;

public class MovePosition : MonoBehaviour
{
    #region Variables
    public Transform goal;  // Goal Object
    float speed = 0.5f;     // Speed of player movement.
    float accuracy = 1.0f;  // 
    #endregion

    void LateUpdate()
    {
        Vector3 lookAtGoal = new Vector3(goal.position.x,   // Updates the x coordiante position.
                                        this.transform.position.y,  // We are not going to update the y position.
                                        goal.position.z);   // Updates the z coordiante position.
        this.transform.LookAt(lookAtGoal);

        if (Vector3.Distance(transform.position, lookAtGoal) > accuracy)
            this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
