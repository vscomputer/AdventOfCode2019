using System;
using System.Collections.Generic;
using System.Linq;

namespace Day03
{
    public class CircuitPanel
    {
        private readonly List<Tuple<int, int>> _wire1;
        private readonly List<Tuple<int, int>> _wire2;
        private readonly List<Tuple<int, int>> _intersections;
        private Tuple<int, int> _currentPosition;


        public CircuitPanel()
        {
            _wire1 = new List<Tuple<int, int>>();
            _wire2 = new List<Tuple<int, int>>();
            _intersections = new List<Tuple<int, int>>();
            _currentPosition = new Tuple<int, int>(0, 0);
        }

        public List<Tuple<int, int>> GetIntersections()
        {
            return _intersections;
        }

        public void MarkWire1(string wireMoves)
        {
            _currentPosition = new Tuple<int, int>(0,0);
            foreach (var move in wireMoves.Split(','))
            {
                MarkWire1Step(move);
            }            
        }
        
        public void MarkWire2(string wireMoves)
        {
            _currentPosition = new Tuple<int, int>(0,0);
            foreach (var move in wireMoves.Split(','))
            {
                MarkWire2Step(move);
            }            
        }

        private void MarkWire1Step(string move)
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
                case 'L':
                    for (int i = 0; i <= steps; i++)
                    {
                        _wire1.Add(new Tuple<int, int>(x-i,y));
                    }
                    break;
                case 'D':
                    for (int i = 0; i <= steps; i++)
                    {
                        _wire1.Add(new Tuple<int, int>(x, y+i));
                    }
                    break;
                default:
                    throw new ArgumentException("that direction isn't supported!");
            }
            _currentPosition = _wire1.Last();
        }
        
        private void MarkWire2Step(string move)
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
                        _wire2.Add(new Tuple<int, int>(x+i, y));
                        if (GetWire1().Any(t => t.Item1 == x+i && t.Item2 == y))
                        {
                            _intersections.Add(new Tuple<int, int>(x+i,y));
                        }
                    }                    
                    break;
                case 'U':
                    for (int i = 1; i <= steps; i++)
                    {
                        _wire2.Add(new Tuple<int, int>(x, y-i));
                        if (GetWire1().Any(t => t.Item1 == x && t.Item2 == y-i))
                        {
                            _intersections.Add(new Tuple<int, int>(x,y-i));
                        }
                    }
                    break;
                case 'L':
                    for (int i = 0; i <= steps; i++)
                    {
                        _wire2.Add(new Tuple<int, int>(x-i,y));
                        if (GetWire1().Any(t => t.Item1 == x-i && t.Item2 == y))
                        {
                            _intersections.Add(new Tuple<int, int>(x-i,y));
                        }
                    }
                    break;
                case 'D':
                    for (int i = 0; i <= steps; i++)
                    {
                        _wire2.Add(new Tuple<int, int>(x, y+i));
                        if (GetWire1().Any(t => t.Item1 == x && t.Item2 == y+i))
                        {
                            _intersections.Add(new Tuple<int, int>(x,y+i));
                        }
                    }
                    break;
                default:
                    throw new ArgumentException("that direction isn't supported!");
            }
            _currentPosition = _wire2.Last();
        }

        public List<Tuple<int,int>> GetWire1()
        {
            return _wire1;
        }

        public int GetManhattanDistance()
        {
            return _intersections.Select(position => Math.Abs(position.Item1) + Math.Abs(position.Item2))
                .Min();
        }

        public int GetShortestWireDistance()
        {
            throw new NotImplementedException();
        }
    }
}