using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;

namespace Sprint0;

public class Game1 : Core
{
    // texture region that defines the mario sprites in the atlas.
    private TextureRegion _mario_standing;
    private TextureRegion _mario_running;

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
        
        // Create the texture atlas from the XML configuration file
        TextureAtlas atlas = TextureAtlas.FromFile(Content, "images/atlas-definition.xml");

        // retrieve the mario_standing region from the atlas.
        _mario_standing = atlas.GetRegion("mario_standing");

        // retrieve the mario_running region from the atlas.
        _mario_running = atlas.GetRegion("mario_running");
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
        SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

        // Draw the mario standing texture region 10px to the right of the mario running at a scale of 4.0
        _mario_standing.Draw(SpriteBatch, Vector2.Zero, Color.White, 0.0f, Vector2.One, 4.0f, SpriteEffects.None, 1.0f);

        // Draw the mario running texture region at a scale of 4.0
        _mario_running.Draw(SpriteBatch, new Vector2(_mario_standing.Width * 4.0f + 10, 0), Color.White, 0.0f, Vector2.One, 4.0f, SpriteEffects.None, 0.0f);

        // Always end the sprite batch when finished.
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
