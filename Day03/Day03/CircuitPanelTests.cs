using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    public class CircuitPanelTests
    {        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MarkWire1_R8_Marks8PointsToTheRight()
        {
            var subject = new CircuitPanel();
            subject.MarkWire1("R8");
            for (int i = 1; i <= 8; i++)
            {
                subject.GetWire1().Any(t => t.Item1 == i && t.Item2 == 0).Should().BeTrue();
            }
            
        }
    }

    public class CircuitPanel
    {
        public void MarkWire1(string move)
        {
            throw new System.NotImplementedException();
        }

        public List<Tuple<int,int>> GetWire1()
        {
            throw new System.NotImplementedException();
        }
    }
}