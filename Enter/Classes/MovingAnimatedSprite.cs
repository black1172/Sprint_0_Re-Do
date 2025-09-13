using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameLibrary.Graphics;

public class MovingAnimatedSprite : AnimatedSprite
{
    public Vector2 Position { get; set; }
    public Vector2 Velocity { get; set; }

    public MovingAnimatedSprite() { }

    public MovingAnimatedSprite(Animation animation, Vector2 position, Vector2 velocity)
        : base(animation)
    {
        Position = position;
        Velocity = velocity;
    }

    public void Update(GameTime gameTime)
    {
        // Move the sprite
        Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Update animation frame
        base.Update(gameTime);
    }
}