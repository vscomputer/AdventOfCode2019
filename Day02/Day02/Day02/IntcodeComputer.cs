using System;
using System.Collections.Generic;

namespace Day02
{
    public class IntcodeComputer
    {
        private const int OpcodeLength = 4;
        private bool _isFinished;
        private List<int> _codes;

        public IntcodeComputer()
        {
            _isFinished = false;
        }
        
        public void Compute(List<int> input)
        {
            _isFinished = false;
            
            _codes = input;
            var i = 0;
            while (_isFinished == false)
            {
                var operation = _codes[i];
                if (operation == 99)
                {
                    _isFinished = true;
                    break;
                }
                    
                var m = _codes[i + 1];
                var n = _codes[i + 2];
                var resultPosition = _codes[i + 3];
                switch (operation)
                {                    
                    case 1:
                        _codes[resultPosition] = _codes[m] + _codes[n];
                        break;
                    case 2:
                        _codes[resultPosition] = _codes[m] * _codes[n];
                        break;
                    default:
                        throw new ArgumentException();
                }                                                               
                i += OpcodeLength;
            }
        }

        public bool IsFinished()
        {
            return _isFinished;
        }

        public int GetValueAtPosition(int position)
        {
            return _codes[position];
        }
    }
}