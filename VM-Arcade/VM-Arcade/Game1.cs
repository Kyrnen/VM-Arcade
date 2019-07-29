using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;

namespace VM_Arcade {
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Texture2D newTexture;
        private Vector2 vPosition;
        private Vector2 vVelocity;
        private float vSpeed;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // TODO: Add your initialization logic here
            vPosition = new Vector2(
                graphics.PreferredBackBufferWidth / 2,
                graphics.PreferredBackBufferHeight / 2
            );
            vVelocity = Vector2.Zero;
            vSpeed = 100f;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            newTexture = this.Content.Load<Texture2D>("Sprites/V");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) {
                Exit();
            }

            vVelocity = Vector2.Zero;

            // TODO: Add your update logic here
            KeyboardState kState = Keyboard.GetState();
            if (kState.IsKeyDown(Keys.W) || kState.IsKeyDown(Keys.Up)) {
                vVelocity.Y -= 1;
            }
            if (kState.IsKeyDown(Keys.S) || kState.IsKeyDown(Keys.Down)) {
                vVelocity.Y += 1;
            }
            if (kState.IsKeyDown(Keys.A) || kState.IsKeyDown(Keys.Left)) {
                vVelocity.X -= 1;
            }
            if (kState.IsKeyDown(Keys.D) || kState.IsKeyDown(Keys.Right)) {
                vVelocity.X += 1;
            }

            if (vVelocity.Length() > 1) {
                vVelocity.Normalize();
            }
            vVelocity *= vSpeed;

            vPosition += vVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(newTexture, new Vector2(0, 0), Color.DarkOliveGreen);
            spriteBatch.Draw(
                newTexture,
                vPosition,
                sourceRectangle: null,
                color: Color.White,
                rotation: 0,
                origin: new Vector2(newTexture.Width / 2, newTexture.Height / 2),
                scale: 0.5f,
                effects: SpriteEffects.None,
                layerDepth: 0f
            );
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
