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
        private static int MOVE_SPEED = 250; // least 10 milliseconds over.

        // Character's state
        private int x, y;
        private int stepSize;
        private int chNo, chMotion;
        private DIRECTION chDirection;
        private bool isMoved;
            
        private Timer tmMove; 

        public Character() : this(0, 1, DIRECTION.DOWN, 10)
        {
        }

        public Character(int no, int motion, DIRECTION dir, int stepSize)
        {
            isMoved = false;
            ChNo = no;
            ChMotion = motion;
            ChDirection = dir;
            this.stepSize = stepSize/3;
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
                    Y += stepSize;
                    break;
                case DIRECTION.LEFT:
                    X -= stepSize;
                    break;
                case DIRECTION.RIGHT:
                    X += stepSize;
                    break;
                case DIRECTION.UP:
                    Y -= stepSize;
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

        public int StepSize
        {
            get
            {
                return stepSize;
            }
            set
            {
                this.stepSize = value;
            }
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

        public bool IsMove
        {
            get
            {
                return isMoved;
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
