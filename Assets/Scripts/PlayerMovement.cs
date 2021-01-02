using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Vector3 pos;
	public float speed;

    void Update()
    {
		if (Input.GetMouseButton(0))
		{
			pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}

		if (Input.touchCount > 0)
		{
			pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
		}
		pos.z = 0;
		pos.y = transform.position.y;
		transform.position = Vector3.Lerp(transform.position, pos, speed);
    }
}
