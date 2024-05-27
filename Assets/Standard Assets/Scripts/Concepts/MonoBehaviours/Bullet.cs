using UnityEngine;

namespace FightRoom
{
	public class Bullet : MonoBehaviour
	{
		public float moveSpeed = 5.0f;
		// public Transform trs;
	
		void Update ()
		{
			transform.position = transform.position + transform.up * moveSpeed * Time.deltaTime;
		}
	}
}