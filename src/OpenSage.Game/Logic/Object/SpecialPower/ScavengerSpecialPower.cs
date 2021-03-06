﻿using OpenSage.Data.Ini.Parser;

namespace OpenSage.Logic.Object
{
    [AddedIn(SageGame.Bfme)]
    public sealed class ScavengerSpecialPowerModuleData : SpecialPowerModuleData
    {
        internal static new ScavengerSpecialPowerModuleData Parse(IniParser parser) => parser.ParseBlock(FieldParseTable);

        private static new readonly IniParseTable<ScavengerSpecialPowerModuleData> FieldParseTable = SpecialPowerModuleData.FieldParseTable
            .Concat(new IniParseTable<ScavengerSpecialPowerModuleData>
            {
                { "BountyPercent", (parser, x) => x.BountyPercent = parser.ParsePercentage() }
            });

        public float BountyPercent { get; private set; }
    }
}
