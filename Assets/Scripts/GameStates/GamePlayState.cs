using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    /*
    public TextMesh _situationTitle;
    public TextMesh _situationText;
    */

    private int _skillRoll;
    private int _challengeRating;

    //constructor (sets variables)
    public GamePlayState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("STATE: Game Play");
        Debug.Log("Listen for Player Inputs");
        Debug.Log("Display Player HUD");
        _controller.ScenarioHUD.SetActive(true); //set scenario UI to active
        //_controller.WinCanvas.SetActive(false); //set win screen UI to inactive

        //TO DO=================================
        //randomly select a situation
        //determine challenge rating
        _challengeRating = Random.Range(8, 10);
        // _challengeRating = Situation.challengeRating;

        //determine attribute modifiers
        //display situation
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();

        //check if player has selected a skill to roll
        if(_controller.Input.SkillSelected == true)
        {
            _skillRoll = Random.Range(1, 20);
            Debug.Log("You rolled " + _skillRoll);
            Debug.Log("The DC was " + _challengeRating);
        }

        //check if roll is higher than CR
        if(_skillRoll >= _challengeRating && _controller.Input.SkillSelected == true)
        {
            //enter win state
            Debug.Log("You succeeded your skill check.");
            _stateMachine.ChangeState(_stateMachine.WinState);
        }

        //check if roll is lower than CR
        if (_skillRoll <= _challengeRating && _controller.Input.SkillSelected == true)
        {
            //enter lose state
            Debug.Log("You failed your skill check.");
            _stateMachine.ChangeState(_stateMachine.LoseState);
        }
    }
}
