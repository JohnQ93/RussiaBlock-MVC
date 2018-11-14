using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	[HideInInspector]
	public Model model;
	[HideInInspector]
	public View view;

	private void Awake()
	{
		model = GameObject.FindGameObjectWithTag("Model").GetComponent<Model>();
		view = GameObject.FindGameObjectWithTag("View").GetComponent<View>();
	}

	// Update is called once per frame
	void Update () {

	}
}
