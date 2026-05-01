using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;    


namespace FinalItsAlmostChristmas;    
    
    public class StateManager
    {
        private static GameState _currentGameState;

        public static void Initialize(GameState initialState)
        {
            _currentGameState = initialState;
            _currentGameState?.OnEnter();
        }

        public static void SwitchState(GameState nextGameState)
        {
            _currentGameState?.OnExit();
            _currentGameState = nextGameState;
            _currentGameState?.OnEnter();
        }

        public static GameState GetCurrentState()
        {
            return _currentGameState;
        }
    }