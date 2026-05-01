
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalItsAlmostChristmas;
    
    public abstract class GameState
    {
        protected Game1 game1;
        protected SpriteBatch _spritebatch;

        public GameState(Game1 game1, SpriteBatch _spritebatch)
        {
            this.game1 = game1;
            this._spritebatch = _spritebatch;
        }

        public virtual void OnEnter()
        {
            
        }
        public virtual void OnExit()
        {

        }
        public virtual void LoadContent()
        {}

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
        
    }