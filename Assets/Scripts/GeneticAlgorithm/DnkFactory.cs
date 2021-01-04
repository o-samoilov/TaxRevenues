using UnityEngine;

namespace GeneticAlgorithm
{
    public class DnkFactory
    {
        public Dnk CreateRandom()
        {
            return new Dnk(
                (new GenFactory()).CreateRandom(),
                CreateRandomDnkColor(),
                Color.black
            );
        }

        public Color CreateRandomDnkColor()
        {
            var r = Random.Range(0.0f, 1.0f);
            var g = Random.Range(0.0f, 1.0f);
            var b = Random.Range(0.0f, 1.0f);

            return new Color(r, g, b);
        }
    }
}