﻿#region

using LoESoft.Core;
using LoESoft.GameServer.logic.loot;
using LoESoft.GameServer.realm.terrain;

#endregion

namespace LoESoft.GameServer.realm.mapsetpiece
{
    internal abstract class Temple : MapSetPiece
    {
        protected static readonly string DarkGrass = "Dark Grass";
        protected static readonly string Floor = "Jungle Temple Floor";
        protected static readonly string WallA = "Jungle Temple Bricks";
        protected static readonly string WallB = "Jungle Temple Walls";
        protected static readonly string WallC = "Jungle Temple Column";
        protected static readonly string Flower = "Jungle Ground Flowers";
        protected static readonly string Grass = "Jungle Grass";
        protected static readonly string Tree = "Jungle Tree Big";

        protected static readonly Loot chest = new Loot(
            new TierLoot(4, ItemType.Weapon, BagType.None),
            new TierLoot(5, ItemType.Weapon, BagType.None),
            new TierLoot(4, ItemType.Armor, BagType.None),
            new TierLoot(5, ItemType.Armor, BagType.None),
            new TierLoot(1, ItemType.Ability, BagType.None),
            new TierLoot(2, ItemType.Ability, BagType.None),
            new TierLoot(2, ItemType.Ring, BagType.None),
            new TierLoot(3, ItemType.Ring, BagType.None),
            new TierLoot(1, ItemType.Potion, BagType.None),
            new TierLoot(1, ItemType.Potion, BagType.None),
            new TierLoot(1, ItemType.Potion, BagType.None)
            );

        protected static void Render(Temple temple, World world, IntPoint pos, int[,] ground, int[,] objs)
        {
            EmbeddedData dat = GameServer.Manager.GameData;
            for (int x = 0; x < temple.Size; x++) //Rendering
                for (int y = 0; y < temple.Size; y++)
                {
                    if (ground[x, y] == 1)
                    {
                        WmapTile tile = world.Map[x + pos.X, y + pos.Y].Clone();
                        tile.TileId = dat.IdToTileType[DarkGrass];
                        tile.ObjType = 0;
                        world.Map[x + pos.X, y + pos.Y] = tile;
                    }
                    else if (ground[x, y] == 2)
                    {
                        WmapTile tile = world.Map[x + pos.X, y + pos.Y].Clone();
                        tile.TileId = dat.IdToTileType[Floor];
                        tile.ObjType = 0;
                        world.Map[x + pos.X, y + pos.Y] = tile;
                    }

                    if (objs[x, y] == 1)
                    {
                        WmapTile tile = world.Map[x + pos.X, y + pos.Y].Clone();
                        tile.ObjType = dat.IdToObjectType[WallA];
                        if (tile.ObjId == 0)
                            tile.ObjId = world.GetNextEntityId();
                        world.Map[x + pos.X, y + pos.Y] = tile;
                    }
                    else if (objs[x, y] == 2)
                    {
                        WmapTile tile = world.Map[x + pos.X, y + pos.Y].Clone();
                        tile.ObjType = dat.IdToObjectType[WallB];
                        if (tile.ObjId == 0)
                            tile.ObjId = world.GetNextEntityId();
                        world.Map[x + pos.X, y + pos.Y] = tile;
                    }
                    else if (objs[x, y] == 3)
                    {
                        WmapTile tile = world.Map[x + pos.X, y + pos.Y].Clone();
                        tile.ObjType = dat.IdToObjectType[WallC];
                        if (tile.ObjId == 0)
                            tile.ObjId = world.GetNextEntityId();
                        world.Map[x + pos.X, y + pos.Y] = tile;
                    }
                    else if (objs[x, y] == 4)
                    {
                        WmapTile tile = world.Map[x + pos.X, y + pos.Y].Clone();
                        tile.ObjType = dat.IdToObjectType[Flower];
                        if (tile.ObjId == 0)
                            tile.ObjId = world.GetNextEntityId();
                        world.Map[x + pos.X, y + pos.Y] = tile;
                    }
                    else if (objs[x, y] == 5)
                    {
                        WmapTile tile = world.Map[x + pos.X, y + pos.Y].Clone();
                        tile.ObjType = dat.IdToObjectType[Grass];
                        if (tile.ObjId == 0)
                            tile.ObjId = world.GetNextEntityId();
                        world.Map[x + pos.X, y + pos.Y] = tile;
                    }
                    else if (objs[x, y] == 6)
                    {
                        WmapTile tile = world.Map[x + pos.X, y + pos.Y].Clone();
                        tile.ObjType = dat.IdToObjectType[Tree];
                        if (tile.ObjId == 0)
                            tile.ObjId = world.GetNextEntityId();
                        world.Map[x + pos.X, y + pos.Y] = tile;
                    }
                }
        }
    }
}