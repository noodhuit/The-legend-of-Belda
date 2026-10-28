using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PurpleSparrow;

    public enum TileType
    {
        _Empty,
        _Grass,
        _Bricks,
        _Bricks_top,
        _Dirt,
        _Dirt_top,
        _Path_side,
        _Path_front,
        _dirt_end,
        _dirt_bottom,
        _bricks_bottom,
        _dirt_end_right,
        _path_tr,
        _path_tl,
        _path_br,
        _path_bl


    }
class Map
{

    private Dictionary<TileType, Texture2D> _textures;
    private int _tileSize = 32;

        private TileType[,] _map =
        {
            
            {TileType._Bricks, TileType._Grass, TileType._Grass, TileType._Grass, TileType._Grass, TileType._Bricks_top, TileType._Bricks_top, TileType._Bricks_top, TileType._Bricks_top, TileType._Bricks_top, TileType._Path_front, TileType._Bricks_top},
            {TileType._Bricks, TileType._Grass, TileType._Grass, TileType._Grass, TileType._Grass, TileType._Bricks, TileType._Bricks, TileType._Bricks, TileType._Bricks, TileType._Bricks, TileType._Path_front, TileType._Bricks},
            {TileType._Bricks, TileType._Grass, TileType._Grass, TileType._Grass, TileType._Grass, TileType._bricks_bottom, TileType._bricks_bottom, TileType._bricks_bottom, TileType._bricks_bottom, TileType._bricks_bottom, TileType._Path_front, TileType._Bricks},
            {TileType._Bricks, TileType._Path_side, TileType._Path_side, TileType._Path_side, TileType._Path_side, TileType._Path_side, TileType._Path_side, TileType._Path_side, TileType._Path_side, TileType._Path_side, TileType._Path_front, TileType._Grass},
            {TileType._Bricks, TileType._Grass, TileType._Grass, TileType._Dirt_top, TileType._Dirt_top, TileType._Dirt_top, TileType._Dirt_top, TileType._Dirt_top, TileType._Grass, TileType._Grass, TileType._Grass, TileType._Grass},
            {TileType._Bricks, TileType._Grass, TileType._Grass, TileType._Dirt, TileType._Dirt, TileType._Dirt, TileType._Dirt, TileType._Dirt, TileType._Grass, TileType._Grass, TileType._Grass, TileType._Dirt_top},
            {TileType._Empty, TileType._dirt_end, TileType._Dirt_top, TileType._Dirt, TileType._Dirt, TileType._Dirt, TileType._Dirt, TileType._Dirt, TileType._Dirt_top, TileType._Grass, TileType._Dirt_top, TileType._dirt_end_right},
            {TileType._Empty, TileType._Empty, TileType._dirt_end, TileType._Dirt, TileType._Dirt, TileType._Dirt, TileType._Dirt, TileType._Dirt, TileType._Dirt, TileType._Dirt_top, TileType._dirt_end_right, TileType._Empty},
            {TileType._Empty, TileType._Empty, TileType._Empty, TileType._dirt_end, TileType._Dirt, TileType._Dirt, TileType._Dirt, TileType._Dirt, TileType._Dirt, TileType._dirt_end_right, TileType._Empty, TileType._Empty},
        };

                public Map(
            Texture2D grass,
            Texture2D bricks,
            Texture2D bricksTop,
            Texture2D dirt,
            Texture2D dirtTop,
            Texture2D pathSide,
            Texture2D pathFront,
            Texture2D dirtend,
            Texture2D dirtbottom,
            Texture2D bricksbottom,
            Texture2D dirtendright,
            Texture2D path_tl,
            Texture2D path_tr,
            Texture2D path_br,
            Texture2D path_bl)
        {
        
            _textures = new Dictionary<TileType, Texture2D>
            {
                    { TileType._Grass, grass},
                    { TileType._Bricks, bricks},
                    { TileType._Bricks_top, bricksTop},
                    { TileType._Path_front, pathFront},
                    { TileType._Path_side, pathSide},
                    { TileType._Dirt, dirt},
                    { TileType._Dirt_top, dirtTop},
                    { TileType._dirt_end, dirtend},
                    { TileType._bricks_bottom, bricksbottom},
                    { TileType._dirt_bottom, dirtbottom},
                    { TileType._dirt_end_right, dirtendright},
                    { TileType._path_bl, path_bl},
                    { TileType._path_br, path_br},
                    { TileType._path_tl, path_tl},
                    { TileType._path_tr, path_tr}

            };
        }

            public void Draw(SpriteBatch spriteBatch, int screenWidth, int screenHeight)
            {


                int mapWidth = _map.GetLength(1) * _tileSize;
                int mapHeight = _map.GetLength(0) * _tileSize;

                int offsetX = (screenWidth - mapWidth) / 2;
                int offsetY = (screenHeight - mapHeight) / 2;

                // Go through every row in the map.
                for (int y = 0; y < _map.GetLength(0); y++)
                {
                    // Go through every column in the current row.
                    for (int x = 0; x < _map.GetLength(1); x++)
                    {
                        // Find which tile belongs at this position.
                        TileType tile = _map[y, x];

                        if (tile == TileType._Empty)
                        {
                            continue;
                        }

                        // Find the texture associated with that tile.
                        Texture2D texture = _textures[tile];

                        // Calculate the tile's position on the screen.
                        Rectangle destination = new Rectangle(
                            offsetX + x * _tileSize,
                            offsetY + y * _tileSize,
                            _tileSize,
                            _tileSize
                        );

                        // Draw the texture.
                        spriteBatch.Draw(texture, destination, Color.White);
                    }
                }
            }
}