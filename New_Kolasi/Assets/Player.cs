using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Player
    {
        public Vector3 position;

        public enum Direction
        {
            UP,
            DOWN,
            LEFT,
            RIGHT,
            NONE
        }

        public Player(Vector3 position)
        {
            this.position = position;
        }

        public void Update()
        {
            Direction direction = Direction.NONE;
            do
            {
                direction = WhichDirection();
            } while (direction == Direction.NONE);
            HasToMove(position, direction);
        }

        public void HasToMove(Vector3 positionInitial, Direction direction)
        {
            switch (direction)
            {
                    case Direction.UP:
                        int i = 0;
                        while (i < 50)
                        {
                            positionInitial += new Vector3(0, 0, 0.1f);
                            i++;
                        }
                        break;
                    case Direction.DOWN:
                        int j = 0;
                        while (j < 50)
                        {
                            positionInitial -= new Vector3(0, 0, 0.1f);
                            j++;
                        }
                        break;
                    case Direction.LEFT:
                        int k = 0;
                        while (k < 50)
                        {
                            positionInitial -= new Vector3(0.1f, 0, 0);
                            k++;
                        }
                        break;
                    case Direction.RIGHT:
                        int l = 0;
                        while (l < 50)
                        {
                            positionInitial += new Vector3(0.1f, 0, 0);
                            l++;
                        }
                        break;
            }
        }

        public Direction WhichDirection()
        {
            Direction direction = Direction.NONE;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = Direction.UP;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = Direction.DOWN;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = Direction.LEFT;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = Direction.RIGHT;
            }
            return direction;
        }
    }
}