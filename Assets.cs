using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Threading.Tasks;

public class SceneAsset
{
    protected float _transparency;
    protected float _rotation;
    protected Vector2 _position;

    public virtual void Draw(SpriteBatch _spriteBatch) {}

    public bool Fade(float Value, float Target, int Duration, float DeltaTime)
    {
        if(_transparency + Value < Target)
        {
            _transparency += (Value * DeltaTime);
            if(_transparency + Value > Target)
            {
                _transparency = Target;
            }
            return false;
        }
        return true;
    }
}

class Image : SceneAsset
{
    Vector2 _origin;
    Texture2D _imageSource;

    public override void Draw(SpriteBatch _spriteBatch)
    {
        _spriteBatch.Draw(_imageSource, _position, null, Color.White * _transparency, _rotation, _origin, Vector2.One, SpriteEffects.None, 0f);
    }

    public Image(Texture2D Image, Vector2 Position, float StartTransparency, float StartRotation) 
    {
        _imageSource = Image;
        _position = Position;
        _transparency = StartTransparency;
        _rotation = StartRotation;
        _origin = new Vector2(_imageSource.Width / 2, _imageSource.Height / 2);
    }

    public bool Rotate(float value, float target, int duration, float DeltaTime)
    {
        if(_rotation + value < target)
        {
            _rotation += (value * DeltaTime);
            return false;
        }
        return true;
    }
}

class Text : SceneAsset
{
    string _text;
    SpriteFont _font;

    public override void Draw(SpriteBatch _spriteBatch)
    {
        _spriteBatch.DrawString(_font, _text, _position, Color.White * _transparency);
    }

    public Text(string Text, SpriteFont Font, Vector2 Position, float StartTransparency) 
    {
        _text = Text;
        _position = Position;
        _transparency = StartTransparency;
    }
}