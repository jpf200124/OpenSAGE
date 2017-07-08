﻿using System.Collections.Generic;
using System.IO;

namespace OpenZH.Data.Map
{
    public sealed class ObjectsList : Asset
    {
        public MapObject[] Objects { get; private set; }

        public static ObjectsList Parse(BinaryReader reader, MapParseContext context)
        {
            return ParseAsset(reader, context, version =>
            {
                var objects = new List<MapObject>();

                ParseAssets(reader, context, assetName =>
                {
                    if (assetName != "Object")
                    {
                        throw new InvalidDataException();
                    }

                    objects.Add(MapObject.Parse(reader, context));
                });

                return new ObjectsList
                {
                    Objects = objects.ToArray()
                };
            });
        }
    }
}