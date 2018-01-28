using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetector : MonoBehaviour {

	void OnTriggerEnter(Collider direction)
    {
		Debug.Log("Collision made! = " + direction.tag);
        TileLogic.connections[direction.tag] += 1;

        // turn off trigger to avoid redundant detection
        direction.isTrigger = false;
    }
}
