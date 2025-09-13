using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;

namespace Sprint0;

public class Game1 : Core
{
    // The Mario texture sheet
    private Texture2D _mario_sheet;

    public Game1() : base("Sprint 0", 1280, 720, false)
    {

    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        // TODO: use this.Content to load your game content here
        _mario_sheet = Content.Load<Texture2D>("images/mario_sheet");
        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        // Begin the sprite batch to prepare for rendering.
        SpriteBatch.Begin();

        // first mario texture is at (0, 8) and is 16x16
        // second mario texture is at (21, 8) and is 16x16

        // The bounds of the icon within the texture.
        Rectangle standing_mario = new Rectangle(0, 8, 16, 16);

        // The bounds of the word mark within the texture.
        Rectangle first_step_mario = new Rectangle(21, 8, 16, 16);

        // Draw only the icon portion of the texture.
    SpriteBatch.Draw(
        _mario_sheet,              // texture
        new Vector2(        // position
            Window.ClientBounds.Width,
            Window.ClientBounds.Height) * 0.5f,
        standing_mario,     // sourceRectangle
        Color.White,        // color
        0.0f,               // rotation
        new Vector2(        // origin
            standing_mario.Width,
            standing_mario.Height) * 0.5f,
        1.0f,               // scale
        SpriteEffects.None, // effects
        0.0f                // layerDepth
    );

    // Draw only the word mark portion of the texture.
    SpriteBatch.Draw(
        _mario_sheet,              // texture
        new Vector2(        // position
          Window.ClientBounds.Width,
          Window.ClientBounds.Height) * 0.5f,
        first_step_mario, // sourceRectangle
        Color.White,        // color
        0.0f,               // rotation
        new Vector2(        // origin
          first_step_mario.Width,
          first_step_mario.Height) * 0.5f,
        1.0f,               // scale
        SpriteEffects.None, // effects
        0.0f                // layerDepth
    );


        // Always end the sprite batch when finished.
        SpriteBatch.End();


        base.Draw(gameTime);
    }
}
