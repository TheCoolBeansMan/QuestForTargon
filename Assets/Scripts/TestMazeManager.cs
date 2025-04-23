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
    public GameObject attackButton;
    public GameObject deathButton;
    public GameObject winButton;

    public Text treasureText;
    public Text attackText;

    private int rolledDamage;
    private int enemyHP;
    private int attack;
    private int treasures;

    void Start()
    {
        currPlayerPortrait.GetComponent<Image>().sprite = playerPortraits[0];
        treasures = 0;
        attack = 0;
        attackText.text = "Aura (" + attack.ToString() + ")"; 
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

    private void Update()
    {
        attackText.text = "Aura (" + attack.ToString() + ")";
        treasureText.text = treasures.ToString();
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
                attack += 3;
                gameText.text = "You make it back to the start of the maze where you set up camp and consume some of your emergency soylent. Your aura goes up by 3";
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
            }
            else if (obj.tag == "1")
            {
                eventButton.SetActive(false);
                attackButton.SetActive(true);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[1];
                gameText.text = "You go in expecting a fight against an evil minotaur, but to your despair, it turns out to be a mini-minotaur instead! Brace for Impact. Its do or die time GAMER!";
                enemyHP = 25;
                
            }
            else if (obj.tag == "2")
            {
                eventButton.SetActive(false);
                attackButton.SetActive(true);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[2];
                gameText.text = "Wandering through the maze, you find a maze gnome. Thankfully for you, short people were denied rights after the last senate meeting. So get ready to attack!";
                enemyHP = 3;
            }
            else if (obj.tag == "3")
            {
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[3];
                gameText.text = "Lucky you Targian! You managed to find the Princess' beloved heart locket!";
                treasures++;
                treasureText.text = treasures.ToString();
            }
            else if (obj.tag == "4")
            {
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[4];
                gameText.text = "Lucky you Targian! You managed to find the Princess' beloved Ring!";
                treasures++;
                treasureText.text = treasures.ToString();
            }
            else if (obj.tag == "5")
            {
                eventButton.SetActive(false);
                attackButton.SetActive(true);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[5];
                gameText.text = "You find a friendly face, Gustavo. Sadly for you, Gustavo is also chasing after the princesses heart. And all is fair in love and war, so KILL HIM NOW!";
                enemyHP = 6;
            }
            else if (obj.tag == "6")
            {
                eventButton.SetActive(false);
                attackButton.SetActive(true);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[6];
                gameText.text = "Yikes! Thats one creepy crawly! Quick Kill it before it kills you!";
                enemyHP = 5;
            }
            else if (obj.tag == "7")
            {
                eventButton.SetActive(false);
                attackButton.SetActive(true);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[7];
                gameText.text = "Todd Howard appears before you. Hes trying to get you to buy some of his new DLC but ya tell him you already did last generation! Looks like theres only one way outta this.";
                enemyHP = 10;
            }
            else if (obj.tag == "8")
            {
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[8];
                gameText.text = "As you wander around the labrynth you fall into a comically large hole and get sent back to the start, oops!";
                //reset plarer position
            }
            else if (obj.tag == "9")
            {
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[9];
                gameText.text = "Lucky you Targian! You managed to find the Princess' beloved Bracelet!";
                treasures++;
                treasureText.text = treasures.ToString();
            }
            else if (obj.tag == "10")
            {
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[10];
                gameText.text = "Lucky you Targian! You managed to find the Princess' beloved Diary!";
                treasures++;
                treasureText.text = treasures.ToString();
            }
            else if (obj.tag == "11")
            {
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[11];
                gameText.text = "Lucky you Targian! You managed to find the Princess' beloved Money Pouch!";
                treasures++;
                treasureText.text = treasures.ToString();
            }
            else if (obj.tag == "12")
            {
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[12];
                gameText.text = "Lucky you Targian! You managed to find the Princess' beloved Mirror!";
                treasures++;
                treasureText.text = treasures.ToString();
            }
            else if (obj.tag == "13")
            {
                eventButton.SetActive(false);
                attackButton.SetActive(true);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[13];
                gameText.text = "Theres a Zombie on your lawn?!?!?! Unfortunatley ya didn't bring any plants with you, so its all up to you to cute this fiend down.";
                enemyHP = 12;
            }
            else if (obj.tag == "14")
            {
                eventButton.SetActive(false);
                attackButton.SetActive(true);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[14];
                gameText.text = "A skeleton blocks your path. He seems like a friendly guy but hes way to spooky to let live.";
                enemyHP = 15;
            }
            else if (obj.tag == "15")
            {
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[15];
                gameText.text = "Lucky you Targian! You managed to find the Princess' beloved Hair Brush";
                treasures++;
                treasureText.text = treasures.ToString();
            }
            else if (obj.tag == "16")
            {
                eventButton.SetActive(false);
                attackButton.SetActive(true);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[16];
                gameText.text = "A pirate stops you and demands you hand him over all your treasures. Nuh uh buddy. These are the princess'. Looks like someones about to get GAMERED!";
                enemyHP = 18;
            }
            else if (obj.tag == "17")
            {
                eventButton.SetActive(false);
                attackButton.SetActive(true);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[17];
                gameText.text = "A kind old man is fishing in a small pond in the maze. You notice however that his fishing liscense is expired. Time to deliver justice and FIGHT!";
                enemyHP = 20;
            }
            else if (obj.tag == "18")
            {
                attack =+ 15;
                gameText.text = "Hidden in the labrynth you find the ultimate weakness of all minotaurs. TAR TAR SAUCE! You are sure to win now! Your aura goes up by 15";
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[18];
                currPlayerPortrait.GetComponent<Image>().sprite = playerPortraits[1];
            }
            else if (obj.tag == "19")
            {
                eventButton.SetActive(false);
                attackButton.SetActive(true);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[19];
                gameText.text = "Gurading the princess you see none other then her head knight. Markiplier. Seems he wants the treasures for himself! Not gonna happen SUCKAPLIER!";
                enemyHP = 23;
            }
            else if (obj.tag == "20")
            {
                if (treasures >= 7)
                {
                    eventButton.SetActive(false);
                    winButton.SetActive(true);
                    currGamePortrait.GetComponent<Image>().sprite = gamePortraits[23];
                    gameText.text = "You collect all of the princesses treasures. She is delighted to see you and decides to appoint you as her new Knight! Good Job GAMER!";
                    
                }
                else
                {
                    attack -= 5;
                    currGamePortrait.GetComponent<Image>().sprite = gamePortraits[20];
                    gameText.text = "Someone doesn't have enough treasure!. Your aura of poverty is mogged by the princesses affluant aura knocking you to the start and making you lose 5 aura!";
                    //reset plarer position
                }
            }
            else if (obj.tag == "21")
            {
                attack += 2;
                gameText.text = "You find a secluded part of the maze and decide to begin aura farming. Your aura goes up by 2";
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[21];
            }
            else if (obj.tag == "22")
            {
                attack -= 2;
                gameText.text = "You find a cute dungeon slime and attempt to 'use rizz'. Sadly you have no rizz to speak of. Your aura goes down by 2";
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[22];
            }

        }
        else
        {
            Debug.Log("No object found under player.");
        }
    }
    public void Attack()
    {
        rolledDamage = Random.Range(1, 7) + attack;

        if (rolledDamage >= enemyHP)
        {
            gameText.text = "Using your aura you deal " + (rolledDamage + attack).ToString() + " damage and mog the enemy! Well done Targinian! Your aura goes up by 1";
            attack += 1;
            attackButton.SetActive(false);
            eventButton.SetActive(true);
        }
        else
        {
            gameText.text = "You project your aura but only deal " + (rolledDamage + attack).ToString() + " damage. The enemy outrizzes you and instantly kills you. Kinda cringe...";
            attackButton.SetActive(false);
            deathButton.SetActive(true);
        }
    }
}
