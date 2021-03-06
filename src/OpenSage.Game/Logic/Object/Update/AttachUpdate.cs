﻿using OpenSage.Data.Ini;
using OpenSage.Data.Ini.Parser;

namespace OpenSage.Logic.Object
{
    [AddedIn(SageGame.Bfme2)]
    public sealed class AttachUpdateModuleData : UpdateModuleData
    {
        internal static AttachUpdateModuleData Parse(IniParser parser) => parser.ParseBlock(FieldParseTable);

        private static readonly IniParseTable<AttachUpdateModuleData> FieldParseTable = new IniParseTable<AttachUpdateModuleData>
        {
            { "ObjectFilter", (parser, x) => x.ObjectFilter = ObjectFilter.Parse(parser) },
            { "ScanRange", (parser, x) => x.ScanRange = parser.ParseInteger() },
            { "AlwaysTeleport", (parser, x) => x.AlwaysTeleport = parser.ParseBoolean() },
            { "AnchorToTopOfGeometry", (parser, x) => x.AnchorToTopOfGeometry = parser.ParseBoolean() }
        };

        public ObjectFilter ObjectFilter { get; private set; }
        public int ScanRange { get; private set; }

        [AddedIn(SageGame.Bfme2Rotwk)]
        public bool AlwaysTeleport { get; private set; }

        [AddedIn(SageGame.Bfme2Rotwk)]
        public bool AnchorToTopOfGeometry { get; private set; }
    }
}
