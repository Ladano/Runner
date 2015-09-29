using UnityEngine;
using System.Collections;

namespace Com.Game
{
	public class PlayerController : MonoBehaviour
	{
		private const string PlayerAnimatorJumpTrigger = "Jump";

		[SerializeField] private Animator _playerAnimator;
		[SerializeField] private CharacterController _characterController;
		[SerializeField] private GameObject _playerCapsule;
		private int _currentPos = 0;

		private void Update()
		{
			InputMethod();
		}

		private void InputMethod()
		{
			if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
			{
				Move(-1);
			}
			if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
			{
				Move(1);
			}
			if(Input.GetKeyDown(KeyCode.Space))
			{
				Jump();
			}
		}

		private void Move(int direction)
		{
			int newPos = Mathf.Clamp(_currentPos + direction, -1, 1);
			if(newPos!=_currentPos)
			{
				_currentPos = newPos;
				transform.localPosition = new Vector3(1.2f * _currentPos, transform.localPosition.y, transform.localPosition.z);
				LeanTween.move(_playerCapsule, transform.position, 0.2f);
			}
		}

		private void Jump()
		{
			Debug.Log("isGrounded = " + _characterController.isGrounded);
			//if(_characterController.isGrounded)
			//{
				_playerAnimator.SetTrigger(PlayerAnimatorJumpTrigger);
			//}
		}

		private void OnControllerColliderHit(ControllerColliderHit hit)
		{
			switch(hit.collider.tag)
			{
			case Tags.GameObstacle:
				//TODO death
				hit.gameObject.SetActive(false);
				Debug.Log("death");
				break;
			case Tags.GameBonus:
				//TODO pick up bonus
				hit.gameObject.SetActive(false);
				Debug.Log("pick up");
				break;
			}
		}
	}
}
