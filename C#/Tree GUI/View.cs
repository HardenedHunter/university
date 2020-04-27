using System;
using System.Drawing;
using System.Windows.Forms;

// ReSharper disable LocalizableElement
// ReSharper disable StringLiteralTypo

namespace Tree_GUI
{
    public partial class View : Form, IView
    {
        private readonly Graphics _canvas;

        public event EventHandler<EventArgs> AddNode;
        public event EventHandler<EventArgs> DeleteNode;
        public event EventHandler<EventArgs> Clear;

        public View()
        {
            InitializeComponent();
            _canvas = panelCanvas.CreateGraphics();
            _canvas.Clip = new Region(new Rectangle(0, 0, panelCanvas.Width, panelCanvas.Height));
            _canvas.Clear(Color.Violet);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddNode?.Invoke(this, EventArgs.Empty);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteNode?.Invoke(this, EventArgs.Empty);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear?.Invoke(this, EventArgs.Empty);
        }

        private void View_Paint(object sender, PaintEventArgs e)
        {
            
        }

        public void DrawTree(Action<Graphics> draw)
        {
            draw(_canvas);
        }

        public string InputAdd
        {
            get
            {
                string rv = textBoxAdd.Text;
                textBoxAdd.Clear();
                return rv;
            }
        }

        public string InputDelete
        {
            get
            {
                string rv = textBoxDelete.Text;
                textBoxDelete.Clear();
                return rv;
            }
        }
    }
}