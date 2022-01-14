using UnityEngine;
using System.Collections;

public class MouseLockCursor : MonoBehaviour
{
	public bool isCursorLock = true;

	void Start ()
	{
		LockCursor (isCursorLock);
	}
	
	void Update()
	{
		if(Input.GetButtonDown("Cancel"))
		{
			LockCursor (false);
		}
		if(Input.GetButtonDown("Fire1"))
		{
			LockCursor (true);
		}
	}

	// Function for locking the cursor
	private void LockCursor(bool isLocked)
	{
		if (isLocked) 
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
		else
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
