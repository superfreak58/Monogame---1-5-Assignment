using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame___1_5
{

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Rectangle field, vikesWR1, football, window;
        Vector2 vikeSpeed, ballSpeed;
        Texture2D vikesHelmet, saintsHelmet, fieldTexture, footballTexture, touchdownTexture;
        SoundEffect commentary;
        double seconds;

        

        MouseState mouseState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            vikeSpeed = new Vector2(0, -1);
            ballSpeed = new Vector2(0, 0);
            window = new Rectangle(0, 0, 800, 500);
            vikesWR1 = new Rectangle(708, 365, 50, 50);
            football = new Rectangle(363, 345, 25, 25);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            vikesHelmet = Content.Load<Texture2D>("vikes");
            fieldTexture = Content.Load<Texture2D>("field");
            footballTexture = Content.Load<Texture2D>("football");
            commentary = Content.Load<SoundEffect>("commentary14");
            touchdownTexture = Content.Load<Texture2D>("touchdown");
        }

        protected override void Update(GameTime gameTime)
        {
            
            if (seconds <= 0)
                commentary.Play();
            mouseState = Mouse.GetState();

            this.Window.Title = $"x = {mouseState.X}, y = {mouseState.Y}";

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            vikesWR1.X += (int)vikeSpeed.X;
            vikesWR1.Y += (int)vikeSpeed.Y;
            football.X += (int)ballSpeed.X;
            football.Y += (int)ballSpeed.Y;
            if (vikesWR1.Y <= 170)
            {
               
                ballSpeed = new Vector2(4, -3);

            }
            if (vikesWR1.Top <0)
            {
                vikeSpeed = new Vector2(0, 0);

            }
            if (vikesWR1.Contains(football))
            {
                ballSpeed.X = vikeSpeed.X;
                ballSpeed.Y = vikeSpeed.Y;

            }
            if (football.Y >= 196 && football.Y<=296) 
            {
                football = new Rectangle(football.X, football.Y,50,50);
                
            }
            else 
            {
                football = new Rectangle(football.X, football.Y, 25, 25);
            }

            // TODO: Add your update logic here

            base.Update(gameTime);

            seconds += gameTime.ElapsedGameTime.TotalSeconds;
            
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            if (vikesWR1.Top < 0)
            {
                _spriteBatch.Draw(touchdownTexture, new Rectangle(0, 0, 500, 800), Color.White);

            }
            _spriteBatch.Draw(fieldTexture, window, Color.White);
            _spriteBatch.Draw(vikesHelmet, new Rectangle(361, 345, 50, 50), Color.White);
            _spriteBatch.Draw(vikesHelmet, new Rectangle(215, 288, 50, 50), Color.White);
            _spriteBatch.Draw(vikesHelmet, new Rectangle(290, 288, 50, 50), Color.White);
            _spriteBatch.Draw(vikesHelmet, new Rectangle(365, 288, 50, 50), Color.White);
            _spriteBatch.Draw(vikesHelmet, new Rectangle(440, 288, 50, 50), Color.White);
            _spriteBatch.Draw(vikesHelmet, new Rectangle(515, 288, 50, 50), Color.White);
            _spriteBatch.Draw(vikesHelmet,vikesWR1, Color.White);
            _spriteBatch.Draw(footballTexture,football, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
