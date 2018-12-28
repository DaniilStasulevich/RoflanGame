// Данный скрипт представляет собой систему поле видимости противника.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rays : MonoBehaviour {

	// Количество лучей
	[SerializeField]
	[Range(1,90)]
	public int numberOfRays;
	
	// Угол падения лучей
	[SerializeField]
	[Range(-360, 360)]
	public float lightAngle = -90;

	// Расстояние между лучами
	[SerializeField]
	[Range(0, 360)]
	public float lightCone = 90;

	private SpriteRenderer sprite;

	private float originOffset = 0.5f;

	public float raycastMaxDistance = 10f;

	[SerializeField]
	public float lightSourceSize = 0;


	private GameObject Player;
	// Перегружаем унарный оператор - 
	//public static Rays operator -(Rays op) { Rays result = new Rays(); result.range = -op.range; return result; }

	void Start () {

		

			// Получем доступ к свойствам SpriteRender
			sprite = GetComponentInChildren<SpriteRenderer>();
		Player = GameObject.Find("Player");
		// Используем перегруженный унарный оператор
	}

	void Update () {
		//foreach (var direction in ArrayOfVectors)
		//	CheckRaycast(direction);

		if (this.gameObject.GetComponent<MoveTest>().Points[PreviousFlag()].tag == "Right")
		{
			sprite.flipX = false;
			lightAngle = 0;

		}
		else if(this.gameObject.GetComponent<MoveTest>().Points[PreviousFlag()].tag == "Left")
		{
			sprite.flipX = true;
			lightAngle = -180;
		
		}
		else if (this.gameObject.GetComponent<MoveTest>().Points[PreviousFlag()].tag == "Up")
		{
			lightAngle = 90;
		
		}
		else if (this.gameObject.GetComponent<MoveTest>().Points[PreviousFlag()].tag == "Down")
		{

			lightAngle = -90;
		}
		CreateVectors();
	}

	//////////оставлю это здесь на всякий случай P.S старая система лучей///////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////

	//private RaycastHit2D CheckRaycast(Vector2 direction)
	//{
	//	// Хуй пойми что делает эта строчка, но как я понял она как то отвечает за позицию откуда будет выходить луч
	//	float directionOriginOffset = originOffset * (direction.x > 0 ? 1 : -1);
	//	// Позиция откуда выходят лучи
	//	Vector2 startingPosition = new Vector2(transform.position.x + directionOriginOffset, transform.position.y+1.5f);
	//	// Визуальная прорисовка лучей
	//	//Debug.DrawRay(startingPosition, direction, Color.red);
	//	// Просто переменная 
	//	RaycastHit2D hit = Physics2D.Raycast(startingPosition, direction, raycastMaxDistance);
	//	// Чекаем не задел ли луч какой-либо объект
	//	if (hit.collider != null && hit.collider.tag == "Player")
	//	{
	//		Debug.DrawRay(startingPosition, direction, Color.yellow);
	//		for(int i=0;i< this.gameObject.GetComponent<MoveTest>().Points.objects.Length;i++)
	//			this.gameObject.GetComponent<MoveTest>().Points[i]=Player.transform;
	//		this.gameObject.GetComponent<AudioSource>().enabled = true;
	//		//Debug.Log("Вас заметили");
	//	}
	//	return Physics2D.Raycast(startingPosition, direction, raycastMaxDistance);
	//}

	private void CreateVectors()
	{
		float RaySpacing = lightCone / numberOfRays;
		float initialAngle = lightAngle - (lightCone / 2);

		Vector3 initialLocation = transform.position + (new Vector3(Mathf.Cos(Mathf.Deg2Rad * (lightAngle - 90)), Mathf.Sin(Mathf.Deg2Rad * (lightAngle - 90))) * lightSourceSize / 2);
		Vector3 locationOffset = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (lightAngle - 90)), Mathf.Sin(Mathf.Deg2Rad * (lightAngle - 90))) * lightSourceSize / numberOfRays;

		for (int i = 0; i < numberOfRays; i++)
		{
			Vector3 origin = initialLocation - (locationOffset * i);
			Vector3 direction = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (i * RaySpacing + initialAngle)) * raycastMaxDistance, Mathf.Sin(Mathf.Deg2Rad * (i * RaySpacing + initialAngle)) * raycastMaxDistance);
			RaycastHit2D hit = Physics2D.Raycast(origin, direction, raycastMaxDistance);
			if (hit)
			{
				Debug.DrawRay(origin, (direction * hit.distance / raycastMaxDistance),Color.yellow);
			}
			else
			{
				Debug.DrawRay(origin, direction,Color.red);
			}
			//ArrayOfVectors[i] = new Vector2(range, i +1);
			//	ArrayOfVectors[i + numberOfRays /2] = new Vector2(range, -i);
		}

	}
	public int PreviousFlag()
	{
		if (this.gameObject.GetComponent<MoveTest>()._currentPoint == 0)
			return this.gameObject.GetComponent<MoveTest>().Points.objects.Length - 1;
		else
			return this.gameObject.GetComponent<MoveTest>()._currentPoint - 1;
	}
}
