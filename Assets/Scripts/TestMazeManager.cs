using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestMazeManager : MonoBehaviour
{
    public GameObject player;
    public Button upButton, downButton, leftButton, rightButton;
    public int stepsRemaining = 0;

    private PlayerMover mover;

    void Start()
    {
        mover = player.GetComponent<PlayerMover>();
        UpdateButtonStates();
    }

    public void RollDice()
    {
        stepsRemaining = Random.Range(1, 7);
        mover.SetSteps(stepsRemaining);
        UpdateButtonStates();
    }

    public void UpdateButtonStates()
    {
        if (stepsRemaining <= 0)
        {
            SetAllButtons(false);
            return;
        }

        upButton.interactable = mover.CanMove(Vector2Int.up);
        downButton.interactable = mover.CanMove(Vector2Int.down);
        leftButton.interactable = mover.CanMove(Vector2Int.left);
        rightButton.interactable = mover.CanMove(Vector2Int.right);
    }

    private void SetAllButtons(bool state)
    {
        upButton.interactable = state;
        downButton.interactable = state;
        leftButton.interactable = state;
        rightButton.interactable = state;
    }

     public void OnMove(Vector2Int direction)
     {
         if (stepsRemaining > 0 && mover.Move(direction))
         {
             stepsRemaining--;
             mover.SetSteps(stepsRemaining);
             UpdateButtonStates();
         }
     }
    public void MoveUp()
    {
        OnMove(Vector2Int.up);
    }

    public void MoveDown()
    {
        OnMove(Vector2Int.down);
    }

    public void MoveLeft()
    {
        OnMove(Vector2Int.left);
    }

    public void MoveRight()
    {
        OnMove(Vector2Int.right);
    }
}
