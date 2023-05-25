using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Caught");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Caught");

        }
    }
}
/*
 * Prank List <Do any three of these to unlock escape conditions>
 * 
 * Steal Teacher's lunch -> Teacher's lounge -> Keep lunch on you to the exit
 * Pop all the basketballs -> Gym
 * Make a Half court shot -> Gym
 * Change your report card -> Principal's office
 * Start a food fight -> Cafeteria
 * Make the Teacher open the windows
 * Pull Fire Alarm -> Escape out front lobby
 * Mess with the thermostat
 * Erase escaping footage
 * Collect all the chewed erasers (Collect Quest -> Bonus)
 * 
 */

/*
 * Escape Conditions
 *
 * Release a Class Pet
 * Escape out the Gym (Do the Gym pranks)
 * Escape out the Front Lobby (Do one of each, Cafeteria, Classroom, Gym)
 * Escape out the Classroom Window (Release the class pet, Get Teacher to open the window, )
 *
 */

/*
 * Once you escape you get a score for how well you did
 * 
 * Silent: How much you were noticed
 * Time taken: Lower the better
 * Casualties: none prank targets harmed = deduction of score
 * 
 */

/*
 * 
 * Priority of Assets 
 * Room assets/Hallways Assets 1
 * Animation 
 * 
 */

/* Game Loop of stealth
 * 
 * Caught
 * teacher walks at you
 * teacher collides with you 
 * reset scene
 * A*
 * Else Make sure not to get Caught
 * 
 */