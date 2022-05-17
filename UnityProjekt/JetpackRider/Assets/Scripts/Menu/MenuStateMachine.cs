using UnityEngine;

namespace MainMenu 
{
    public class MenuStateMachine : StateMachine<MenuTransitions> 
    {

        [field: SerializeField] public StateHandler MainMenuHandler { get; private set; }
        [field: SerializeField] public StateHandler SelectLevelHandler { get; private set; }
        [field: SerializeField] public StateHandler SelectSpecificLevelHandler { get; private set; }


        private void Awake() 
        {

            // Main Menu -> Select Level
            AddTransition(MainMenuHandler, SelectLevelHandler, MenuTransitions.LevelSelectionSelected);

            // Select Level -> Level 1
            AddTransition(SelectLevelHandler, SelectSpecificLevelHandler, MenuTransitions.LevelSelected);

        }
    }

}