using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateAround : MonoBehaviour {

	public Transform target;
	public Vector3 offset;
	public float sensitivity = 1; // чувствительность
	public float limit = 80; // ограничение вращения по Y
	public float zoom = 0.25f; // чувствительность при увеличении, колесиком мышки
	public float zoomMax = 10; // макс. увеличение
	public float zoomMin = 3; // мин. увеличение
	private float X, Y;

	void Start () 
	{
		limit = Mathf.Abs(limit);
		if(limit > 90) limit = 90;
		offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax)/2);
		transform.position = target.position + offset;
	}
	
	public void RotateCameraPosition(Vector2 delta)
	{
		Y = Mathf.Clamp(Y, -limit, limit);
		X = transform.localEulerAngles.y + Mathf.Sign(delta.x) * sensitivity;
		Y += Mathf.Sign(delta.y) * sensitivity;
		transform.localEulerAngles = new Vector3(-Y, X, 0);
		transform.position = transform.localRotation * offset + target.position;
	}
}