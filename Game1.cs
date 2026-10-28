using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PurpleSparrow;

public class Game1 : Game
{
    private Texture2D _grass;
    private Texture2D _bricks;
    private Texture2D _bricksTop;
    private Texture2D _dirt;
    private Texture2D _dirtTop;
    private Texture2D _pathSide;
    private Texture2D _pathFront;
    private Texture2D _dirt_end;
    private Texture2D _dirt_bottom;
    private Texture2D _bricks_bottom;
    private Texture2D _dirt_end_right;
    private Texture2D _path_tl;
    private Texture2D _path_tr;
    private Texture2D _path_bl;
    private Texture2D _path_br;
    private Texture2D Backround;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D sparrowboy;
    private Texture2D sparrowboy_left;
    private Texture2D sparrowboyfront;
    private Texture2D sparrowboyback;
    public int walking;

    private Map _map;
    Sparrow _player = new Sparrow();

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);

        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.PreferredBackBufferHeight = 1080;

        _graphics.IsFullScreen = true;

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
           _player.Sparrow_position.X = 200;
           _player.Sparrow_position.Y = 600;


       base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        _grass = Content.Load<Texture2D>("Grass_Tiles");
        _bricks = Content.Load<Texture2D>("Bricks");
        _bricksTop = Content.Load<Texture2D>("Bricks_top");
        _dirt = Content.Load<Texture2D>("dirt");
        _dirtTop = Content.Load<Texture2D>("dirt_top");
        _pathSide = Content.Load<Texture2D>("Path_side");
        _pathFront = Content.Load<Texture2D>("Path_front");
        _dirt_end = Content.Load<Texture2D>("dirt island");
        _bricks_bottom = Content.Load<Texture2D>("Bricks_bottom");
        _dirt_bottom = Content.Load<Texture2D>("dirt_bottom");
        _dirt_end_right = Content.Load<Texture2D>("dirt island right");
        _path_bl = Content.Load<Texture2D>("Path_corner_bl");
        _path_br = Content.Load<Texture2D>("Path_corner_br");
        _path_tl = Content.Load<Texture2D>("Path_corner_left");
        _path_tr = Content.Load<Texture2D>("Path_corner_right");
        sparrowboy = Content.Load<Texture2D>("sparrowboy");
        sparrowboy_left = Content.Load<Texture2D>("sparrowboy(Left)");
        sparrowboyfront = Content.Load<Texture2D>("sparrow boy front");
        sparrowboyback = Content.Load<Texture2D>("sparrow boy back");
        Backround = Content.Load<Texture2D>("backround");


        _player.sparrow_pixel = sparrowboy;



        _map = new Map(
            _grass,
            _bricks,
            _bricksTop,
            _dirt,
            _dirtTop,
            _pathSide,
            _pathFront,
            _dirt_end,
            _dirt_bottom,
            _bricks_bottom,
            _dirt_end_right,
            _path_bl,
            _path_br,
            _path_tl,
            _path_tr
        );

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        KeyboardState keyboard = Keyboard.GetState();


        if (keyboard.IsKeyDown(Keys.D))
        {
            _player.Sparrow_position.X += _player.speed;
            if (_player.Sparrow_position.X > 1920 - 32)
            {
                _player.Sparrow_position.X -= _player.speed;

            }
        }

        if (keyboard.IsKeyDown(Keys.W))
        {
            _player.Sparrow_position.Y -= _player.speed;
            if (_player.Sparrow_position.Y < 0)
            {
                _player.Sparrow_position.Y += _player.speed;
            }
        }

        if (keyboard.IsKeyDown(Keys.S))
        {
            _player.Sparrow_position.Y += _player.speed;
            if (_player.Sparrow_position.Y > 1080 - 32)
            {
                _player.Sparrow_position.Y -= _player.speed;
            }
        }

        if (keyboard.IsKeyDown(Keys.A))
        {
            _player.Sparrow_position.X -= _player.speed;
            if (_player.Sparrow_position.X < 0)
            {
                _player.Sparrow_position.X += _player.speed;
            }
        }
            //else if (sparrowboy.Intersect(TileType._Bricks) && _player.speed > 0)
        //{
        //    _player.speed = 0;
        //}

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        KeyboardState keyboard = Keyboard.GetState();

        _spriteBatch.Begin();

        _spriteBatch.Draw(Backround, new Rectangle(0, 0, 1920, 1080), Color.White);

        _map.Draw(_spriteBatch, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            if(walking == 1 || keyboard.IsKeyDown(Keys.S))
            {
                _spriteBatch.Draw(sparrowboyfront, new Rectangle((int)_player.Sparrow_position.X, (int)_player.Sparrow_position.Y, 32, 32), Color.White);
                walking = 1;
            }
            
            if (keyboard.IsKeyDown(Keys.A) || walking == 2)
            {
                _spriteBatch.Draw(sparrowboy, new Rectangle((int)_player.Sparrow_position.X, (int)_player.Sparrow_position.Y, 32, 32), Color.White);
                walking = 2;
            }
            
            if (walking == 3 || keyboard.IsKeyDown(Keys.D))
            {
                _spriteBatch.Draw(sparrowboy_left, new Rectangle((int)_player.Sparrow_position.X, (int)_player.Sparrow_position.Y, 32, 32), Color.White);
                walking = 3;
            }
            
            if (walking == 4 || keyboard.IsKeyDown(Keys.W) )
            {
                _spriteBatch.Draw(sparrowboyback, new Rectangle((int)_player.Sparrow_position.X, (int)_player.Sparrow_position.Y, 32, 32), Color.White);
                walking = 4;
            }

        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
