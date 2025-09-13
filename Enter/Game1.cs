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

    // movement and position
    private Vector2 _marioPosition;
    private const float MOVEMENT_SPEED = 5.0f;

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

        // check for keyboard input
        CheckKeyboardInput();

        // check for mouse input
        CheckMouseInput();

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
        _mario_running.Draw(SpriteBatch, _marioPosition);

        // Always end the sprite batch when finished.
        SpriteBatch.End();

        base.Draw(gameTime);
    }

    private void CheckKeyboardInput()
    {
        // Get the state of keyboard input
        KeyboardState keyboardState = Keyboard.GetState();

        // If the space key is held down, the movement speed increases by 1.5
        float speed = MOVEMENT_SPEED;
        if (keyboardState.IsKeyDown(Keys.Space))
        {
            speed *= 1.5f;
        }

        // If the W or Up keys are down, move the slime up on the screen.
        if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up))
        {
            _marioPosition.Y -= speed;
        }

        // if the S or Down keys are down, move the slime down on the screen.
        if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down))
        {
            _marioPosition.Y += speed;
        }

        // If the A or Left keys are down, move the slime left on the screen.
        if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
        {
            _marioPosition.X -= speed;
        }

        // If the D or Right keys are down, move the slime right on the screen.
        if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
        {
            _marioPosition.X += speed;
        }
    }
    
    private void CheckMouseInput()
    {
        // Get the state of mouse input
        MouseState mouseState = Mouse.GetState();

        // If the left mouse button is pressed, move Mario to the mouse position
        if (mouseState.LeftButton == ButtonState.Pressed)
        {
            _marioPosition = new Vector2(mouseState.X, mouseState.Y);
        }
    }       
}
