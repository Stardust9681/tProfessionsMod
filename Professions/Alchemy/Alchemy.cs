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
    public class Alchemy : ProfessionPlayer
    {
        public override Color ProfessionColor => Color.LimeGreen;
        public override float ScaleMult => .3f;
        public override float MinExp => 40;
    }
}
