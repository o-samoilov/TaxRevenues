using UnityEngine;

namespace GeneticAlgorithm
{
    public class DnkFactory
    {
        private Random _random = new Random();

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

            Debug.Log($"R: {r} G: {g} B: {b}");

            return new Color(r, g, b);
        }
    }
}