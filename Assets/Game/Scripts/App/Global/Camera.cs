using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngineInternal;

public class Camera : MonoBehaviour
{
	[SerializeField]
	private float m_speed = 25f;

	[SerializeField]
	private float m_sprintSpeed = 60f;

	[SerializeField]
	private float m_scrollSpeed = 300f;

	[SerializeField]
	private float m_cameraMaxHeight = 80f;

	[SerializeField]
	private float m_cameraMinHeight = 30f;

	private float m_rotationY = 0f;
	private float m_currentSpeed = 0f;

	private void Start()
	{
		transform.position = new Vector3(transform.position.x, 40, transform.position.z);
	}

	// Update is called once per frame
	private void Update()
	{
		MoveCameraObject();
		ZoomCamera();
		RotateCamera();
		IncreaseSpeed();
	}

	private void MoveCameraObject()
	{
		float h_axis = Input.GetAxis(Constants.AXIS_HORIZONTAL);
		float v_axis = Input.GetAxis(Constants.AXIS_VERTICAL);

		Vector3 direction = new Vector3(h_axis, 0, v_axis);
		Vector3 velocity = direction.normalized * m_currentSpeed * Time.deltaTime;
		Vector3 move = transform.TransformDirection(velocity);
		transform.position += move;
	}

	private void ZoomCamera()
	{
		float mouseWheel = Input.mouseScrollDelta.y;
		bool shouldZoom = mouseWheel > 0 || mouseWheel < 0;
		bool isLowerThenMaxLimit = transform.position.y >= m_cameraMaxHeight && mouseWheel > 0;
		bool isHigherThenMinLimit = transform.position.y <= m_cameraMinHeight && mouseWheel < 0;
		bool isWithinLimits = transform.position.y <= m_cameraMaxHeight && transform.position.y >= m_cameraMinHeight;

		if (shouldZoom && (isLowerThenMaxLimit || isHigherThenMinLimit || isWithinLimits))
		{
			Vector3 newPosition = new(0, -mouseWheel, mouseWheel > 0 ? 1 : -1);
			transform.position += m_scrollSpeed * Time.deltaTime * newPosition;
		}
	}

	private void RotateCamera()
	{
		if (Input.GetMouseButton(1))
		{
			GameManager.Instance.SetCanInteract(false);
			m_rotationY += Input.GetAxis("Mouse X") * 1000f * Time.deltaTime;
			transform.localEulerAngles = new Vector3(transform.rotation.x, m_rotationY, transform.rotation.z);
		}
		else
		{
			GameManager.Instance.SetCanInteract(true);
		}
	}

	private void IncreaseSpeed()
	{
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			m_currentSpeed = m_sprintSpeed;
		}
		else
		{
			m_currentSpeed = m_speed;
		}
	}
}
