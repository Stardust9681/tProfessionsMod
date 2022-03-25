using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ProfessionsMod.Professions
{
    public class CraftingItem : GlobalItem
    {
        //Item ID, Level Requirement, Experience gain for using
        //Max alchemy level = 5 (10?)

        public static (int, int, float)[] AlchemyReqs =
        {
            //Possible Ingredient Additions:
            //[2, 1] Fish Oil (3 Bass at Bottle): Used in some potions
            //[3, 1.5] Specular Oil (2 Specular Fish at Bottle): Used in some potions
            //[5, 2.5] Prismatic Oil (1 Prismite at Bottle): Used in some potions

            //Possible Potion Additions:
            //Elixer of Minor Defence (Fish Oil + Blinkroot): +3 def
            //Elixer of Minor Rejuvination (Fish Oil + Daybloom): +1 regen
            //Elixer of Minor Speed (Fish Oil + Moonglow): +10% movespeed
            //Elixer of Lion's Strength (Specular Oil + Deathweed*2): +5% damage
            //Elixer of Troll's Blood (Specular Oil + Daybloom*2 + Moonglow*2): +2 regen, +2 mana regen
            //Elixer of Restoration (Specular Oil + Pink Gel + Glowing Mushroom*5): +80 hp, +40 mp
            //Elixer of Fire Power (Specular Oil + Obsidian + Fire Blossom*3): +6% crit, +4% damage
            //Elixer of Displacement (Prismatic Oil + Specular Oil + Chaos Fish): Chance when hit to ignore damage, and teleport to a nearby position. -5 iv frames
            //Elixer of Elune (Prismatic Oil + Moonglow*3 + Glowing Mushroom*5): +5% various stats at night
            //Elixer of Eonar (Prismatic Oil + Daybloom*3 + Fire Blossom*3 + Flarefin Koi): +5% various stats at day
            //Elixer of Unspoken Knowledge (Prismatic Oil + Daybloom + Moonglow + Blinkroot): +15% crit, +5% DR
            //Cauldron of Troll's Blood (Empty Bucket + Elixer of Troll's Blood*10): Elixer of Troll's Blood (30 uses)
            //Cauldron of Lion's Strength (Empty Bucket + Elixer of Lion's Strength*10): Elixer of Lion's Strength (30 uses)
            //Cauldron of Fire Power (Empty Bucket + Elixer of Fire Power*10): Elixer of Fire Power (30 uses)
            //Cauldron ...


            //Lv1:
            (ItemID.Bottle, 1, 1f),
            (ItemID.BottledWater, 1, 1f),
            (ItemID.Daybloom, 1, 1f),
            (ItemID.Moonglow, 1, 1f),
            (ItemID.Blinkroot, 1, 1f),
            (ItemID.Waterleaf, 1, 1f),
            (ItemID.Gel, 1, 1f),
            (ItemID.Mushroom, 1, 1f),
            (ItemID.PinkGel, 1, 1f),
            (ItemID.Coral, 1, 1f),

            //Lv2:
            (ItemID.Shiverthorn, 2, 2f),
            (ItemID.Cactus, 2, 2f),
            (ItemID.GlowingMushroom, 2, 2f),
            (ItemID.LeadOre, 2, 2f),
            (ItemID.IronOre, 2, 2f),
            (ItemID.PlatinumOre, 2, 2f),
            (ItemID.GoldOre, 2, 2f),
            (ItemID.Feather, 2, 2f),
            (ItemID.Lens, 2, 2f),

            //Lv3:
            (ItemID.Deathweed, 3, 3f),
            (ItemID.Fireblossom, 3, 3f),
            (ItemID.Obsidian, 3, 3f),
            (ItemID.Cobweb, 3, 3f),
            (ItemID.Goldfish, 3, 3f),
            (ItemID.WormTooth, 3, 3f),
            (ItemID.AntlionMandible, 3, 3f),
            (ItemID.Bone, 3, 3f),

            //Lv4:
            (ItemID.ArmoredCavefish, 4, 4f),
            (ItemID.Ebonkoi, 4, 4f),
            (ItemID.DoubleCod, 4, 4f),
            (ItemID.SpecularFish, 4, 4f),
            (ItemID.FrostMinnow, 4, 4f),
            (ItemID.SharkFin, 4, 4f),

            //Lv5:
            (ItemID.CrimsonTigerfish, 5, 5f),
            (ItemID.Hemopiranha, 5, 5f),
            (ItemID.Damselfish, 5, 5f),
            (ItemID.Obsidifish, 5, 5f),
            (ItemID.FlarefinKoi, 5, 5f),
            (ItemID.ChaosFish, 5, 5f),
            (ItemID.PrincessFish, 5, 5f),

            //Lv6:
            (ItemID.PixieDust, 6, 6f),
            (ItemID.UnicornHorn, 6, 6f),
            (ItemID.Prismite, 6, 6f),
            (ItemID.CrystalShard, 6, 6f),

            //Lv7:
            (ItemID.FragmentSolar, 7, 7f),
            (ItemID.FragmentVortex, 7, 7f),
            (ItemID.FragmentStardust, 7, 7f),
            (ItemID.FragmentNebula, 7, 7f),
        };

        public static (int, int, float)[] CookingReqs = new (int, int, float)[]
        {
            //Lv1:
            (ItemID.Bass, 1, 1f),
            (ItemID.AtlanticCod, 1, 2f),

            //Lv2:
            (ItemID.Goldfish, 2, 2f),
            (ItemID.Mushroom, 2, .5f),
            (ItemID.Bowl, 2, 0f),

            //Lv3:
            (ItemID.Pumpkin, 3, 3f),
        };

        public static (int, int, float)[] BlacksmithingReqs = new (int, int, float)[]
        {
            //Lv1:
            (ItemID.CopperBar, 1, 1f),
            (ItemID.TinBar, 1, 1f),
            (ItemID.IronBar, 1, 1f),
            (ItemID.LeadBar, 1, 1f),
            (ItemID.Amethyst, 1, 1f),
            (ItemID.Topaz, 1, 1f),

            //Lv2:
            (ItemID.SilverBar, 2, 2f),
            (ItemID.TungstenBar, 2, 2f),
            (ItemID.GoldBar, 2, 2f),
            (ItemID.PlatinumBar, 2, 2f),
            (ItemID.DesertFossil, 2, 2f),
            (ItemID.Sapphire, 2, 2f),
            (ItemID.Emerald, 2, 2f),
            (ItemID.Amber, 2, 2f),

            //Lv3:
            (ItemID.DemoniteBar, 3, 3f),
            (ItemID.CrimtaneBar, 3, 3f),
            (ItemID.HellstoneBar, 3, 3f),
            (ItemID.MeteoriteBar, 3, 3f),
            (ItemID.Ruby, 3, 3f),
            (ItemID.Diamond, 3, 3f),

            //Lv4:
            (ItemID.CobaltBar, 4, 4f),
            (ItemID.PalladiumBar, 4, 4f),
            (ItemID.MythrilBar, 4, 4f),
            (ItemID.CrystalShard, 4, 4f),
            (ItemID.SoulofFlight, 4, 4f),
            (ItemID.SoulofLight, 4, 4f),
            (ItemID.SoulofNight, 4, 4f),

            //Lv5:
            (ItemID.OrichalcumBar, 5, 5f),
            (ItemID.AdamantiteBar, 5, 5f),
            (ItemID.TitaniumBar, 5, 5f),
            (ItemID.SoulofMight, 5, 5f),
            (ItemID.SoulofSight, 5, 5f),
            (ItemID.SoulofFright, 5, 5f),

            //Lv6:
            (ItemID.HallowedBar, 6, 6f),
            (ItemID.ChlorophyteBar, 6, 6f),
            (ItemID.TurtleShell, 6, 6f),
            (ItemID.Ectoplasm, 6, 6f),

            //Lv7:
            (ItemID.SpectreBar, 7, 7f),
            (ItemID.ShroomiteBar, 7, 7f),
            (ItemID.BeetleHusk, 7, 7f),

            //Lv8:
            (ItemID.LunarBar, 8, 8f),
            (ItemID.FragmentSolar, 8, 8f),
            (ItemID.FragmentNebula, 8, 8f),
            (ItemID.FragmentVortex, 8, 8f),
            (ItemID.FragmentStardust, 8, 8f),
        };

        public override void OnCraft(Item item, Recipe recipe)
        {
            //Assume List<int> ingredients is an accurate representation of all ingredients needs for a recipe
            Player player = Main.LocalPlayer;
            Alchemy alchPlayer = player.GetModPlayer<Alchemy>();
            Cooking cookPlayer = player.GetModPlayer<Cooking>();
            Blacksmithing forgePlayer = player.GetModPlayer<Blacksmithing>();
            float inc = 0;
            List<int> ingredients = new List<int>();
            ProfessionRecipe pRecipe = new ProfessionRecipe(recipe);
            switch(pRecipe.recipeType)
            {
                case ProfessionID.Alchemy:
                    pRecipe.OnCraft(alchPlayer);
                    break;
                case ProfessionID.Cooking:
                    pRecipe.OnCraft(cookPlayer);
                    break;
                case ProfessionID.Blacksmithing:
                    pRecipe.OnCraft(forgePlayer);
                    break;
                default:
                    break;
            }
            
            /*foreach(Item it in recipe.requiredItem)
            {
                ingredients.Add(it.type);
            }
            if (recipe.alchemy)
            {

                bool duplicate = (Main.rand.NextFloat() < (alchPlayer.professionLevel * .01f) && alchPlayer.professionLevel > 2);
                for (int i = 0; i < AlchemyReqs.Length; i++)
                {
                    if (ingredients.Contains(AlchemyReqs[i].Item1))
                    {
                        inc += AlchemyReqs[i].Item3;
                        if (duplicate)
                            inc += AlchemyReqs[i].Item3;
                    }
                }
                if (duplicate)
                {
                    Item craftItem = Main.mouseItem;
                    if (craftItem.stack < craftItem.maxStack)
                        Main.mouseItem.stack += 1;
                    else
                        player.QuickSpawnItem(item.type);
                }
                alchPlayer.professionExp += (int)inc;
                alchPlayer.TestLevelUp(false);
            }*/
            base.OnCraft(item, recipe);
        }

        public override bool OnPickup(Item item, Player player)
        {
            Alchemy alchPlayer = player.GetModPlayer<Alchemy>();

            //Transmutation of lower currency into higher
            if(alchPlayer.professionLevel > 5)
            {
                if(item.rare < 5 && item.rare > 0 && item.value > 5)
                {
                    if (Main.rand.NextFloat() < .15f / (item.rare * 10f))
                    {
                        int v = item.value / 5;
                        item = new Item();
                        if (v > 1000000)
                        {
                            item.CloneDefaults(ItemID.PlatinumCoin);
                            item.stack = v / 1000000;
                        }
                        else if (v > 10000)
                        {
                            item.CloneDefaults(ItemID.GoldCoin);
                            item.stack = v / 10000;
                        }
                        if (v > 100)
                        {
                            item.CloneDefaults(ItemID.SilverCoin);
                            item.stack = v / 100;
                        }
                        else
                        {
                            item.CloneDefaults(ItemID.CopperCoin);
                            item.stack = v;
                        }
                    }
                }
            }
            return base.OnPickup(item, player);
        }
    }
    public class CraftingRecipe : GlobalRecipe
    {
        public override bool RecipeAvailable(Recipe recipe)
        {
            //Assume List<int> ingredients is an accurate representation of all ingredients needs for a recipe
            Player player = Main.LocalPlayer;
            Alchemy alchPlayer = player.GetModPlayer<Alchemy>();
            Cooking cookPlayer = player.GetModPlayer<Cooking>();
            Blacksmithing forgePlayer = player.GetModPlayer<Blacksmithing>();
            ProfessionRecipe pRecipe = new ProfessionRecipe(recipe);

            /*
            List<int> ingredients = new List<int>();
            foreach (Item it in recipe.requiredItem)
            {
                ingredients.Add(it.type);
            }
            if (recipe.alchemy)
            {
                for (int i = 0; i < CraftingItem.AlchemyReqs.Length; i++)
                {
                    if (ingredients.Contains(CraftingItem.AlchemyReqs[i].Item1))
                        if (alchPlayer.professionLevel < CraftingItem.AlchemyReqs[i].Item2)
                            return false;
                }
            }
            */

            switch (pRecipe.recipeType)
            {
                case ProfessionID.Alchemy:
                    return base.RecipeAvailable(recipe) && pRecipe.RecipeAvailable(alchPlayer);
                case ProfessionID.Cooking:
                    return base.RecipeAvailable(recipe) && pRecipe.RecipeAvailable(cookPlayer);
                case ProfessionID.Blacksmithing:
                    return base.RecipeAvailable(recipe) && pRecipe.RecipeAvailable(forgePlayer);
                default:
                    return base.RecipeAvailable(recipe);
            }
        }
    }
    public class ProfessionRecipe
    {
        public int recipeType;
        public float expYield;
        public int reqLevel;
        public Recipe baseRecipe;
        public ProfessionRecipe(Recipe recipe)
        {
            baseRecipe = recipe;
            List<int> tiles = recipe.requiredTile.ToList();
            Item result = recipe.createItem;
            (int, int, float)[] array = CraftingItem.AlchemyReqs;
            if (recipe.alchemy)
            {
                recipeType = ProfessionID.Alchemy;
                array = CraftingItem.AlchemyReqs;
            }
            //Required Tiles includes Cooking Pot or Furnace and the output is consumeable, with 0 damage
            if((tiles.Contains(TileID.CookingPots) || tiles.Contains(TileID.Furnaces)) && result.consumable && result.damage == 0)
            {
                recipeType = ProfessionID.Cooking;
                array = CraftingItem.CookingReqs;
            }
            if(tiles.Contains(TileID.Anvils) || tiles.Contains(TileID.MythrilAnvil) || tiles.Contains(TileID.LunarCraftingStation))
            {
                recipeType = ProfessionID.Blacksmithing;
                array = CraftingItem.BlacksmithingReqs;
            }
            foreach(Item i in recipe.requiredItem)
            {
                foreach((int, int, float) t in array)
                {
                    if(i.type == t.Item1)
                    {
                        expYield += t.Item3;
                        if(t.Item2 > reqLevel)
                        {
                            reqLevel = t.Item2;
                        }
                    }
                }
            }
        }
        public bool RecipeAvailable(ProfessionPlayer player)
        {
            return (player.professionLevel >= reqLevel && player.CheckRecipe(baseRecipe));
        }
        public void OnCraft(ProfessionPlayer player)
        {
            player.professionExp += (int)expYield;
            //Main.NewText(player.player.name + " is at level " + player.professionLevel + ": [" + player.professionExp + "/" + player.GetExpCap() + "]. This recipe added " + (int)expYield + ".");
            player.TestLevelUp(false);
        }
    }
    public static class ProfessionID
    {
        public const int Alchemy = 1;
        public const int Cooking = 2;
        public const int Blacksmithing = 3;
    }
}
