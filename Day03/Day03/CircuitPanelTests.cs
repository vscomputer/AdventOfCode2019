using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Day03
{
    public class CircuitPanelTests
    {
        private CircuitPanel _subject;
        [SetUp]
        public void Setup()
        {
            _subject = new CircuitPanel();
        }

        [Test]
        public void MarkWire1_R8_Marks8PointsToTheRight()
        {
            _subject.MarkWire1("R8");
            for (int i = 1; i <= 8; i++)
            {
                _subject.GetWire1().Any(t => t.Item1 == i && t.Item2 == 0).Should().BeTrue();
            }            
        }

        [Test]
        public void MarkWire1_U5AfterR8_Marks5Points8ToTheRight()
        {
            _subject.MarkWire1("R8");
            _subject.MarkWire1("U5");
            for (int i = -1; i >= -5; i--)
            {
                _subject.GetWire1().Any(t => t.Item1 == 8 && t.Item2 == i).Should().BeTrue();
            }
        }

        
        
    }

    public class CircuitPanel
    {
        private List<Tuple<int, int>> _wire1;
        private Tuple<int, int> _currentPosition;

        public CircuitPanel()
        {
            _wire1 = new List<Tuple<int, int>>();
            _currentPosition = new Tuple<int, int>(0,0);
        }
        
        public void MarkWire1(string move)
        {
            var x = _currentPosition.Item1;
            var y = _currentPosition.Item2;
            char direction = move[0];
            int steps = int.Parse(move.Substring(1));
            switch (direction)
            {
                case 'R':
                    for (int i = 1; i <= steps; i++)
                    {
                        _wire1.Add(new Tuple<int, int>(x+i, y));
                    }                    
                    break;
                case 'U':
                    for (int i = 1; i <= steps; i++)
                    {
                        _wire1.Add(new Tuple<int, int>(x, y-i));
                    }
                    break;
                default:
                    throw new ArgumentException("that direction isn't supported!");
            }
            _currentPosition = _wire1.Last();
            
        }

        public List<Tuple<int,int>> GetWire1()
        {
            return _wire1;
        }
    }
}