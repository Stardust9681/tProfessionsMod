using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;

namespace ProfessionsMod.Professions
{
    public class Blacksmithing : ProfessionPlayer
    {
        public override Color ProfessionColor => Color.Yellow;
        public override float ScaleMult => .1f;
        public override float MinExp => 10;
    }
}
