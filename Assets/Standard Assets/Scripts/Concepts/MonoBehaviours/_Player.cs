using UnityEngine;
using UnityEngine.InputSystem;

namespace FightRoom
{
	public class _Player : MonoBehaviour
	{
		public float moveSpeed = 5.0f;
		public float reloadSpeed = 0.0f;
		float shootTimer = 0.0f;

		void Start ()
		{
			print("Hello World!");
			// _Test ();
		}

		// void _Test ()
		// {
		// 	print("Hi!");
		// }

		void Update ()
		{
			// _Test ();
			Vector3 move = Vector3.zero;
			if (Keyboard.current.aKey.isPressed)
				move.x -= 1.0f;
			if (Keyboard.current.dKey.isPressed)
				move.x += 1.0f;
			if (Keyboard.current.sKey.isPressed)
				move.y -= 1.0f;
			if (Keyboard.current.wKey.isPressed)
				move.y += 1.0f;
			move.Normalize();
			Vector3 position = transform.position;
			position += move * moveSpeed * Time.deltaTime;
			transform.position = position;
			Vector3 mousePosition = Mouse.current.position.ReadValue();
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			Vector3 facing = mousePosition - position;
			transform.eulerAngles = Vector3.forward * (Mathf.Atan2(facing.y, facing.x) * 57.2958f - 90.0f);
			if (shootTimer > 0.0f)
				shootTimer -= Time.deltaTime;
			if (shootTimer <= 0.0f && Mouse.current.leftButton.isPressed)
			{
				shootTimer += 1.0f / reloadSpeed;
			}
		}
	}
}