using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;
namespace ProfessionsMod.Professions
{
    public abstract class ProfessionPlayer : ModPlayer
    {

        internal List<int> unknownRecipes;

        public override void Initialize()
        {
            unknownRecipes = new List<int>();
            UniqueRecipes = new Recipe[] { new Recipe(), };
            base.Initialize();
        }

        public virtual Recipe[] UniqueRecipes
        {
            get;
            private set;
        }

        /// <summary>
        /// Overriding this may cause lost data.
        /// </summary>
        /// <returns></returns>
        public override TagCompound Save()
        {
            return new TagCompound
            {
                ["unknownRecipes"] = unknownRecipes ?? new List<int>(),
                ["professionLevel"] = professionLevel,
                ["professionExp"] = professionExp,
            };
        }
        /// <summary>
        /// Overriding this may cause lost data.
        /// </summary>
        /// <returns></returns>
        public override void Load(TagCompound tag)
        {
            //unknownRecipes = tag.Get<List<Recipe>>("unknownRecipes") ?? new List<Recipe>();
            unknownRecipes = tag.GetList<int>("unknownRecipes").ToList() ?? new List<int>();
            professionLevel = tag.Get<int>("professionLevel");
            professionExp = tag.Get<int>("professionExp");
        }

        /// <summary>
        /// The colour which you desire the profession to be associated with.
        /// </summary>
        public virtual Color ProfessionColor { get { return Color.Black; } }

        /// <summary>
        /// Affects the experience needed per level according to the formula.
        /// <c>(int)(Math.Pow(professionLevel, (1+Math.Abs(ScaleMult)))*Math.Abs(MinExp));</c>
        /// such that it does not take less Experience to level up, for each level.
        /// The minimum value needed to level up can be modified with <see cref="MinExp"/>
        /// </summary>
        /// <remarks>
        /// Recommend returning a value (0, 1)
        /// </remarks>
        public virtual float ScaleMult { get { return .24f; } }

        /// <summary>
        /// Affects the experience needed per level according to the formula.
        /// <c>(int)(Math.Pow(professionLevel, (1+Math.Abs(ScaleMult)))*Math.Abs(MinExp));</c>
        /// such that it takes a minimum of this amount of Experience to level up.
        /// The way in which this scales may be modified with <see cref="ScaleMult"/>
        /// </summary>
        /// <remarks>
        /// Caution recommended when using small numbers, as it may become too easy to level up certain professions that way.
        /// </remarks>
        public virtual float MinExp { get { return 25f; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        public virtual bool CheckRecipe(Recipe recipe)
        {
            if (unknownRecipes != null)
                foreach (int i in unknownRecipes)
                    if (UniqueRecipes[i].Equals(recipe))
                        return false;
            return true;
        }

        public void LearnRecipe(Recipe recipe)
        {
            int removeAt = -1;
            if (unknownRecipes != null)
                for(int i = 0; i < unknownRecipes.Count && removeAt < 0; i++)
                {
                    if(UniqueRecipes[i].Equals(recipe))
                    {
                        removeAt = i;
                    }
                }
            if (removeAt > 0)
                unknownRecipes.RemoveAt(removeAt);
        }

        /// <returns>
        /// The total Experience for the current level, as indicated by
        /// <c>(int)(Math.Pow(professionLevel, (1+Math.Abs(ScaleMult))) * Math.Abs(MinExp))</c>
        /// </returns>
        public int GetExpCap()
        {
            return (int)(Math.Pow(professionLevel, (1+Math.Abs(ScaleMult))) * Math.Abs(MinExp));
        }

        public int professionLevel = 1;
        public int professionExp = 0;

        public bool TestLevelUp(bool quiet = true)
        {
            bool level = false;
            int expCap = GetExpCap();
            while (professionExp > expCap)
            {
                professionExp -= expCap;
                professionLevel += 1;
                level = true;
                if(!quiet)
                {
                    //TODO:
                    //Logic for level cap. Don't need players exploiting the possibilities of this mod by getting stupidly high profession levels.
                    CombatText.NewText(player.getRect(), ProfessionColor, $"{player.name}'s {GetType().Name} skill increased to {professionLevel}!");
                    for(int i = 0; i < Main.rand.Next(12); i++)
                    {
                        Dust d = Dust.NewDustDirect(player.Bottom + new Vector2(Main.rand.NextFloat(-16f, 16f), 0), 1, 1, Terraria.ID.DustID.LastPrism, 0, 0, 0, ProfessionColor, Main.rand.NextFloat(.8f, 1f));
                        d.noGravity = true;
                        d.velocity = new Vector2(0, Main.rand.NextFloat(-16f, -4f));
                    }
                }
            }
            return level;
        }
    }
}
