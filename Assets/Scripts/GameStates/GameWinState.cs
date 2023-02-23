using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWinState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GameWinState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("GAME STATE: Win State");
        Debug.Log("You succeed skill check.");

        //disable scenario hud
        _controller.ScenarioHUD.SetActive(false);
        _controller.SkillCheckResult.SetActive(true);
        //set reset button to active
        _controller.ResetButton.SetActive(true);
        //_controller.WinCanvas.SetActive();
    }

    public override void Exit()
    {
        base.Exit();
        _controller.ResetButton.SetActive(false);
        
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();
        if (_controller.Input._resetPressed == true) //if reset button is pressed revert back to play state and reload the level
        {
            SceneManager.LoadScene(1);
            _stateMachine.ChangeState(_stateMachine.PlayState);
        }

        /*
        if (_controller.Input._quitPressed == true) //if quit button is pressed load back to main menu
        {
            SceneManager.LoadScene(0);
            _stateMachine.ChangeState(_stateMachine.PlayState);
        }
        */
    }
}
