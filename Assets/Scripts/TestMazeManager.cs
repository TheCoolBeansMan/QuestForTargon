using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestMazeManager : MonoBehaviour
{
    public GameObject player;
    public Button upButton, downButton, leftButton, rightButton;
    public Text stepsText;
    public int stepsRemaining = 0;
    public Button diceButton;
    public GameObject[] objectsToDeactivate;
    public GameObject[] objectsToActivate;
    private PlayerMover mover;
    public Button eventButton;
    public int sendInteger;

    void Start()
    {
        mover = player.GetComponent<PlayerMover>();
        UpdateStepsText();
        UpdateButtonStates();
    }

    public void RollDice()
    {
        stepsRemaining = Random.Range(1, 7);
        mover.SetSteps(stepsRemaining);
        diceButton.interactable = false;
        UpdateStepsText();
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
            UpdateStepsText();
            UpdateButtonStates();

            if (stepsRemaining == 0)
            {
                //diceButton.interactable = true;

                // Deactivate the specified GameObjects
                foreach (GameObject obj in objectsToDeactivate)
                {
                    obj.SetActive(false);
                }

                // Activate the specified GameObjects
                foreach (GameObject obj in objectsToActivate)
                {
                    obj.SetActive(true);
                }

                // Detect tag of object player is standing on
                DetectObjectUnderPlayer();
            }
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
    private void UpdateStepsText()
    {
        stepsText.text = stepsRemaining.ToString();
    }

    public void TriggerEvent()
    {
        // Reactivate objects that were deactivated
        foreach (GameObject obj in objectsToDeactivate)
        {
            obj.SetActive(true);
        }

        // Deactivate objects that were activated
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(false);
        }
        diceButton.interactable = true;

    }
    private void DetectObjectUnderPlayer()
    {
        Vector3 origin = player.transform.position;
        Vector3 direction = Vector3.forward;
        float rayLength = 2f;

        // Draw the ray in the Scene view
        Debug.DrawRay(origin, direction * rayLength, Color.green, 2f);

        RaycastHit hit;

        // Cast a ray downwards to detect what's underneath
        if (Physics.Raycast(origin, direction, out hit, rayLength))
        {
            GameObject obj = hit.collider.gameObject;
            Debug.Log("Player is on object with tag: " + obj.tag);

            if (obj.tag == "0")
            {
                sendInteger = 0;
            }
            else if (obj.tag == "1")
            {
                sendInteger = 1;
            }
            else if (obj.tag == "2")
            {
                sendInteger = 2;
            }
            else if (obj.tag == "3")
            {
                sendInteger = 3;
            }
            else if (obj.tag == "4")
            {
                sendInteger = 4;
            }
            else if (obj.tag == "5")
            {
                sendInteger = 5;
            }
            else if (obj.tag == "6")
            {
                sendInteger = 6;
            }
            else if (obj.tag == "7")
            {
                sendInteger = 7;
            }
            else if (obj.tag == "8")
            {
                sendInteger = 8;
            }
            else if (obj.tag == "9")
            {
                sendInteger = 9;
            }
            else if (obj.tag == "10")
            {
                sendInteger = 10;
            }
            else if (obj.tag == "11")
            {
                sendInteger = 11;
            }
            else if (obj.tag == "12")
            {
                sendInteger = 12;
            }
            else if (obj.tag == "13")
            {
                sendInteger = 13;
            }
            else if (obj.tag == "14")
            {
                sendInteger = 15;
            }
            else if (obj.tag == "16")
            {
                sendInteger = 16;
            }
            else if (obj.tag == "17")
            {
                sendInteger = 17;
            }
            else if (obj.tag == "18")
            {
                sendInteger = 18;
            }
            else if (obj.tag == "19")
            {
                sendInteger = 19;
            }
            else if (obj.tag == "20")
            {
                sendInteger = 20;
            }
            else if (obj.tag == "21")
            {
                sendInteger = 21;
            }
            else if (obj.tag == "22")
            {
                sendInteger = 22;
            }
            else if (obj.tag == "23")
            {
                sendInteger = 23;
            }

        }
        else
        {
            Debug.Log("No object found under player.");
        }
    }
}
