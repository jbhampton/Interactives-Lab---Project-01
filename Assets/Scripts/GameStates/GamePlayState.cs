using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    //public ScenarioBlock _currentScenario;
    public int _skillRoll;

    private int _skillMod;
    private int _athMod;
    private int _agiMod;
    private int _intMod;
    private int _chaMod;

    private int _challengeRating;

    public Text _scenarioText;

    //CONSTRUCTOR (sets variables)
    public GamePlayState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("STATE: Game Play");
        //set HUD active
        _controller.ScenarioHUD.SetActive(true); //set scenario UI to active

        //Assign the Scenarios in the Controller to the list of Possible Scenarios
        _controller.PossibleScenarios.Add(_controller.scenario1);
        _controller.PossibleScenarios.Add(_controller.scenario2);
        _controller.PossibleScenarios.Add(_controller.scenario3);
        //_controller.PossibleScenarios.Add(_controller.scenario4);
        //Randomly pick a scenario from the list of possible scenarios
        _controller._currentScenario = _controller.PossibleScenarios[Random.Range(0, _controller.PossibleScenarios.Count)];
        Debug.Log(_controller._currentScenario.scenarioHeader);
        
        //Display Scenario Text
        _controller.ScenarioHeader.text = _controller._currentScenario.scenarioHeader;
        _controller.ScenarioText.text = _controller._currentScenario.scenarioText;

        //determine challenge rating
        _challengeRating = Random.Range(8, 15);

        //determine attribute modifiers
        _athMod = _controller._currentScenario._athMod;
        _agiMod = _controller._currentScenario._agiMod;
        _intMod = _controller._currentScenario._intMod;
        _chaMod = _controller._currentScenario._chaMod;
        //display situation
    }

    public override void Exit()
    {
        //_stateMachine.WinState._winScenario = _controller._currentScenario;
        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();
        //assign chosen skill to skillRoll
        if(_controller.Input.AthCheck == true)
        {
            _skillMod = _athMod;
        } 
        else if (_controller.Input.AgiCheck == true)
        {
            _skillMod = _agiMod;
        } 
        else if (_controller.Input.IntCheck == true)
        {
            _skillMod = _intMod;
        }
        else if (_controller.Input.ChaCheck == true)
        {
            _skillMod = _chaMod;
        }

        //check if player has selected a skill to roll
        if(_controller.Input.SkillSelected == true)
        {
            _skillRoll = Random.Range(1, 20) + _skillMod; //IMPORTANT: CHANGE TO RELEVANT SKILL MOD BEFORE RELEASE
            Debug.Log("You rolled " + _skillRoll + " (+" + _skillMod + " to skill check)");
            Debug.Log("The DC was " + _challengeRating);
        }

        //check if roll is higher than CR
        if(_skillRoll >= _challengeRating && _controller.Input.SkillSelected == true)
        {
            //enter win state
            _stateMachine.ChangeState(_stateMachine.WinState);
        }

        //check if roll is lower than CR
        if (_skillRoll <= _challengeRating && _controller.Input.SkillSelected == true)
        {
            //enter lose state
            _stateMachine.ChangeState(_stateMachine.LoseState);
        }
    }
}
