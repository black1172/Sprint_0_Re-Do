using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;
using KeyboardController;
using MouseController;

namespace Sprint0;

public class Game1 : Core
{
    // define sprites
    private Sprite _mario_standing;
    private AnimatedSprite _mario_running;

    // movement and position
    private Vector2 _marioPosition;
    private const float MOVEMENT_SPEED = 5.0f;

    // text font
    private SpriteFont _font1;

    // graphics device manager
    private GraphicsDeviceManager _graphics;

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

        // retrieve the smallmario-standing region from the atlas.
        _mario_standing = atlas.CreateSprite("smallmario-standing");
        _mario_standing.Scale = new Vector2(4.0f, 4.0f);

        // create the animated sprite for smallmario-running
        _mario_running = atlas.CreateAnimatedSprite("small-mario-run");
        _mario_running.Scale = new Vector2(4.0f, 4.0f);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // update the animated sprite
        _mario_running.Update(gameTime);

        // TODO: Check for keyboard input
        

        // TODO: Check for mouse input
        

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // Begin the sprite batch to prepare for rendering.
        SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

        // Draw Mario Standing
        _mario_standing.Draw(SpriteBatch, Vector2.One);

        // Draw Mario Running
        _mario_running.Draw(SpriteBatch, _marioPosition);

        _font1 = Content.Load<SpriteFont>("MyMenuFont");
        Viewport viewport = _graphics.GraphicsDevice.Viewport;

        // Draw the text sprite
        TextSprite textSprite = new TextSprite("Hello, MonoGame!", _font1, Color.White);
        textSprite.Draw(SpriteBatch, new Vector2(viewport.Width / 2, viewport.Height / 2));

        // Always end the sprite batch when finished.
        SpriteBatch.End();

        base.Draw(gameTime);
    }     
}
