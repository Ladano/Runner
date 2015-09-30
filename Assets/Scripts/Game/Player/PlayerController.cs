using UnityEngine;
using System.Collections;

namespace Com.Game
{
	public class PlayerController : MonoBehaviour
	{
		private const string PlayerAnimatorJumpTrigger = "Jump";

		public static event System.Action<string> OnObjectCollision;

		[SerializeField] private Animator _playerAnimator;
		[SerializeField] private Transform _player;
		[SerializeField] private GameObject _playerCapsule;
		private int _currentPos = 0;
		private bool _isGrounded = true;

		private void Update()
		{
			InputMethod();

			_isGrounded = CheckGround();
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

		private bool CheckGround()
		{
			RaycastHit hit;
			if(Physics.Raycast(_player.position, Vector3.down, out hit, 0.01f))
			{
				if(hit.transform.CompareTag(Tags.GameGround))
				{
					return true;
				}
			}
			return false;
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
			if(_isGrounded)
			{
				_playerAnimator.SetTrigger(PlayerAnimatorJumpTrigger);
			}
		}

		private void OnTriggerEnter(Collider collider)
		{
			if(OnObjectCollision!=null)
			{
				OnObjectCollision(collider.tag);
			}
		}
	}
}
