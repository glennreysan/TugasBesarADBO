using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

	int numBGPanels = 2;

	float treeMax = 0.8430938f;
	float treeMin = -0.003243029f;

	void Start() {
		GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");

		foreach(GameObject Tree in trees) {
			Vector3 pos = Tree.transform.position;
			pos.y = Random.Range(treeMin, treeMax);
			Tree.transform.position = pos;
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log ("Triggered: " + collider.name);

		float widthOfBGObject = ((BoxCollider2D)collider).size.x;

		Vector3 pos = collider.transform.position;

		pos.x += widthOfBGObject * numBGPanels;

		if(collider.tag == "Tree") {
			pos.y = Random.Range(treeMin, treeMax);
		}

		collider.transform.position = pos;

	}
}
