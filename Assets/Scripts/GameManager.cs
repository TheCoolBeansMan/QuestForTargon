using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text mapText;
    public Text mainGameText;
    public Text xpText;
    public Text attackText;
    public Text enemyText;

    public GameObject moveButton;
    public GameObject dismountButton;
    public GameObject attackButton;
    public GameObject deadButton;
    public GameObject finalAttackButton;
    public GameObject firstMovementButton;

    public GameObject currPlayerPortrait;
    public Sprite[] playerPortraits;

    public GameObject currGamePortrait;
    public Sprite[] gamePortraits;

    private int currSpace;
    private int currDice;
    private int rolledDamage;
    private int enemyHP;
    private int xp;
    private int attack;
    private bool isDismounted;
    private bool start;


    private void Start()
    {

        attack = 0;
        xp = 0;
        isDismounted = false;
        start = true;
        currSpace = 0;

        mapText.text = "P---------------------------D";
        mainGameText.text = "Welcome to Targan, you are the Targinian. You embark on a journey to find the Well of Targanium to gain ontold power.";
        xpText.text = "XP: 0";
        attackText.text = "Weapon: Your Wits (+0)";
        enemyText.text = "None";

        currPlayerPortrait.GetComponent<Image>().sprite = playerPortraits[0];
        currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];

        firstMovementButton.SetActive(true);
        moveButton.SetActive(false);
        dismountButton.SetActive(false);
        attackButton.SetActive(false);
        deadButton.SetActive(false);
        finalAttackButton.SetActive(false);
    }

    private void Update()
    {
        //Free Space
        if (currSpace == 1)
        {
            currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
            mapText.text = "P---------------------------D";
            mainGameText.text = "You are on space " + currSpace.ToString() + ".";
            enemyText.text = "None";
            firstMovementButton.SetActive(false);
            moveButton.SetActive(true);
            dismountButton.SetActive(true);

            if (isDismounted == true)
            {
                mainGameText.text = "You look around and see only your humble home, leaving your Funko Pop Collection behind you remind yourself of your mission and gain 1 XP!";
                xpText.text = "XP: " + xp.ToString();
                dismountButton.SetActive(false);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
            }
        }
        //Encounter
        if (currSpace == 2)
        {
            if (start == true)
            {
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
                mapText.text = "-P--------------------------D";
                mainGameText.text = "You are on space " + currSpace.ToString() + ".";
                enemyText.text = "None";
                moveButton.SetActive(true);
                dismountButton.SetActive(true);
            }

            if (isDismounted == true)
            {
                mainGameText.text = "You Encounter a peaceful gnome. But it is IN YOUR WAY! Get Ready to Attack.";
                enemyText.text = "Gnome (3 HP)";
                dismountButton.SetActive(false);
                moveButton.SetActive(false);
                attackButton.SetActive(true);
                enemyHP = 3;
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
            }
        }
        //Free Space
        if (currSpace == 3)
        {
            currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
            mapText.text = "--P-------------------------D";
            mainGameText.text = "You are on space " + currSpace.ToString() + ".";
            enemyText.text = "None";
            moveButton.SetActive(true);
            dismountButton.SetActive(true);

            if (isDismounted == true)
            {
                mainGameText.text = "You look around and smell the roses, she smells you back and say you smell quite nice so after feeling better about yourself you gain 1 XP!";
                xpText.text = "XP: " + xp.ToString();
                dismountButton.SetActive(false);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
            }
        }
        //Free Space
        if (currSpace == 4)
        {
            currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
            mapText.text = "---P------------------------D";
            mainGameText.text = "You are on space " + currSpace.ToString() + ".";
            enemyText.text = "None";
            moveButton.SetActive(true);
            dismountButton.SetActive(true);

            if (isDismounted == true)
            {
                mainGameText.text = "You find a crisp 20 dollar bill on the ground, you however have no use for cash as you exclussively trade in cryptocurrency. Rememebering this fact lets you gain 1 XP!";
                xpText.text = "XP: " + xp.ToString();
                dismountButton.SetActive(false);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
            }
        }
        //Loot
        if (currSpace == 5)
        {
            currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
            mapText.text = "----P-----------------------D";
            mainGameText.text = "You are on space " + currSpace.ToString() + ".";
            enemyText.text = "None";
            moveButton.SetActive(true);
            dismountButton.SetActive(true);

            if (isDismounted == true)
            {
                attack = 3;
                mainGameText.text = "You find a nice fella with a Big Iron on his hip. You talk to him and complement his choice of sidearm. The man ends up letting you keep it after a nice long chat. You know have a BIG IRON";
                attackText.text = "Weapon: BIG IRON (+" + attack.ToString() + ")";
                dismountButton.SetActive(false);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
                currPlayerPortrait.GetComponent<Image>().sprite = playerPortraits[1];
            }
        }
        //Encounter
        if (currSpace == 6)
        {
            if (start == true)
            {
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
                mapText.text = "-----P----------------------D";
                mainGameText.text = "You are on space " + currSpace.ToString() + ".";
                enemyText.text = "None";
                moveButton.SetActive(true);
                dismountButton.SetActive(true);
            }

            if (isDismounted == true)
            {
                mainGameText.text = "After walking through the swamps you find an UGLY OLD WITCH. Quick, get ready to Attack.";
                enemyText.text = "Witch (5 HP)";
                dismountButton.SetActive(false);
                moveButton.SetActive(false);
                attackButton.SetActive(true);
                enemyHP = 5;
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
            }
        }
        //Free Space
        if (currSpace == 7)
        {
            currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
            mapText.text = "------P---------------------D";
            mainGameText.text = "You are on space " + currSpace.ToString() + ".";
            enemyText.text = "None";
            moveButton.SetActive(true);
            dismountButton.SetActive(true);

            if (isDismounted == true)
            {
                mainGameText.text = "A strange girl walks up to you and challanges you to a gaming game off, YOU LOSE. But this humbling experience has allowed you to gain 1 XP.";
                xpText.text = "XP: " + xp.ToString();
                dismountButton.SetActive(false);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
            }
        }
        //Encounter
        if (currSpace == 8)
        {
            if (start == true)
            {
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
                mapText.text = "-------P--------------------D";
                mainGameText.text = "You are on space " + currSpace.ToString() + ".";
                enemyText.text = "None";
                moveButton.SetActive(true);
                dismountButton.SetActive(true);
            }

            if (isDismounted == true)
            {
                mainGameText.text = "You see a strange man fishing by the pond with a non scoped rod. This crime cannot go unpunished. Get ready to deliver justice and Attack.";
                enemyText.text = "Fisherman (7 HP)";
                dismountButton.SetActive(false);
                moveButton.SetActive(false);
                attackButton.SetActive(true);
                enemyHP = 7;
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
            }
        }
        //Encounter
        if (currSpace == 9)
        {
            if (start == true)
            {
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
                mapText.text = "--------P-------------------D";
                mainGameText.text = "You are on space " + currSpace.ToString() + ".";
                enemyText.text = "None";
                moveButton.SetActive(true);
                dismountButton.SetActive(true);
            }

            if (isDismounted == true)
            {
                mainGameText.text = "You see a man outside an RV. He offers to sell you some valuable crystals but his prices are outragous! Thankfully, you have a coupon. Get ready to attack.";
                enemyText.text = "RV Man (8 HP)";
                dismountButton.SetActive(false);
                moveButton.SetActive(false);
                attackButton.SetActive(true);
                enemyHP = 8;
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
            }
        }
        //Loot
        if (currSpace == 10)
        {
            currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
            mapText.text = "---------P------------------D";
            mainGameText.text = "You are on space " + currSpace.ToString() + ".";
            enemyText.text = "None";
            moveButton.SetActive(true);
            dismountButton.SetActive(true);

            if (isDismounted == true)
            {
                attack = 5;
                mainGameText.text = "In the ends of the swamp you find a beautiful tree with a sword in the middle. You grab the sword and with your buldging muscles you now have THE DRAGONSLAYER";
                attackText.text = "Weapon: THE DRAGONSLAYER (+" + attack.ToString() + ")";
                dismountButton.SetActive(false);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
                currPlayerPortrait.GetComponent<Image>().sprite = playerPortraits[2];
            }
        }
        //Free Space
        if (currSpace == 11)
        {
            currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
            mapText.text = "----------P-----------------D";
            mainGameText.text = "You are on space " + currSpace.ToString() + ".";
            enemyText.text = "None";
            moveButton.SetActive(true);
            dismountButton.SetActive(true);

            if (isDismounted == true)
            {
                mainGameText.text = "You walk through the city and you find a trashcan. Inside the trashcan you find a FUNKO POP! This joyous occasion allows you to gain 1 XP.";
                xpText.text = "XP: " + xp.ToString();
                dismountButton.SetActive(false);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
            }
        }
        //Free Space
        if (currSpace == 12)
        {
            currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
            mapText.text = "-----------P----------------D";
            mainGameText.text = "You are on space " + currSpace.ToString() + ".";
            enemyText.text = "None";
            moveButton.SetActive(true);
            dismountButton.SetActive(true);

            if (isDismounted == true)
            {
                mainGameText.text = "Inside a cafe you find an evil sandwich vendor making evil sandwiches. You manage to convice him to turn to the light side. This allows you to gain 1 XP.";
                xpText.text = "XP: " + xp.ToString();
                dismountButton.SetActive(false);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
            }
        }
        //Free Space
        if (currSpace == 13)
        {
            currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
            mapText.text = "------------P---------------D";
            mainGameText.text = "You are on space " + currSpace.ToString() + ".";
            enemyText.text = "None";
            moveButton.SetActive(true);
            dismountButton.SetActive(true);

            if (isDismounted == true)
            {
                mainGameText.text = "You find a fountain in the center of the city full of coins! Yummy! You jump in and eat to your hearts content. You are stuffed and gain 1 XP.";
                xpText.text = "XP: " + xp.ToString();
                dismountButton.SetActive(false);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
            }
        }
        //Encounter
        if (currSpace == 14)
        {
            if (start == true)
            {
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
                mapText.text = "-------------P--------------D";
                mainGameText.text = "You are on space " + currSpace.ToString() + ".";
                enemyText.text = "None";
                moveButton.SetActive(true);
                dismountButton.SetActive(true);
            }

            if (isDismounted == true)
            {
                mainGameText.text = "You find a little girl armed to the teeth driving a tank. Well we can't allow traffic laws to be violated. Correction is in order. Get ready to Attack.";
                enemyText.text = "Tank Girl (9 HP)";
                dismountButton.SetActive(false);
                moveButton.SetActive(false);
                attackButton.SetActive(true);
                enemyHP = 9;
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
            }
        }
        //Encounter
        if (currSpace == 15)
        {
            if (start == true)
            {
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
                mapText.text = "--------------P-------------D";
                mainGameText.text = "You are on space " + currSpace.ToString() + ".";
                enemyText.text = "None";
                moveButton.SetActive(true);
                dismountButton.SetActive(true);
            }

            if (isDismounted == true)
            {
                mainGameText.text = "You find yourself enetring the spooky woods but find a helpful gnome. The gnome does a little jig. This deeply INFURIATES you. Get ready to Attack.";
                enemyText.text = "Jig Gnome (9 HP)";
                dismountButton.SetActive(false);
                moveButton.SetActive(false);
                attackButton.SetActive(true);
                enemyHP = 9;
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
            }
        }
        //Free Space
        if (currSpace == 16)
        {
            currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
            mapText.text = "---------------P------------D";
            mainGameText.text = "You are on space " + currSpace.ToString() + ".";
            enemyText.text = "None";
            moveButton.SetActive(true);
            dismountButton.SetActive(true);

            if (isDismounted == true)
            {
                mainGameText.text = "You find a stray cat. He is a very helpful cat. You talk, share stories, play games. After a couple of hours you go your seperate ways and gain 1 XP.";
                xpText.text = "XP: " + xp.ToString();
                dismountButton.SetActive(false);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
            }
        }
        //Free Space
        if (currSpace == 17)
        {
            currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
            mapText.text = "----------------P-----------D";
            mainGameText.text = "You are on space " + currSpace.ToString() + ".";
            enemyText.text = "None";
            moveButton.SetActive(true);
            dismountButton.SetActive(true);

            if (isDismounted == true)
            {
                mainGameText.text = "You decide to take a break to sharpen your wits. After a couple of months you have gained 1 XP.";
                xpText.text = "XP: " + xp.ToString();
                dismountButton.SetActive(false);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
            }
        }
        //Free Space
        if (currSpace == 18)
        {
            currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
            mapText.text = "-----------------P----------D";
            mainGameText.text = "You are on space " + currSpace.ToString() + ".";
            enemyText.text = "None";
            moveButton.SetActive(true);
            dismountButton.SetActive(true);

            if (isDismounted == true)
            {
                mainGameText.text = "You find a beautiful garden within find the GumGum fruit. You give it a bite and it sure tastes! You feel like you gained something but you definetly gain 1 Xp.";
                xpText.text = "XP: " + xp.ToString();
                dismountButton.SetActive(false);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
            }
        }
        //Loot
        if (currSpace == 19)
        {
            currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
            mapText.text = "------------------P---------D";
            mainGameText.text = "You are on space " + currSpace.ToString() + ".";
            enemyText.text = "None";
            moveButton.SetActive(true);
            dismountButton.SetActive(true);

            if (isDismounted == true)
            {
                attack = 7;
                mainGameText.text = "You find a chest in the middle of the spooky forest. Inside you find a little scrimblio guy. He seems quite strong and hes willing to fight for you. You now have SCRIMBLIO";
                attackText.text = "Weapon: SCRIMBLIO (+" + attack.ToString() + ")";
                dismountButton.SetActive(false);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
                currPlayerPortrait.GetComponent<Image>().sprite = playerPortraits[3];
            }
        }
        //Encounter
        if (currSpace == 20)
        {
            if (start == true)
            {
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
                mapText.text = "-------------------P--------D";
                mainGameText.text = "You are on space " + currSpace.ToString() + ".";
                enemyText.text = "None";
                moveButton.SetActive(true);
                dismountButton.SetActive(true);
            }

            if (isDismounted == true)
            {
                mainGameText.text = "You find a Vampire in the spooky woods! But she hasn't spotted you! Quick get ready to attack.";
                enemyText.text = "Vampire (10 HP)";
                dismountButton.SetActive(false);
                moveButton.SetActive(false);
                attackButton.SetActive(true);
                enemyHP = 10;
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
            }
        }
        //Encounter
        if (currSpace == 21)
        {
            if (start == true)
            {
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
                mapText.text = "--------------------P-------D";
                mainGameText.text = "You are on space " + currSpace.ToString() + ".";
                enemyText.text = "None";
                moveButton.SetActive(true);
                dismountButton.SetActive(true);
            }

            if (isDismounted == true)
            {
                mainGameText.text = "Micheal!??!?! Whats that guy doing here? Sorry buddy wrong game. Hey get this guy outta here and get ready to Attack.";
                enemyText.text = "Micheal (2 HP)";
                dismountButton.SetActive(false);
                moveButton.SetActive(false);
                attackButton.SetActive(true);
                enemyHP = 2;
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
            }
        }
        //Loot
        if (currSpace == 22)
        {
            currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
            mapText.text = "---------------------P------D";
            mainGameText.text = "You are on space " + currSpace.ToString() + ".";
            enemyText.text = "None";
            moveButton.SetActive(true);
            dismountButton.SetActive(true);

            if (isDismounted == true)
            {
                attack = 9;
                mainGameText.text = "At the end of the Spooky Forest you find Haki Serum. You drink it in order to gain the power of Haki! You did! You know have HAKI";
                attackText.text = "Weapon: HAKI (+" + attack.ToString() + ")";
                dismountButton.SetActive(false);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
                currPlayerPortrait.GetComponent<Image>().sprite = playerPortraits[4];
            }
        }
        //Free Space
        if (currSpace == 23)
        {
            currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
            mapText.text = "----------------------P-----D";
            mainGameText.text = "You are on space " + currSpace.ToString() + ".";
            enemyText.text = "None";
            moveButton.SetActive(true);
            dismountButton.SetActive(true);

            if (isDismounted == true)
            {
                mainGameText.text = "You are in the Gates of Targon. The Goddess of Targon lives here. You look at the gates and find that they're made of your favorite type of wood! You gain 1 XP.";
                xpText.text = "XP: " + xp.ToString();
                dismountButton.SetActive(false);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
            }
        }
        //Encounter
        if (currSpace == 24)
        {
            if (start == true)
            {
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
                mapText.text = "-----------------------P----D";
                mainGameText.text = "You are on space " + currSpace.ToString() + ".";
                enemyText.text = "None";
                moveButton.SetActive(true);
                dismountButton.SetActive(true);
            }

            if (isDismounted == true)
            {
                mainGameText.text = "You find a copy of Festers Quest on the Ground, but it begins attacking you! Sorcery!?!? Quick get ready to Attack.";
                enemyText.text = "Festers Quest (11 HP)";
                dismountButton.SetActive(false);
                moveButton.SetActive(false);
                attackButton.SetActive(true);
                enemyHP = 13;
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
            }
        }
        //Free Space
        if (currSpace == 25)
        {
            currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
            mapText.text = "------------------------P---D";
            mainGameText.text = "You are on space " + currSpace.ToString() + ".";
            enemyText.text = "None";
            moveButton.SetActive(true);
            dismountButton.SetActive(true);

            if (isDismounted == true)
            {
                mainGameText.text = "You find the break room. Theres various sodas littered about. You drink your favorite, Sunny D, and gain 1 XP.";
                xpText.text = "XP: " + xp.ToString();
                dismountButton.SetActive(false);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
            }
        }
        //Free Space
        if (currSpace == 26)
        {
            currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
            mapText.text = "-------------------------P--D";
            mainGameText.text = "You are on space " + currSpace.ToString() + ".";
            enemyText.text = "None";
            moveButton.SetActive(true);
            dismountButton.SetActive(true);

            if (isDismounted == true)
            {
                mainGameText.text = "You find a cool pair of sunglasses right before the throne room. You put them on and strike a cool pose. You gain 1000 swag and gain 1 XP.";
                xpText.text = "XP: " + xp.ToString();
                dismountButton.SetActive(false);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
            }
        }
        //Encounter
        if (currSpace == 27)
        {
            if (start == true)
            {
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
                mapText.text = "--------------------------P-D";
                mainGameText.text = "You are on space " + currSpace.ToString() + ".";
                enemyText.text = "None";
                moveButton.SetActive(true);
                dismountButton.SetActive(true);
            }

            if (isDismounted == true)
            {
                mainGameText.text = "Right as you're about to enter the throne room you're ambushed by The Law!?!? He gets ready to lay down the law if ya catch my drift. Get ready to DIE!";
                enemyText.text = "The Law (13 HP)";
                dismountButton.SetActive(false);
                moveButton.SetActive(false);
                attackButton.SetActive(true);
                enemyHP = 13;
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
            }
        }
        //Loot
        if (currSpace == 28)
        {
            currGamePortrait.GetComponent<Image>().sprite = gamePortraits[0];
            mapText.text = "---------------------------PD";
            mainGameText.text = "You are on space " + currSpace.ToString() + ".";
            enemyText.text = "None";
            moveButton.SetActive(true);
            dismountButton.SetActive(true);

            if (isDismounted == true)
            {
                attack = 12;
                mainGameText.text = "Right Before you go in. You realize all the lessons you've learned on your journey. You're really weapon. Is your WITS. You gain the WITS KATANA!";
                attackText.text = "WITS KATANA: (+" + attack.ToString() + ")";
                dismountButton.SetActive(false);
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
                currPlayerPortrait.GetComponent<Image>().sprite = playerPortraits[5];
            }
        }
        //Final Boss
        if (currSpace >= 29)
        {
            if (start == true)
            {
                currGamePortrait.GetComponent<Image>().sprite = gamePortraits[28];
                mapText.text = "----------------------------P";
                mainGameText.text = "You are on space " + currSpace.ToString() + ".";
                enemyText.text = "None";
                moveButton.SetActive(true);
                dismountButton.SetActive(true);
            }

            if (isDismounted == true)
            {
                if (xp >= 10)
                {
                    mainGameText.text = "You finally make it. Ready to defeat the Targon Goddes you ready yourself and go in for the kill. Get ready to STRIKE!";
                    enemyText.text = "Goddess of Targon (15 HP)";
                    dismountButton.SetActive(false);
                    moveButton.SetActive(false);
                    finalAttackButton.SetActive(true);
                    enemyHP = 15;
                    currGamePortrait.GetComponent<Image>().sprite = gamePortraits[currSpace];
                }
                else
                {
                    mainGameText.text = "To weak and in experienced. The second you step foot in the throne room the whole world shakes and you are reduced to ash in but an instant. You DIE!";
                    deadButton.SetActive(true);
                    dismountButton.SetActive(false);
                    moveButton.SetActive(false);
                }
            }
        }
    }

    public void FirstMove()
    {
        isDismounted = false;
        currSpace++;
    }

    public void Movement()
    {

        isDismounted = false;
        currDice = Random.Range(1, 4);
        currSpace += currDice;
        if (currSpace > 29)
            currSpace = 29;
        start = true;


    }

    public void Dismount()
    {
        isDismounted = true;
        if (currSpace == 1 || currSpace == 3 || currSpace == 4 || currSpace == 7 || currSpace == 11 || currSpace == 12 || currSpace == 13 || currSpace == 16 || currSpace == 17 || currSpace == 18 || currSpace == 23 || currSpace == 25 || currSpace == 26)
        {
            xp++;
        }
    }

    public void Attack()
    {
        start = false;
        rolledDamage = Random.Range(1, 7) + attack;

        if (rolledDamage >= enemyHP)
        {
            xp += 2;
            mainGameText.text = "Using your weapon you deal " + (rolledDamage + attack).ToString() + " damage! Well done Targinian! You have gained 2 XP!";
            xpText.text = "XP: " + xp.ToString();
            enemyText.text = " ";
            moveButton.SetActive(true);
            attackButton.SetActive(false);
            isDismounted = false;
        }
        else
        {
            mainGameText.text = "As you went in to strike you tripped on a bannana peel and only did " + (rolledDamage + attack).ToString() + " damage. Kinda cringe...";
            deadButton.SetActive(true);
            attackButton.SetActive(false);
        }
    }

    public void FinalAttack()
    {
        start = false;
        isDismounted = false;
        rolledDamage = Random.Range(1, 7) + attack;

        if (rolledDamage >= enemyHP)
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            mainGameText.text = "Your pathetic " + (rolledDamage + attack).ToString() + " damage didn't even leave a scratch. She used her [DOMAIN EXPANSION] and instantly killed you. You are MEGA DEAD!";
            deadButton.SetActive(true);
            attackButton.SetActive(false);
        }
    }
}