using UnityEngine;
using System.Collections;

public class DemoUI : MonoBehaviour {

	bool cursorlock = true;
	void LateUpdate () {// Creating the Cursor on Screen for the Player to navigate
		if (cursorlock)
			Cursor.lockState = CursorLockMode.Locked;
		else
			Cursor.lockState = CursorLockMode.None;

		if (Input.GetKeyDown(KeyCode.Escape))
			cursorlock = !cursorlock;
	}
}
