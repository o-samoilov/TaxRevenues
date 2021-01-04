using System;
using UnityEngine;

namespace GeneticAlgorithm
{
    public class Dnk : ICloneable
    {
        public Color Color { get; set; }
        public Color ParentColor { get; set; }
        
        public Gen MainGen { get; }

        public Dnk(Gen mainGen, Color color, Color parentColor)
        {
            MainGen = mainGen;
            Color = color;
            ParentColor = parentColor;
        }

        public object Clone()
        {
            var color = new Color(Color.r, Color.g, Color.b);
            var parentColor = new Color(ParentColor.r, ParentColor.g, ParentColor.b);
            
            return new Dnk((Gen)MainGen.Clone(), color, parentColor);
        }
    }
}