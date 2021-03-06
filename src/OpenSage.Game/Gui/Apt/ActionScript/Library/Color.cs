﻿using System;
using System.Collections.Generic;
using System.Linq;
using OpenSage.Mathematics;

namespace OpenSage.Gui.Apt.ActionScript.Library
{
    public sealed class Color : ObjectContext
    {
        private ColorRgba _color = ColorRgba.White;
        private readonly Dictionary<string, Action<ObjectContext, Value[]>> _builtinFunctions;

        public Color()
        {
            //list of builtin functions
            _builtinFunctions = new Dictionary<string, Action<ObjectContext, Value[]>>();
            _builtinFunctions["setRGB"] = (ObjectContext ctx, Value[] args) => { _color = ColorRgba.FromHex(_color, args.First().ToString()); };
        }

        public override bool IsBuiltInFunction(string name)
        {
            if (_builtinFunctions.ContainsKey(name))
            {
                return true;
            }

            return false;
        }

        public override void CallBuiltInFunction(string name, Value[] args)
        {
            _builtinFunctions[name](this, args);
        }
    }
}
