using System;
using Microsoft.Xna.Framework;

namespace MonoGameLibrary.Graphics;

public class MovingSprite : Sprite
{
    private Vector2 _velocity;
    private Vector2 _position;

    /// <summary>
    /// Gets or Sets the velocity of this moving sprite.
    /// </summary>
    public Vector2 Velocity
    {
        get => _velocity;
        set => _velocity = value;
    }

    /// <summary>
    /// Gets or Sets the position of this moving sprite.
    /// </summary>
    public Vector2 Position
    {
        get => _position;
        set => _position = value;
    }

    /// <summary>
    /// Creates a new moving sprite.
    /// </summary>
    public MovingSprite() { }

    /// <summary>
    /// Creates a new moving sprite with the specified position and velocity.
    /// </summary>
    /// <param name="position">The position of this moving sprite.</param>
    /// <param name="velocity">The velocity of this moving sprite.</param>
    public MovingSprite(Vector2 position, Vector2 velocity)
    {
        Position = position;
        Velocity = velocity;
    }

    /// <summary>
    /// Updates this moving sprite.
    /// </summary>
    /// <param name="gameTime">A snapshot of the game timing values provided by the framework.</param>
    public void Update(GameTime gameTime)
    {
        Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }
}