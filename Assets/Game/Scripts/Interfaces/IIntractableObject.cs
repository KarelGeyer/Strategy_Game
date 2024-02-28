using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IIntractableObject
{
	/// <summary>
	/// Defines Object behavior when player interacts with it
	/// </summary>
	protected virtual void OnInteract() { }
}
