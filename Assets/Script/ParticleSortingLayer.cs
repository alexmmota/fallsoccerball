using UnityEngine;
using System.Collections;

public class ParticleSortingLayer : MonoBehaviour {

	void Start (){
		particleSystem.renderer.sortingOrder = 4;
	}
}
