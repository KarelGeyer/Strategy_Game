using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionSpawn : MonoBehaviour
{
	[SerializeField]
	private GameObject m_SpawnObject;

	private Material m_errorMaterial;
	private Material m_buildMaterial;

	private bool m_canBuild;

	private Dictionary<string, int> m_costList;

	private void Update()
	{
		ChooseConstructionPlace();
	}

	private void Start()
	{
		Destroy(GameObject.Find(Constants.GAME_OBJECT_CONSTRUCTION));
		m_errorMaterial = (Material)Resources.Load(Constants.ERROR_MESH_MATERIAL, typeof(Material));
		m_buildMaterial = (Material)Resources.Load(Constants.BUILD_MESH_MATERIAL, typeof(Material));

		GetComponent<MeshRenderer>().material = m_buildMaterial;
	}

	private void OnMouseDown()
	{
		Construct();
	}

	private void ChooseConstructionPlace()
	{
		UI_Manager.Instance.CanPlayerInteractWithUi = false;
		Vector3 mouse = Input.mousePosition;
		Ray castPoint = Camera.main.ScreenPointToRay(mouse);
		if (Physics.Raycast(castPoint, out RaycastHit hit, Mathf.Infinity))
		{
			transform.position = new Vector3(hit.point.x, 0, hit.point.z + 5);
			m_SpawnObject.transform.position = transform.position;
		}
	}

	private void OnCollisionStay(Collision collision)
	{
		if (collision.gameObject.name != Constants.GAME_OBJECT_TERRAIN)
		{
			m_canBuild = false;
			GetComponent<MeshRenderer>().material = m_errorMaterial;
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		m_canBuild = true;
		GetComponent<MeshRenderer>().material = m_buildMaterial;
	}

	private void Construct()
	{
		if (m_canBuild)
		{
			Instantiate(m_SpawnObject);
			Destroy(GameObject.Find(Constants.GAME_OBJECT_CONSTRUCTION_CLONE));
			Destroy(this);
			UI_Manager.Instance.GetConstructionUI().gameObject.SetActive(true);
		}
	}

	public void SetBuilding(Building newBuilding)
	{
		MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
		MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
		BoxCollider collider = gameObject.AddComponent<BoxCollider>();
		Rigidbody body = gameObject.AddComponent<Rigidbody>();

		if (newBuilding.name == Constants.GAME_OBJECT_MATERIALS_HOUSE)
		{
			meshRenderer.material = m_buildMaterial;
			meshFilter.mesh = newBuilding.GetComponentInChildren<MeshFilter>().sharedMesh;
			collider.size = newBuilding.GetComponentInChildren<BoxCollider>().size;
			collider.center = newBuilding.GetComponentInChildren<BoxCollider>().center;
		}
		else
		{
			meshRenderer.material = m_buildMaterial;
			meshFilter.mesh = newBuilding.GetComponent<MeshFilter>().sharedMesh;
			collider.size = newBuilding.GetComponent<BoxCollider>().size;
			collider.center = newBuilding.GetComponent<BoxCollider>().center;
		}

		body.freezeRotation = true;

		m_SpawnObject = newBuilding.gameObject;
	}
}
