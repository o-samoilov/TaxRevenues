using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GeneticAlgorithm
{
    public class Dnk : ICloneable
    {
        public Color Color { get; private set; }
        public Color ParentColor { get; private set; }
        
        public Gen MainGen { get; }

        private DnkFactory _dnkFactory = new DnkFactory();
        private GenElementFactory _genElementFactory = new GenElementFactory();

        public Dnk(Gen mainGen, Color color, Color parentColor)
        {
            MainGen = mainGen;
            Color = color;
            ParentColor = parentColor;
        }

        public void Mutate()
        {
            var countMutations = Random.Range(1, 4);

            for (var i = 0; i < countMutations; i++)
            {
                var index = Random.Range(0, MainGen.Size());
                MainGen.SetElement(index, _genElementFactory.CreateRandom());

                ParentColor = Color;
                Color = _dnkFactory.CreateRandomDnkColor();
            }
        }

        public object Clone()
        {
            var color = new Color(Color.r, Color.g, Color.b);
            var parentColor = new Color(ParentColor.r, ParentColor.g, ParentColor.b);
            
            return new Dnk((Gen)MainGen.Clone(), color, parentColor);
        }
    }
}