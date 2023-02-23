using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLoseState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GameLoseState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("GAME STATE: Lose State");
        Debug.Log("You fail your skill check.");

        //set reset button to active
        _controller.ScenarioHUD.SetActive(false);
        _controller.SkillCheckResult.SetActive(true);
        //set reset button to active
        _controller.ResetButton.SetActive(true);
        //_controller.WinCanvas.SetActive(true);
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
        if (_controller.Input._resetPressed == true)
        {
            SceneManager.LoadScene(1);
            _stateMachine.ChangeState(_stateMachine.PlayState);
        }
        
        /*
        if (_controller.Input._quitPressed == true)
        {
            SceneManager.LoadScene(0);
            _stateMachine.ChangeState(_stateMachine.PlayState);
        }
        */
    }
}
