﻿using LeagueToolkit.IO.PropertyBin;
using LeagueToolkit.IO.PropertyBin.Properties;

namespace LeagueBulkConvert.Conversion
{
    class Material
    {
        public ulong Hash { get; set; }

        public bool IsComplete
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Texture))
                    return false;
                return true;
            }
        }

        public string Name { get; set; }

        public string Texture { get; set; }

        public void Complete(BinTreeObject treeObject)
        {
            if (Utils.FindTexture(treeObject, out var texture))
                Texture = texture;
        }

        public Material(BinTreeProperty materialProperty, BinTreeProperty submeshProperty, BinTreeProperty textureProperty)
        {
            if (materialProperty != null)
                Hash = ((BinTreeObjectLink)materialProperty).Value;
            if (submeshProperty != null)
                Name = ((BinTreeString)submeshProperty).Value.ToLower().Replace('/', '\\');
            if (textureProperty != null)
                Texture = ((BinTreeString)textureProperty).Value.ToLower().Replace('/', '\\');
        }
    }
}
