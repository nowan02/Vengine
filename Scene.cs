using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Threading.Tasks;

record Event
{
    public int Duration;
    public GameTime StartingGameTime;
}

delegate bool SceneEvent();
delegate void DrawEvent();

class Scene
{
    float _deltaTime;
    SceneEvent _sceneEvent;
    DrawEvent _drawEvent;
    List<SceneEvent> _events;
    List<Image> _images;
    List<Text> _texts;
    Event _currentEvent;

    int eventCounter = 0;

    public void Update(GameTime _gameTime)
    {
        if(_events[eventCounter]())
        {
            eventCounter++;
            return;
        }
        _events[eventCounter]();
    }

    public void Draw(SpriteBatch _spriteBatch)
    {
        _drawEvent.Invoke();
    }

    private void AddDrawEvent(DrawEvent DrawFunction)
    {
        _drawEvent += DrawFunction;
    }

    private void RemoveDrawEvent(DrawEvent DrawFunction)
    {
        _drawEvent -= DrawFunction;
    }

    public Scene() {}
}