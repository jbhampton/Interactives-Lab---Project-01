using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    /*
    [field: SerializeField]
    public Unit PlayerUnitPrefab { get; private set; }
    

    [field: SerializeField]
    public Transform playerUnitSpawnLocation { get; private set; }
    

    [field: SerializeField]
    public UnitSpawner UnitSpawner { get; private set; }
    */

    [field: SerializeField]
        public InputBroadcaster Input { get; private set; }

    [field: SerializeField]
        public GameObject ScenarioHUD { get; private set; }
    
    [field: SerializeField]
        public GameObject SkillCheckResult { get; private set; }

    [field: SerializeField]
        public GameObject ResetButton { get; private set; }

    [field: SerializeField]
        public GameObject QuitButton { get; private set; }
}
