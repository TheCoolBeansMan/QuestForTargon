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
    public GameObject eventButton;
    public int sendInteger;

    public GameObject currPlayerPortrait;
    public Sprite[] playerPortraits;

    public GameObject currGamePortrait;
    public Sprite[] gamePortraits;

    public Text gameText;
    public GameObject spiderButton;
    public GameObject zombieButton;
    public GameObject deathButton;
    public GameObject winButton;

    public Text treasureText;

    private int rolledDamage;
    private int treasures;
    private int minotaurHP = 30;
    private int playerHP = 20;

    public GameObject locket;
    public GameObject ring;
    public GameObject bracelet;
    public GameObject diary;
    public GameObject brush;
    public GameObject pouch;
    public GameObject mirror;
    public GameObject horn;

    private bool hasLocket = false;
    private bool hasRing = false;
    private bool hasBracelet = false;
    private bool hasDiary = false;
    private bool hasBrush = false;
    private bool hasPouch = false;
    private bool hasMirror = false;
    private bool hasHorn = false;

    private bool isBitten = false;


    void Start()
    {
        currPlayerPortrait.GetComponent<Image>().sprite = playerPortraits[0];
        treasures = 0;
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
                gameText.text = "Nothing Ever Happens";
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
            }
            else if (obj.tag == "1")
            {
                //Remake Fight
            }
            else if (obj.tag == "2")
            {
                gameText.text = "LMAO TRAPPED!";
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[2];
            }
            else if (obj.tag == "3")
            {
                if (hasLocket == false)
                {
                    currGamePortrait.GetComponent<Image>().sprite = gamePortraits[3];
                    gameText.text = "Lucky you Targian! You managed to find the Princess' beloved heart locket!";
                    treasures++;
                    treasureText.text = treasures.ToString();
                    locket.SetActive(true);
                    hasLocket = true;
                }
                else
                {
                    currGamePortrait.GetComponent<Image>().sprite = gamePortraits[3];
                    gameText.text = "Silly you, you already have the locket!";
                }

            }
            else if (obj.tag == "4")
            {
                if (hasRing == false)
                {
                    currGamePortrait.GetComponent<Image>().sprite = gamePortraits[4];
                    gameText.text = "Lucky you Targian! You managed to find the Princess' beloved ring !";
                    treasures++;
                    treasureText.text = treasures.ToString();
                    ring.SetActive(true);
                    hasRing = true;
                }
                else
                {
                    currGamePortrait.GetComponent<Image>().sprite = gamePortraits[4];
                    gameText.text = "Silly you, you already have the ring!";
                }

            }
            else if (obj.tag == "5")
            {
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[5];
                gameText.text = "Lucky you! You have obtained one of the princess' lost treasures!";
                if (hasLocket == false)
                {
                    locket.SetActive(true);
                    hasLocket = true;
                }
                else if (hasBrush == false)
                {
                    brush.SetActive(true);
                    hasBrush = true;
                }
                else if (hasBracelet == false)
                {
                    bracelet.SetActive(true);
                    hasBracelet = true;
                }
                else if (hasMirror == false)
                {
                    mirror.SetActive(true);
                    hasMirror = true;
                }
                else if (hasDiary == false)
                {
                    diary.SetActive(true);
                    hasDiary = true;
                }
                else if (hasPouch == false)
                {
                    pouch.SetActive(true);
                    hasPouch = true;
                }
                else if (hasRing == false)
                {
                    ring.SetActive(true);
                    hasRing = true;
                }
            }
            else if (obj.tag == "6")
            {
                eventButton.SetActive(false);
                spiderButton.SetActive(true);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[6];
                gameText.text = "Ah! A spooky spider... man? Either way, kill it before its too late!";
            }
            else if (obj.tag == "7")
            {
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[7];
                gameText.text = "Okay, someones a lucky guy! You managed to snag one of the princess' treasures! Way to go Targinian!";
                if (hasLocket == false)
                {
                    locket.SetActive(true);
                    hasLocket = true;
                }
                else if (hasBrush == false)
                {
                    brush.SetActive(true);
                    hasBrush = true;
                }
                else if (hasBracelet == false)
                {
                    bracelet.SetActive(true);
                    hasBracelet = true;
                }
                else if (hasMirror == false)
                {
                    mirror.SetActive(true);
                    hasMirror = true;
                }
                else if (hasDiary == false)
                {
                    diary.SetActive(true);
                    hasDiary = true;
                }
                else if (hasPouch == false)
                {
                    pouch.SetActive(true);
                    hasPouch = true;
                }
                else if (hasRing == false)
                {
                    ring.SetActive(true);
                    hasRing = true;
                }
            }
            else if (obj.tag == "8")
            {
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[8];
                gameText.text = "As you wander around the labrynth you fall into a comically large hole and get sent back to the start, oops!";
                //reset plarer position
            }
            else if (obj.tag == "9")
            {
                if (hasBracelet == false)
                {
                    currGamePortrait.GetComponent<Image>().sprite = gamePortraits[9];
                    gameText.text = "Lucky you Targian! You managed to find the Princess' beloved bracelet!";
                    treasures++;
                    treasureText.text = treasures.ToString();
                    bracelet.SetActive(true);
                    hasBracelet = true;
                }
                else
                {
                    currGamePortrait.GetComponent<Image>().sprite = gamePortraits[9];
                    gameText.text = "Silly you, you already have the bracelet!";
                }
            }
            else if (obj.tag == "10")
            {
                //diary event
            }
            else if (obj.tag == "11")
            {
                if (hasPouch == false)
                {
                    currGamePortrait.GetComponent<Image>().sprite = gamePortraits[11];
                    gameText.text = "Lucky you Targian! You managed to find the Princess' beloved money pouch!";
                    treasures++;
                    treasureText.text = treasures.ToString();
                    pouch.SetActive(true);
                    hasPouch = true;
                }
                else
                {
                    currGamePortrait.GetComponent<Image>().sprite = gamePortraits[11];
                    gameText.text = "Silly you, you already have the money pouch!";
                }
            }
            else if (obj.tag == "12")
            {
                if (hasMirror == false)
                {
                    currGamePortrait.GetComponent<Image>().sprite = gamePortraits[12];
                    gameText.text = "Lucky you Targian! You managed to find the Princess' beloved mirror!";
                    treasures++;
                    treasureText.text = treasures.ToString();
                    mirror.SetActive(true);
                    hasMirror = true;
                }
                else
                {
                    currGamePortrait.GetComponent<Image>().sprite = gamePortraits[12];
                    gameText.text = "Silly you, you already have the mirror!";
                }
            }
            else if (obj.tag == "13")
            {
                eventButton.SetActive(false);
                zombieButton.SetActive(true);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[13];
                gameText.text = "Ah! A malevolant zombie draws near! Kill it before its too late!";
            }
            else if (obj.tag == "14")
            {
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[14];
                gameText.text = "You have been cured of Zombie Bite!";
                isBitten = false;
            }
            else if (obj.tag == "15")
            {
                if (hasBrush == false)
                {
                    currGamePortrait.GetComponent<Image>().sprite = gamePortraits[15];
                    gameText.text = "Lucky you Targian! You managed to find the Princess' beloved heart locket!";
                    treasures++;
                    treasureText.text = treasures.ToString();
                    brush.SetActive(true);
                    hasBrush = true;
                }
                else
                {
                    currGamePortrait.GetComponent<Image>().sprite = gamePortraits[15];
                    gameText.text = "Silly you, you already have the hair brush!";
                }
            }
            else if (obj.tag == "16")
            {
                //Choose number of squares to move
            }
            else if (obj.tag == "17")
            {
                minotaurHP = 25;
                //Fight Minotaur
            }
            else if (obj.tag == "18")
            {
                minotaurHP = 25;
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[18];
                currPlayerPortrait.GetComponent<Image>().sprite = playerPortraits[1];
                gameText.text = "Amongst the ruins of the maze you manage to find the magic axe! You are invigorated with great power!";
            }
            else if (obj.tag == "19")
            {
                //Princess Check
            }
        }
        else
        {
            Debug.Log("No object found under player.");
        }
    }
    public void Spider()
    {
        rolledDamage = Random.Range(1, 7);

        if (rolledDamage <= 4)
        {
            gameText.text = "Well done Targian! Your rolled a " + (rolledDamage).ToString() + ". You did it!";
            spiderButton.SetActive(false);
            eventButton.SetActive(true);
        }
        else if (rolledDamage == 5) 
        {
            if (treasures > 0)
            {
                gameText.text = "You roll a " + (rolledDamage).ToString() + " and lose a treasure in the chaos.";
                spiderButton.SetActive(false);
                eventButton.SetActive(true);
                treasures--;
                if (hasLocket == true)
                {
                    locket.SetActive(false); 
                    hasLocket = false;
                }
                else if (hasBrush == true)
                {
                    brush.SetActive(false); 
                    hasBrush = false;
                }    
                else if (hasBracelet == true)
                {
                    bracelet.SetActive(false); 
                    hasBracelet = false;
                }
                else if (hasMirror == true)
                {
                    mirror.SetActive(false); 
                    hasMirror = false;
                }
                else if (hasDiary == true)
                {
                    diary.SetActive(false);
                    hasDiary = false;
                }
                else if (hasPouch == true)
                {
                    pouch.SetActive(false);
                    hasPouch = false;
                }
                else if (hasRing == true)
                {
                    ring.SetActive(false);
                    hasRing = false;
                }
            }
            else
            {
                gameText.text = "You roll a " + (rolledDamage).ToString() + " and get flung back to the start in the chaos.";
                spiderButton.SetActive(false);
                eventButton.SetActive(true);
                //reset player postion
            }
        }
        else
        {
            gameText.text = "Looks like you only rolled a " + (rolledDamage).ToString() + ". YOU DIED!";
            spiderButton.SetActive(false);
            deathButton.SetActive(true);
        }
    }

    public void Zombie()
    {
        rolledDamage = Random.Range(1, 7);

        if (rolledDamage >= 3)
        {
            gameText.text = "Well done Targian! Your rolled a " + (rolledDamage).ToString() + ". You did it!";
            zombieButton.SetActive(false);
            eventButton.SetActive(true);
        }
        else if (rolledDamage == 2)
        {
            isBitten = true;
            gameText.text = "Oh no! You got bitten by the zombie! You can no longer collect treasures until you find a cure!";
            zombieButton.SetActive(false);
            eventButton.SetActive(true);
        }
        else
        {
            gameText.text = "Looks like you only rolled a " + (rolledDamage).ToString() + ". YOU DIED!";
            spiderButton.SetActive(false);
            deathButton.SetActive(true);
        }
    }
}
