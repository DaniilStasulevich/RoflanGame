using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rays : MonoBehaviour {

	#region vectors
	static Vector2 one = Vector2.one;
	Vector2[] ArrayOfVectors = new[] { one, one, one, one, one, one, one, one, one };
	#endregion

	//public GameObject CurrentEnemy;
	private SpriteRenderer sprite;
	private float originOffset = 0.5f;
	private float raycastMaxDistance = 10f;
	public int angle;
	private int _range;
	public int range;
	private GameObject Player;

	public static Rays operator -(Rays op) { Rays result = new Rays(); result.range = -op.range; return result; }

	void Start () {
		// Получем доступ к свойствам SpriteRender
		sprite = GetComponentInChildren<SpriteRenderer>();

		Player = GameObject.Find("Player");
		_range = -range;
	}

	void Update () {
		foreach (var direction in ArrayOfVectors)
			CheckRaycast(direction);

		if (this.gameObject.GetComponent<MoveTest>().Points[PreviousFlag()].tag == "Right")
		{
			sprite.flipX = false;
			range = Mathf.Abs(range);
			
		}
		else
		{
			sprite.flipX = true;
			range = _range;
		}

		CreateVectors();
	}

	private RaycastHit2D CheckRaycast(Vector2 direction)
	{
		// Хуй пойми что делает эта строчка, но как я понял она как то отвечает за позицию откуда будет выходить луч
		float directionOriginOffset = originOffset * (direction.x > 0 ? 1 : -1);
		// Позиция откуда выходят лучи
		Vector2 startingPosition = new Vector2(transform.position.x + directionOriginOffset, transform.position.y+1.5f);
		// Визуальная прорисовка лучей
		Debug.DrawRay(startingPosition, direction, Color.red);
		// Просто переменная 
		RaycastHit2D hit = Physics2D.Raycast(startingPosition, direction, raycastMaxDistance);
		// Чекаем не задел ли луч какой-либо объект
		if (hit.collider != null && hit.collider.tag == "Player")
		{
			Debug.DrawRay(startingPosition, direction, Color.yellow);
			for(int i=0;i< this.gameObject.GetComponent<MoveTest>().Points.objects.Length;i++)
				this.gameObject.GetComponent<MoveTest>().Points[i]=Player.transform;
			this.gameObject.GetComponent<AudioSource>().enabled = true;
			//Debug.Log("Вас заметили");
		}
		return Physics2D.Raycast(startingPosition, direction, raycastMaxDistance);
	}

	private void CreateVectors()
	{
		
		if (angle == 90)
		{
			ArrayOfVectors[0] = new Vector2(range, -2);
			ArrayOfVectors[1] = new Vector2(range, 0);
			ArrayOfVectors[2] = new Vector2(range, 2);
			ArrayOfVectors[3] = new Vector2(range, 1);
			ArrayOfVectors[4] = new Vector2(range, -1);
			ArrayOfVectors[5] = new Vector2(range, 3);
			ArrayOfVectors[6] = new Vector2(range, -3);
			ArrayOfVectors[7] = new Vector2(range, 4);
			ArrayOfVectors[8] = new Vector2(range, -4);
		}
		else if (angle == 60)
		{
			ArrayOfVectors[0] = new Vector2(range, -1);
			ArrayOfVectors[1] = new Vector2(range, 0);
			ArrayOfVectors[2] = new Vector2(range, 1);
			ArrayOfVectors[3] = new Vector2(range, 0);
			ArrayOfVectors[4] = new Vector2(range, -0);
			ArrayOfVectors[5] = new Vector2(range, 2);
			ArrayOfVectors[6] = new Vector2(range, -2);
			ArrayOfVectors[7] = new Vector2(range, 3);
			ArrayOfVectors[8] = new Vector2(range, -3);
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
