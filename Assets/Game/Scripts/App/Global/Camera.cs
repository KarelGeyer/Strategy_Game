using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngineInternal;

public class MainCamera : MonoBehaviour
{
	[SerializeField]
	[Range(25, 30)]
	private float m_speed = 25f;

	[SerializeField]
	[Range(50, 70)]
	private float m_sprintSpeed = 60f;

	[SerializeField]
	[Range(300, 350)]
	private float m_scrollSpeed = 300f;

	[SerializeField]
	[Range(80, 150)]
	private float m_cameraMaxHeight = 80f;

	[SerializeField]
	[Range(25, 35)]
	private float m_cameraMinHeight = 30f;

	private float m_rotationY = 0f;
	private float m_currentSpeed = 0f;

	private void Start()
	{
		transform.position = new Vector3(transform.position.x, 40, transform.position.z);
	}

	private void Update()
	{
		MoveCameraObject();
		ZoomCamera();
		RotateCamera();
		IncreaseSpeed();
	}

	/// <summary>
	/// Moves camera holder on the horizontal and vertical axis
	/// </summary>
	private void MoveCameraObject()
	{
		float h_axis = Input.GetAxis(Constants.AXIS_HORIZONTAL);
		float v_axis = Input.GetAxis(Constants.AXIS_VERTICAL);

		Vector3 direction = new Vector3(h_axis, 0, v_axis);
		Vector3 velocity = direction.normalized * m_currentSpeed * Time.deltaTime;
		Vector3 move = transform.TransformDirection(velocity);
		transform.position += move;
	}

	/// <summary>
	/// Moves camera holder on the depth axis
	/// </summary>
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

	/// <summary>
	/// Allows to rotate camera and ban interaction for as long as camera is being rotated
	/// </summary>
	private void RotateCamera()
	{
		if (Input.GetMouseButton(1))
		{
			UI_Manager.Instance.CanPlayerInteractWithUi = false;
			m_rotationY += Input.GetAxis("Mouse X") * 1000f * Time.deltaTime;
			transform.localEulerAngles = new Vector3(transform.rotation.x, m_rotationY, transform.rotation.z);
		}

		if (Input.GetMouseButtonUp(1))
		{
			UI_Manager.Instance.CanPlayerInteractWithUi = true;
		}
	}

	/// <summary>
	/// Increases the speed for movement on horizontal and vertical axis when shift is held down
	/// </summary>
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
