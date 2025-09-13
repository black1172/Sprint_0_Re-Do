using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;

namespace Sprint0;

public class Game1 : Core
{
    // define sprites
    private Sprite _mario_standing;
    private AnimatedSprite _mario_running;

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
        _mario_standing = atlas.CreateSprite("mario_standing");
        _mario_standing.Scale = new Vector2(4.0f, 4.0f);

        // create the animated sprite for mario_running
        _mario_running = atlas.CreateAnimatedSprite("mario_running");
        _mario_running.Scale = new Vector2(4.0f, 4.0f);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        _mario_running.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        // Begin the sprite batch to prepare for rendering.
        SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

        // Draw Mario Standing
        _mario_standing.Draw(SpriteBatch, Vector2.One); 

        // Draw Mario Running
        _mario_running.Draw(SpriteBatch, new Vector2(_mario_standing.Width + 10, 0));

        // Always end the sprite batch when finished.
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
