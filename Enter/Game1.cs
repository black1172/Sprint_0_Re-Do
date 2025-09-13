using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;
using System;
using KeyboardController;
using MouseController;

namespace Sprint0;

public class Game1 : Core
{
    // define sprites
    private Sprite _mario_standing;
    private TextSprite _textSprite;
    private AnimatedSprite _mario_running;

    // movement and position
    private const int SCREEN_WIDTH = 1280;
    private const int SCREEN_HEIGHT = 720;
    private Vector2 _marioPosition = new Vector2(SCREEN_WIDTH / 2f, SCREEN_HEIGHT / 2f);
    private const float MOVEMENT_SPEED = 5.0f;

    // The Sprite Font reference to draw with
    SpriteFont font1;

    // Controllers
    private KeyboardController.KeyboardController _keyboardController = new KeyboardController.KeyboardController();
    private MouseController.MouseController _mouseController = new MouseController.MouseController();

    internal enum MarioState { Standing, Running, StandingUpDown, RunningLeftRight }
    internal MarioState _currentMarioState = MarioState.Standing;

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

        // Load Font
        font1 = Content.Load<SpriteFont>("images/MyMenuFont");

        // Create Text Sprite
        _textSprite = new TextSprite("Credits \nCreated by Wyatt Black \nSprites from: https://www.spriters-resource.com/nes/supermariobros/asset/50365/page-1/#comment_list", font1, Color.Black);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // Check for keyboard input
        _keyboardController.Update(this);

        // Update animated sprite
        _mario_running.Update(gameTime);

        // Check for mouse input
        _mouseController.Update(this);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // Begin the sprite batch to prepare for rendering.
        SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

        // Draw Mario Initial State
        if (_currentMarioState == MarioState.Standing)
        {
            _marioPosition = new Vector2(SCREEN_WIDTH / 2f, SCREEN_HEIGHT / 2f);
            _mario_standing.Draw(SpriteBatch, _marioPosition);
        }
        else if (_currentMarioState == MarioState.Running)
        {
            _marioPosition = new Vector2(SCREEN_WIDTH / 2f, SCREEN_HEIGHT / 2f);
            _mario_running.Draw(SpriteBatch, _marioPosition);
        }
        else if (_currentMarioState == MarioState.StandingUpDown)
        {
            // Move Mario up and down still sprite
            _marioPosition.Y += MOVEMENT_SPEED;
            _marioPosition.X = SCREEN_WIDTH / 2f;
            if (_marioPosition.Y > SCREEN_HEIGHT)
            {
                _marioPosition.Y = 0;
            }
            _mario_standing.Draw(SpriteBatch, _marioPosition);
        }
        else if (_currentMarioState == MarioState.RunningLeftRight)
        {
            // Move Mario left and right moving sprite
            _marioPosition.X += MOVEMENT_SPEED;
            _marioPosition.Y = SCREEN_HEIGHT / 2f;
            if (_marioPosition.X > SCREEN_WIDTH)
            {
                _marioPosition.X = 0;
            }
            _mario_running.Draw(SpriteBatch, _marioPosition);
        }
        // Draw text
        _textSprite.Draw(SpriteBatch, new Vector2(250, 550));

        // Always end the sprite batch when finished.
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
