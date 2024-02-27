using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	[SerializeField]
	private Material m_interactionMaterial;

	private bool m_IsMarked;

	private void Update()
	{
		if (!UI_Manager.Instance.CanPlayerInteractWithUi && m_IsMarked)
		{
			OnMouseExit();
		}
	}

	private void OnMouseDown()
	{
		print(UI_Manager.Instance.CanPlayerInteractWithUi);
		if (UI_Manager.Instance.CanPlayerInteractWithUi)
			OnInteract();
	}

	private void OnMouseEnter()
	{
		if (!UI_Manager.Instance.CanPlayerInteractWithUi)
			return;

		AddMeshToRenderer(transform);
		if (transform.childCount != 0)
		{
			foreach (Transform child in transform)
				AddMeshToRenderer(child);
		}

		m_IsMarked = true;
	}

	private void OnMouseExit()
	{
		RemoveMeshFromRenderer(transform);
		if (transform.childCount != 0)
		{
			foreach (Transform child in transform)
				RemoveMeshFromRenderer(child);
		}

		m_IsMarked = false;
	}

	private void AddMeshToRenderer(Transform interactableObject)
	{
		MeshRenderer renderer = interactableObject.GetComponent<MeshRenderer>();
		if (renderer != null)
		{
			List<Material> materials = renderer.materials.ToList();
			materials.Add(m_interactionMaterial);

			renderer.SetMaterials(materials);
		}
	}

	private void RemoveMeshFromRenderer(Transform interactableObject)
	{
		MeshRenderer renderer = interactableObject.GetComponent<MeshRenderer>();
		if (renderer != null)
		{
			List<Material> materials = renderer.materials.ToList();
			for (int i = 0; i < materials.Count(); i++)
			{
				if (materials[i].name.Contains(Constants.INTERACTION))
					materials.RemoveAt(i);
			}

			renderer.SetMaterials(materials);
		}
	}

	protected virtual void OnInteract() { }
}
