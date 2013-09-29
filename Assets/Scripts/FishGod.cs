using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FishGod : MonoBehaviour {
	
	public Fish fishBlueprint;
	public Fish mantaBlueprint;
	public float fishToMantaRatio;
	
	public int count;
	
	List<Fish> mortals;
	

	// Use this for initialization
	void Start () {
		mortals = new List<Fish>();
		mortals.Add(fishBlueprint);
		mortals.Add(mantaBlueprint);
		
		int total = 0;
		while (total < count) {
			++total;
			
			Vector3 fishPosition = Random.insideUnitSphere * 10f;
			
			if (Random.Range(0f, 1f) > fishToMantaRatio)
				mortals.Add(Instantiate(mantaBlueprint, fishPosition, Quaternion.identity) as Fish);
			else
				mortals.Add(Instantiate(fishBlueprint, fishPosition, Quaternion.identity) as Fish);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			foreach (Fish f in mortals)
				f.destination = Vector3.zero;
		}
	}
}
