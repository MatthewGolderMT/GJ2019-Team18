using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform camTransform;

	// How long the object should shake for.
	public float MaxShakeTime = 0.5f;
	private float _timeShaking = 0;
	private bool _isShaking = false;
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;

	Vector3 originalPos;

	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
		_timeShaking = 0;
	}

	void OnEnable()
	{
		originalPos = camTransform.localPosition;
		MechController.damageEvent += ShakeCamera;
	}

	private void OnDisable()
	{
		MechController.damageEvent -= ShakeCamera;

	}

	public void ShakeCamera()
	{
		_isShaking = true;
	}

	void Update()
	{
		if (_isShaking)
		{
			if (_timeShaking < MaxShakeTime)
			{
				camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
				_timeShaking += Time.deltaTime * decreaseFactor;
			}
			else
			{
				_isShaking = false;
				_timeShaking = 0;
			}
		}
		/*
		if (MaxShakeTime > 0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

			MaxShakeTime -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			MaxShakeTime = 0f;
			camTransform.localPosition = originalPos;
		}
		*/
	}
}