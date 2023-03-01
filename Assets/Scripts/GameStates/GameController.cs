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
    public ScenarioBlock scenario1 = new ScenarioBlock("Scenario 1", "This is scenario 1 Blah blah blah...",
        5, 3, 2, 1,
        "You succeeded using Athletics.", "Agi Win", "Int Win", "Cha Win",
        "Ath Lose", "Agi Lose", "Int Lose", "Cha Lose");
    public ScenarioBlock scenario2 = new ScenarioBlock("Scenario 2", "This is scenario 2 Blah blah blah...",
        5, 3, 2, 1,
        "Ath Win", "Agi Win", "Int Win", "Cha Win",
        "Ath Lose", "Agi Lose", "Int Lose", "Cha Lose");
   public ScenarioBlock scenario3 = new ScenarioBlock("Scenario 3", "This is scenario 3 Blah blah blah...",
        5, 3, 2, 1,
        "Ath Win", "Agi Win", "Int Win", "Cha Win",
        "Ath Lose", "Agi Lose", "Int Lose", "Cha Lose");
    public ScenarioBlock scenario4 = new ScenarioBlock("Scenario 4", "This is scenario 4 Blah blah blah...",
        5, 3, 2, 1,
        "Ath Win", "Agi Win", "Int Win", "Cha Win",
        "Ath Lose", "Agi Lose", "Int Lose", "Cha Lose");

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
