using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLoseState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public ScenarioBlock _loseScenario;

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

        //set scenario
        _loseScenario = _controller._currentScenario;

        //set reset button to active
        _controller.ScenarioHUD.SetActive(false);
        _controller.LoseScreen.SetActive(true);

        //set reset button to active
        _controller.ResetButton.SetActive(true);

        //SET WIN TEXT
        if (_controller.Input.AthCheck == true)
        {
            _controller.LoseText.text = _loseScenario._athLose;
        }
        else if (_controller.Input.AgiCheck == true)
        {
            _controller.LoseText.text = _loseScenario._agiLose;
        }
        else if (_controller.Input.IntCheck == true)
        {
            _controller.LoseText.text = _loseScenario._intLose;
        }
        else if (_controller.Input.ChaCheck == true)
        {
            _controller.LoseText.text = _loseScenario._chaLose;
        }
    }

    public override void Exit()
    {
        _controller.LoseScreen.SetActive(false); //set lose screen UI to inactive
        _controller.ResetButton.SetActive(false);
        base.Exit();
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
