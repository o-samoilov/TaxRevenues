using System;
using System.Collections.Generic;

namespace GeneticAlgorithm
{
    public class Gen : ICloneable
    {
        private int _currentElementIndex = 0;
        private List<GenElement> _elements;

        public Gen(List<GenElement> elements)
        {
            _elements = elements;
        }

        public GenElement GetCurrentElement()
        {
            return _elements[_currentElementIndex];
        }
        
        public void SetElement(int index, GenElement genElement)
        {
            _elements[index] = genElement;
        }

        public void Move(int steps)
        {
            //todo check this
            _currentElementIndex = (_currentElementIndex + steps) % Size();
        }

        public int Size()
        {
            return _elements.Count;
        }

        public object Clone()
        {
            var elements = new List<GenElement>();
            foreach (var element in _elements)
            {
                elements.Add(new GenElement(element.Type, element.Name, element.Coefficient));
            }

            return new Gen(elements);
        }
        
        public override string ToString()
        {
            var result = $"Current Element Index: {_currentElementIndex}";

            var number = 1;
            foreach (var element in _elements)
            {
                result += $"{number}: {element.Name} Coefficient: {element.Coefficient}\n";
                number++;
            }

            return result;
        }
    }
}