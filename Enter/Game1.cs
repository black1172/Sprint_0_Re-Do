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

        // Draw the texture.
        SpriteBatch.Draw(
            _mario_sheet,              // texture
            new Vector2(        // position
                (Window.ClientBounds.Width * 0.5f) - (_mario_sheet.Width * 0.5f),
                (Window.ClientBounds.Height * 0.5f) - (_mario_sheet.Height * 0.5f)),
            null,               // sourceRectangle
            Color.White,        // color
            0.0f,               // rotation
            Vector2.Zero,       // origin
            1.0f,               // scale
            SpriteEffects.None, // effects
            0.0f                // layerDepth
        );

        // Always end the sprite batch when finished.
        SpriteBatch.End();


        base.Draw(gameTime);
    }
}
