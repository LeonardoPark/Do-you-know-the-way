using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodingGame_KOI.game;
using CodingGame_KOI.communication;

namespace CodingGame_KOI
{
    public partial class frmGame : Form
    {
        // constanats
        private const int REFRESH_TIME = 200;
        private const string DATA_UP = "1";
        private const string DATA_DOWN = "2";
        private const string DATA_LEFT = "3";
        private const string DATA_RIGHT = "4";
        private const string DATA_REMOVE = "5";
        private const string DATA_RUN = "6";

        // the objects that related game.
        private bool isRunning = false;
        private Timer tmRefresh;
        private Timer tmRunner;
        private Character character;

        // objects
        private CodeblockManager codeblockManager = null;
        private List<Character.DIRECTION> codeblocks = null;
        private SerialCommunication bluetooth = null;

        public frmGame()
        {
            InitializeComponent();
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            codeblockManager = new CodeblockManager(this, this.picCodeblocks);
            initCharacter();
            initEvent();
        }

        private void initEvent()
        {
            tmRefresh = new Timer();
            tmRefresh.Tick += new EventHandler(refresh);
            tmRefresh.Interval = REFRESH_TIME;
            tmRefresh.Enabled = true;

            tmRunner = new Timer();
            tmRunner.Tick += new EventHandler(run);
            tmRunner.Interval = REFRESH_TIME;
            tmRunner.Enabled = false;
        }


        private void execute()
        {
            if (!isRunning)
            {
                tmRunner.Enabled = true;
                codeblocks = codeblockManager.getCodeblocks();
                isRunning = true;
            }
        }

        private void run(object sender, EventArgs e)
        {
            if (codeblocks != null && codeblocks.Count >= 1)
            {
                Character.DIRECTION dir = codeblocks.ElementAt(0);
                if (character.move(dir))
                {
                    codeblocks.RemoveAt(0);
                }
            }
            else
            {
                isRunning = false;
                tmRunner.Enabled = false;
                codeblocks = null;
            }   
        }

        private void refresh(object sender, EventArgs e)
        {
            gameScreen.Invalidate();
        }

        private void initCharacter()
        {
            this.character = new Character(4, 1, Character.DIRECTION.DOWN);
        }

        private Bitmap loadImageFromResources(string resourceName)
        {
            return (Bitmap)Properties.Resources.ResourceManager.GetObject(resourceName);
        }

        private void drawCharacter(Graphics g)
        {
            Bitmap characters = loadImageFromResources("characters");
            int imgWidth, imgHeight;
            int chWidth, chHeight;
            
            imgWidth = characters.Width;
            imgHeight = characters.Height;

            chWidth = imgWidth / 12;
            chHeight = imgHeight / 8;

            Point imgSrcXY = new Point();
            Point imgDestXY = new Point();

            
            imgSrcXY.X = chWidth * ( (character.ChNo >= 4) ? character.ChNo - 4 : character.ChNo ) * 3 + chWidth * character.ChMotion;
            imgSrcXY.Y = ((character.ChNo >= 4) ? chHeight * 4 : 0) + chHeight * (int)character.ChDirection;

            imgDestXY.X = character.X;
            imgDestXY.Y = character.Y;

            g.DrawImage(characters,
                new Rectangle(imgDestXY, new Size(chWidth, chHeight)),
                new Rectangle(imgSrcXY, new Size(chWidth, chHeight)),
                GraphicsUnit.Pixel
            );
        }

        private void gameScreen_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bg = loadImageFromResources("background");
            Graphics g = e.Graphics;

            g.DrawImage(bg, new Rectangle(new Point(0, 0), gameScreen.Size));
            drawCharacter(g);
        }

        private void frmGame_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Up:
                    codeblockManager.addBlock(Character.DIRECTION.UP);
                    break;
                case Keys.Down:
                    codeblockManager.addBlock(Character.DIRECTION.DOWN);
                    break;
                case Keys.Left:
                    codeblockManager.addBlock(Character.DIRECTION.LEFT);
                    break;
                case Keys.Right:
                    codeblockManager.addBlock(Character.DIRECTION.RIGHT);
                    break;
                case Keys.Back:
                    codeblockManager.removeLastBlock();
                    break;
                case Keys.Space:
                    execute();
                    break;
            }
        }

        private void btnOpenSerial_Click(object sender, EventArgs args)
        {
            if (bluetooth != null)
            {
                bluetooth.close();
                bluetooth = null;
            }
            bluetooth = new SerialCommunication(this, txtSerialPortName.Text, bluetoothDataReceive);
            try
            {
                bluetooth.open();
                pnSerialSetting.Visible = false;
            }
            catch (Exception e)
            {
                MessageBox.Show("시리얼 포트 연결에 실패했습니다. 다시 시도해주세요.\n에러메세지:" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void bluetoothDataReceive(string msg)
        {
            switch(msg)
            {
                case DATA_UP:
                    codeblockManager.addBlock(Character.DIRECTION.UP);
                    break;
                case DATA_DOWN:
                    codeblockManager.addBlock(Character.DIRECTION.DOWN);
                    break;
                case DATA_LEFT:
                    codeblockManager.addBlock(Character.DIRECTION.LEFT);
                    break;
                case DATA_RIGHT:
                    codeblockManager.addBlock(Character.DIRECTION.RIGHT);
                    break;
                case DATA_REMOVE:
                    codeblockManager.removeLastBlock();
                    break;
                case DATA_RUN:
                    execute();
                    break;
            }
        }
    }
}
