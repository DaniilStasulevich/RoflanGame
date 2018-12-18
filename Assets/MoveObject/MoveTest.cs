using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour {
	#region private fields
	// Текущая точка маршрута
	internal  int _currentPoint;
	private bool Waiting = false;
	#endregion

	#region public fields
	//public Transform[] Points;
	public Points Points;
	private Transform[] TempBack;
	private Transform[] TempFoward;
	// Скорость и дистанция
	public float Speed = 0.0f, Distance = 0.0f;

	void Start()
	{
		int j = 0;
		TempBack= new Transform[Points.objects.Length];
		TempFoward = new Transform[Points.objects.Length];
		for(int i=Points.objects.Length-1;i>=0;i--)
		{
			TempBack[j] = Points[i];
			j++;
		}
		for (int i=0;i<=Points.objects.Length-1;i++)
		{
			TempFoward[i] = Points[i];
		}

	}
	#endregion
	void Update()
	{
			if (_currentPoint == Points.objects.Length)
			{
				for(int i=0;i<Points.objects.Length;i++)
				{
					Points[i] = TempBack[i];
				}
				_currentPoint = 0;
				
				
			}
			else if(_currentPoint==0)
			{
				for (int i = 0; i < Points.objects.Length; i++)
				{
				Points[i] = TempFoward[i];

				}
			}

			float _currentDistance = Vector3.Distance(transform.position, Points[_currentPoint].position);

			if (_currentDistance <= Distance)
			{
				if (Points[_currentPoint].tag == "Wait" )
				{
					if (!Waiting)
					{
					StartCoroutine(stop());
					Waiting = true;
					}
				}
				else
					_currentPoint++;
			}

		Vector3 directionToPoint = Points[_currentPoint].position - transform.position;

			//transform.up = Vector3.RotateTowards(transform.up, directionToPoint, Speed * Time.deltaTime, 0.0f);
			
			transform.position = Vector3.MoveTowards(transform.position, Points[_currentPoint].position, Speed * Time.deltaTime);
	}

	public IEnumerator stop()
	{
		yield return new WaitForSeconds(4);
		Waiting = false;
		_currentPoint++;
	}
}
[System.Serializable]
public  class Points
{
	public  Transform[] objects;

	[HideInInspector]
	public int Length;

	public Points(int Size)
	{
		objects = new Transform[Size];
		Length = Size;
	}

	public Transform this[int index]
	{
		set
		{

			objects[index] = value;


		}

		get
		{
			if (index ==objects.Length)
				return objects[index - 1];
			else return objects[index];

		}
	}
}