using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScenarioBlock
{
    public string scenarioHeader;
    public string scenarioText;

    public int _athMod;
    public int _agiMod;
    public int _intMod;
    public int _chaMod;

    public string _athWin;
    public string _agiWin;
    public string _intWin;
    public string _chaWin;

    public string _athLose;
    public string _agiLose;
    public string _intLose;
    public string _chaLose;

    public ScenarioBlock(string scenarioHeader, string scenarioText, int athMod, int agiMod, int intMod, int chaMod, 
        string athWin, string agiWin, string intWin, string chaWin,
        string athLose, string agiLose, string intLose, string chaLose)
    {
        this.scenarioHeader = scenarioHeader;
        this.scenarioText = scenarioText;

        this._athMod = athMod;
        this._agiMod = agiMod;
        this._intMod = intMod;
        this._chaMod = chaMod;

        this._athWin = athWin;
        this._agiWin = agiWin;
        this._intWin = intWin;
        this._chaWin = chaWin;

        this._athLose = athLose;
        this._agiLose = agiLose;
        this._intLose = intLose;
        this._chaLose = chaLose;
    }
}
public class GameController : MonoBehaviour
{
    //==SCENARIOS==
    //Scenario Array
    //public ScenarioBlock[] PossibleScenarios = new ScenarioBlock[4];
    public List<ScenarioBlock> PossibleScenarios = new List<ScenarioBlock>();
    public ScenarioBlock _currentScenario;

    //Possible scenarios
    public ScenarioBlock scenario1 = new ScenarioBlock("Carriage Crash", "After hearing a loud crash in the market square you rush over to see what is happening. " +
        "As you arrive at the square you find a crowd surrounding a cart that has flipped over, pinning a child under the carriage. What attribute will you use?",
        5, 2, 1, 3,
        //win texts
        "You rush to the cart, flexing your massive delts. You grip the side of the cart and turn it over with ease. The crowd cheering as you save the boy.", 
        "You swiftly and gracefully slide over to the cart, vaulting over the axel, and landing onto the yoke. As you land the carriage torques, lifting up just enough for the boy to be set free.", 
        "Through marvelous intuition or dumb luck, you notice that the boy is not actually pinned and only seems to be so. You casually walk over to him and pull him out from under the cart, the crowd's fear dying down into a dumbfounded realization.", 
        "You step before the fearing crowd and embolden them with an inspiring speech. Commanding hte ranks of the people, you rally the crowd to the boys aid. The crowd lifts the cart and frees the boy, thanking you for your leadership.",
        //Lose texts
        "You rush to the cart, griping the side of the carriage, flexing your massive delts. As you huff a large snap rings through your back, as you keel over like a limp noodle. The crowd's fears turn to laughter as you weep on the floor.", 
        "As you gracefully rush over to the cart, you attempt to roll, slide, and cartwheel around it. The crowd looks on in confusion as you flail about, contributing nothing to the scene.", 
        "You see the turned over cart and point out that if pressure was placed onto a certain portion of the cart it would lift up. As someone does so the cart crumples and the boy becomes further stuck under the wieght of the cart.", 
        "You step before the fearful crowd and in an attempt to lighten the mood make a joke about the boy's situation. The crowd falls silent, glaring at you as you scamper off in shame.");
    public ScenarioBlock scenario2 = new ScenarioBlock("Gap in the Pass", "As you traverse the high mountain pass alone, you come to a broken bridge that spans a large divide. Near the bridge a spindly tree leans into the gap." +
        "The gap leads to a great rocky fall to certain death.",
        2, 5, 3, 1,
        //Lose texts
        "You approach the gap without a care in the world, looking both ways before crossing. With a single standing leap you thunder across the gap spanning the distance and some, as you land on the other side with ease.", 
        "Seeing the gap, you instinctively reach into your bag and whip out your climbing rope and hook. Fashioning them swiftly, in a single motion you leap from the edge of the gap, lassoing the rope upon the tree and swinging across the gap, gracefully landing upon the other side.", 
        "As you come across the gap, you begin to rummage through your bag, excited to put some of your craft to use. Pulling out an array of equipment and tools, you begin to rebuild the bridge, refashioning it into a stronger and more durable form. After your work is done you briskly walk across with confidence.", 
        "As you began to sing a ballad of despair, a small pack of goblins come down from a nearby ridge, serranaded by your tune. In an attempt to aid you they fashion a catapult, launching you across the gap.",
        //Lose texts
        "You approach the gap without a care in the world, looking both ways before crossing. With a single standing leap you lunged into the gap. As the lack of landing comes to you, you realize the gap was much farther than anticipated. You plummet down the ridge.",
        "Seeing the gap, you instinctively reach into your bag and whip out your climbing rope and hook. Fashioning them swiftly, in a single motion you leap from the edge of the gap, lassoing the rope upon the tree. As you swing, the tree snaps under your weight as you fall into the ravine.",
        "As you come across the gap, you begin to rummage through your bag, excited to put some of your craft to use. Pulling out an array of equipment and tools, you prepare to begin, realizing now that you have no way of rebinding the other side of the bridge without a bridge itself. Looking down at your useuless equipment you decide to sit and wait.", 
        "Seeing the gap before you, it reminds you of the gap in your heart. You begin to sing a ballad of despair, alone, in the middle of nowhere, with no one around...");
   public ScenarioBlock scenario3 = new ScenarioBlock("Woodland Scavenge", "As you wander the wilds you decide to settle for the day and go out looking for food before you bed down for the day. " +
       "You gather your gear and head out into the woodlands, prepared to eat anything you can come across to fill your aching belly.",
        2, 5, 3, 1,
        //Win Descriptions
        "As you wander the forests, crackign twigs and tossing pebbles at trees, a giant boar wanders across your path. Without a thought you lunge at it head on. Grappling and wrestling it, you eventually bring it down, dragging it back to camp, emotionally preparing for the best bacon ever.", 
        "As you stalk the shadows of the woods, climbing through trees and crawling through the underbrush, you spot a magestic stag. You draw your bow, knocking an arrow and taking aim. With a crisp whisp the arrow flies through the air, taking down the stag quickly and with ease. You dress the beast there and take back what you can.", 
        "As you wander the forest you come across some mushrooms and herbs in the underbrush. Gathering them you decide to use some of them as bait as you set up a few traps for small game. After a short wait you harvest the game from all your traps and head back to camp, ready for fine dining.", 
        "As you wander lost in the woods you begin to hum a tune and whistle away. As you do so a flock of birds gather around you and sing along. Soon a small menagerie of animals walks alongside you as you dance through the woods and into a musical number.",
        //Lose Descriptions
        "As you wander the forests, crackign twigs and tossing pebbles at trees, a giant boar wanders across your path. Without a thought you lunge at it head on. After a tiring battle you are thrown off the boar as it escapes, leaving you battered and exhausted, still hungry.",
        "As you stalk the shadows of the woods, climbing through trees and crawling through the underbrush, you spot a magestic stag. You draw your bow, knocking an arrow and taking aim. Just before you release the arrow, the branch you rest upon snaps, and you fall face first into the forest floor and into a bundle of thorns.", 
        "As you wander the woodlands, confident in your crafty abilities and intuition, you begin to realize you have no practical survival skills and begin to attempt to find your way back to camp.",
        "As you wander lost in the woods you begin to bellow out your favorite opera. Unbeknownst to you, every beast in the area is alerted to your presence, leaving you in an empty and quiet forest. It does have great acoustics though.");
    /*
    public ScenarioBlock scenario4 = new ScenarioBlock("Scenario 4", "This is scenario 4 Blah blah blah...",
        5, 3, 2, 1,
        "Ath Win", "Agi Win", "Int Win", "Cha Win",
        "Ath Lose", "Agi Lose", "Int Lose", "Cha Lose");
    */

    [field: SerializeField]
        public InputBroadcaster Input { get; private set; }

    [field: SerializeField]
        public GameObject ScenarioHUD { get; private set; }
    
    [field: SerializeField]
        public GameObject ResetButton { get; private set; }

    [field: SerializeField]
        public GameObject QuitButton { get; private set; }

    //SCENARIO TEXT BOXES
    [field: SerializeField]
        public TextMeshProUGUI ScenarioHeader { get; private set; }
    [field: SerializeField]
        public TextMeshProUGUI ScenarioText { get; private set; }

    //WIN SCREEN
    [field: SerializeField]
        public GameObject WinScreen { get; private set; }
    [field: SerializeField]
        public TextMeshProUGUI WinHeader { get; private set; }
    [field: SerializeField]
        public TextMeshProUGUI WinText { get; private set; }
    //LOSE SCREEN
    [field: SerializeField]
        public GameObject LoseScreen { get; private set; }
    [field: SerializeField]
        public TextMeshProUGUI LoseHeader { get; private set; }
    [field: SerializeField]
        public TextMeshProUGUI LoseText { get; private set; }
}
