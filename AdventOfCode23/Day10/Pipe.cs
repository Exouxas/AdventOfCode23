using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode23.Day10
{
    internal class Pipe(char symbol)
    {
        private Dictionary<Pipe, Pipe> _connections = new();

        public char Symbol { get; } = symbol;

        private Pipe _up;
        public Pipe Up 
        {
            get => _up;
            set
            {
                if (value == null) return;
                if (_up != null) return;

                if (value.Down != null)
                {
                    _up = value;
                    Connect(value);
                }
                else
                {
                    if(CanHaveUp())
                    {
                        if(value.CanHaveDown())
                        {
                            _up = value;
                            value.Down = this;
                            Connect(value);
                        }
                    }
                }
            }
        }

        private Pipe _down;
        public Pipe Down 
        {
            get => _down;
            set
            {
                if (value == null) return;
                if (_down != null) return;

                if (value.Up != null)
                {
                    _down = value;
                    Connect(value);
                }
                else
                {
                    if (CanHaveDown())
                    {
                        if (value.CanHaveUp())
                        {
                            _down = value;
                            value.Up = this;
                            Connect(value);
                        }
                    }
                }
            }
        }

        private Pipe _left;
        public Pipe Left
        {
            get => _left;
            set
            {
                if (value == null) return;
                if (_left != null) return;

                if (value.Right != null)
                {
                    _left = value;
                    Connect(value);
                }
                else
                {
                    if (CanHaveLeft())
                    {
                        if (value.CanHaveRight())
                        {
                            _left = value;
                            value.Right = this;
                            Connect(value);
                        }
                    }
                }
            }
        }

        private Pipe _right;
        public Pipe Right
        {
            get => _right;
            set
            {
                if (value == null) return;
                if (_right != null) return;

                if (value.Left != null)
                {
                    _right = value;
                    Connect(value);
                }
                else
                {
                    if (CanHaveRight())
                    {
                        if (value.CanHaveLeft())
                        {
                            _right = value;
                            value.Left = this;
                            Connect(value);
                        }
                    }
                }
            }
        }

        public Pipe Next(Pipe previous)
        {
            return _connections[previous];
        }

        private void Connect(Pipe toConnect)
        {
            if(_connections.Count > 0)
            {
                Pipe existing = First();
                _connections[existing] = toConnect;
                _connections.Add(toConnect, existing);
            }
            else
            {
                _connections.Add(toConnect, null);
            }
        }

        public Pipe First()
        {
            return _connections.Keys.First();
        }

        public bool CanHaveUp()
        {
            return Symbol == '|' || Symbol == 'L' || Symbol == 'J' || Symbol == 'S';
        }

        public bool CanHaveDown()
        {
            return Symbol == '|' || Symbol == 'F' || Symbol == '7' || Symbol == 'S';
        }

        public bool CanHaveLeft()
        {
            return Symbol == '-' || Symbol == 'J' || Symbol == '7' || Symbol == 'S';
        }

        public bool CanHaveRight()
        {
            return Symbol == '-' || Symbol == 'L' || Symbol == 'F' || Symbol == 'S';
        }
    }
}
