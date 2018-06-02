using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodingGame_KOI.game
{
    class Character
    {
        public enum DIRECTION { DOWN, LEFT, RIGHT, UP };

        // Constants
        private static int STEP_SIZE = 10; // the distance when character move.
        private static int MOVE_SPEED = 50; // least 10 milliseconds over.

        // Character's state
        private int x, y;
        private int chNo, chMotion;
        private DIRECTION chDirection;
        private bool isMoved;
            
        private Timer tmMove; 

        public Character() : this(0, 1, DIRECTION.DOWN)
        {
        }

        public Character(int no, int motion, DIRECTION dir)
        {
            isMoved = false;
            ChNo = no;
            ChMotion = motion;
            ChDirection = dir;
            init();
        }

        private void init()
        {
            initAnimator();
        }

        private void initAnimator()
        {
            tmMove = new Timer();
            tmMove.Tick += new EventHandler(moveAnimator);
            tmMove.Interval = MOVE_SPEED;
        }

        private void moveAnimator(Object obj, EventArgs args)
        {
            ChMotion = (ChMotion >= 2) ? 0 : ChMotion + 1;

            if (ChMotion == 1)
            {
                tmMove.Enabled = false;
                isMoved = false;
            }

            switch(ChDirection)
            {
                case DIRECTION.DOWN:
                    Y += STEP_SIZE;
                    break;
                case DIRECTION.LEFT:
                    X -= STEP_SIZE;
                    break;
                case DIRECTION.RIGHT:
                    X += STEP_SIZE;
                    break;
                case DIRECTION.UP:
                    Y -= STEP_SIZE;
                    break;
            }
        }

        public bool move(Character.DIRECTION dir)
        {
            if (!isMoved)
            {
                ChDirection = dir;
                isMoved = true;
                tmMove.Enabled = true;
                return true;
            }
            return false;
        }

        public int ChNo
        {
            get
            {
                return chNo;
            }
            set
            {
                chNo = value;
            }
        }

        public int ChMotion
        {
            get
            {
                return chMotion;
            }
            set
            {
                if (value >= 0 && value <= 2)
                    chMotion = value;
            }
        }

        public Character.DIRECTION ChDirection
        {
            get
            {
                return chDirection;
            }
            set
            {
                chDirection = value;
            }
        }

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
    }
}
