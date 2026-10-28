using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PurpleSparrow;

class Sparrow
{
    public int health;
    public bool sword;
    public bool HealPotion;
    public Vector2 Sparrow_position;
    public Texture2D sparrow_pixel;
    public int speed = 1;
}