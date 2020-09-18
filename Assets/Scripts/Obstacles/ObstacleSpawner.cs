using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

	[SerializeField] private GameObject[] obstacles;

	private List<GameObject> obstaclesForSpawing = new List<GameObject>();

	void Awake() {
		InitializeObstacles(); // initialize obstacles method will be called first ibn the awake method
		Shuffle();
	}

	void Start() {
		StartCoroutine(SpawnRandomObstacle()); // then after awake, run the coroutine
	}

	void InitializeObstacles() { //  This method will fill in the value or list item for obstaclesForSpawing
		int index = 0;
		for (int i = 0; i < obstacles.Length * 3; i++) { // multiply it by 3 so the game object will be added 3 times in the obstaclesForSpawing list
			GameObject obj = Instantiate(obstacles[index], new Vector3(transform.position.x,
																	   transform.position.y, -2), Quaternion.identity) as GameObject; //instantiate the object based on current transform and rotation
																																	  // Read More about it : https://docs.unity3d.com/ScriptReference/Object.Instantiate.html#:~:text=Instantiate%20can%20be%20used%20to,rigidbody%20then%20set%20the%20velocity
			obstaclesForSpawing.Add(obj); // add the gameobject to the List
			obstaclesForSpawing[i].SetActive(false); // set the game object to be not active, because it'll be active when it go towards the player (line 50)
			index++; // then increment the index
			if (index == obstacles.Length) { // in order to avoid array array index out of bounds exception we need to check it whether it's out of the index of the array length or not (well because we multiply the lopp with 3, so ofc it'll ot of index)
				index = 0; // set it back to 0
				// in case if you confuse so, the index of the List of obstaclesForSpawing will be 7*3 (why 7? well, because we only have 7 variety of obstacles) so when it reaches the end of the index of the Obstacles array it'll back and return to index 0, so this is what I mean by multiply it by 3 on line 21
			}
		}
	}

	void Shuffle() {
		for (int i = 0; i < obstaclesForSpawing.Count; i++) {
			GameObject temp = obstaclesForSpawing[i];
			int random = Random.Range(i, obstaclesForSpawing.Count);
			obstaclesForSpawing[i] = obstaclesForSpawing[random];
			obstaclesForSpawing[random] = temp;
		}
	}

	IEnumerator SpawnRandomObstacle() { // then after initialize the obstacles run the obstacles spawner to spawn the obstacles
		yield return new WaitForSeconds(Random.Range(1.5f, 4.5f)); // return for random range between 1.5f to 4.5f so the List items will be spawned in a random time (in case you wondering about how to simulate the random distance between the obstacles)

		int index = Random.Range(0, obstaclesForSpawing.Count);
		while (true) {
			if (!obstaclesForSpawing[index].activeInHierarchy) {
				obstaclesForSpawing[index].SetActive(true); // spawn the obstacle by set it to be active
				obstaclesForSpawing[index].transform.position = new Vector3(transform.position.x, transform.position.y, -2);
				break;
			} else {
				index = Random.Range(0, obstaclesForSpawing.Count);
			}
		}

		StartCoroutine(SpawnRandomObstacle());
	}

}
