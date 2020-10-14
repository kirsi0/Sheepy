using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class switch_scenes : MonoBehaviour {
	
	public string sceneName = "";

	// Use this for initialization
	void Start () {
		Button b = GetComponent<Button> ();
		if (b != null && sceneName != "")
		{
#pragma warning disable CS0618 // Type or member is obsolete
			b.onClick.AddListener(call: () => {Application.LoadLevel(sceneName);});
#pragma warning restore CS0618 // Type or member is obsolete
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
