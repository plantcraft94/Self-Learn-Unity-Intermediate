using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	[SerializeField] string playerName;
	[SerializeField] Survivor survivor;
	InputAction moveAction;
	float movement;
	private void Awake()
	{
		moveAction = InputSystem.actions.FindAction("Move");
	}
	private void Update()
	{
		ReadInput();
		survivor.Move(movement);
	}
	void ReadInput()
	{
		movement = moveAction.ReadValue<float>();
	}
}
