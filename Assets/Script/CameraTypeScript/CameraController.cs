using UnityEngine;
using System.Collections;



public class CameraController : MonoBehaviour
{

	
	public Transform target;
	public float targetHeight = 1;
	public float distance = 3;
	public float maxDistance = 10;
	public float minDistance = 0.5f;
	public float xSpeed = 200;
	public float ySpeed = 120;
	public float yMinLimit = -50;
	public float yMaxLimit = 60;
	public float zoomRate = 50;
	public float rotationDampening = 15;
	private float x = 0f;
	private float y = 0f;
	
	//    bool isTalking = false;
	public float count;
	
	void Start()
	{
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
		var mousePos = Input.mousePosition;
		mousePos.x -= Screen.width / 2;
		mousePos.y -= Screen.height / 2;

		Cursor.lockState = CursorLockMode.Locked;

	}

	// Update is called once per frame
	void Update()
	{

	}
	void LateUpdate()
	{
		if (!target)
		{
			return;
		}

		
		x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
		y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
		

		distance -= (Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime) * zoomRate * Mathf.Abs(distance);
		distance = Mathf.Clamp(distance, minDistance, maxDistance);

		y = ClampAngle(y, yMinLimit, yMaxLimit);

		//Rotate Camera
		Quaternion rotation = Quaternion.Euler(y, x, 0);
		transform.rotation = rotation;
	


		//Position Camera
		var position = target.position - (rotation * Vector3.forward * distance + new Vector3(0, -targetHeight, 0));
		transform.position = position;

		//Is view blocked?
		RaycastHit hit;
		Vector3 trueTargetPosition = target.transform.position - new Vector3(0, -targetHeight, 0);

		
		// make sure its not colliding with the original target
		if (Physics.Linecast(trueTargetPosition, transform.position, out hit) && hit.transform != target)
		{
			count += Time.deltaTime;

			//If so, shorten distance so camera is in front of object:
			if (count > 0.9)
			{
				var tempDistance = Vector3.Distance(trueTargetPosition, hit.point) - 0.28f;

				// Finally reposition the camera:
				position = target.position - (rotation * Vector3.forward * tempDistance + new Vector3(0, -targetHeight, 0));
				transform.position = position;
			}
		}
		else
		{
			count = 0;
		}

	}

	static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360)
		{
			angle += 360;
		}
		if (angle > 360)
		{
			angle -= 360;
		}
		return Mathf.Clamp(angle, min, max);
	}

}
