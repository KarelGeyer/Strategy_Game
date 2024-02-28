using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Interactable : MonoBehaviour, IIntractableObject
{
	[SerializeField]
	[Tooltip("Material used as an interaction overlay over default objects default material")]
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

	/// <summary>
	/// Adds interactable mesh to mesh renderer list of meshes to create interaction layer
	/// </summary>
	/// <param name="interactableObject"><see cref="this"/></param>
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

	/// <summary>
	/// Oposite of <see cref="AddMeshToRenderer"/>
	/// </summary>
	/// <param name="interactableObject"><see cref="this"/></param>
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
