using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
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
        public event EventHandler<EventArgs> Reload;
        public event EventHandler<EventArgs> SelectArray;
        public event EventHandler<EventArgs> SelectLinked;
        public event EventHandler<EventArgs> ChangeFactor;
        public event EventHandler<EventArgs> SortByEven;
        public event EventHandler<EventArgs> SortByOdd;
        public event EventHandler<EventArgs> FillTestData;
        public event EventHandler<EventArgs> MakeImmutable;

        public View()
        {
            InitializeComponent();
            _canvas = panelCanvas.CreateGraphics();
            _canvas.Clip = new Region(new Rectangle(0, 0, panelCanvas.Width, panelCanvas.Height));
            _canvas.InterpolationMode = InterpolationMode.High;

            var radioButtons = groupBoxImplementation.Controls.OfType<RadioButton>();
            foreach (RadioButton item in radioButtons)
            {
                item.CheckedChanged += radio_CheckedChanged;
            }
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

        public string InputFactor
        {
            get
            {
                string rv = textBoxFactor.Text;
                textBoxFactor.Clear();
                return rv;
            }
        }

        public void DrawTree(Action<Graphics> draw)
        {
            draw(_canvas);
        }

        public void DrawEmpty()
        {
            _canvas.Clear(Color.White);

            var rectangle = new Rectangle(0, 0, (int)_canvas.ClipBounds.Width,
                (int)(_canvas.ClipBounds.Height / 1.5f));

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            using (Font font = new Font("Arial", 24, FontStyle.Bold, GraphicsUnit.Point))
            {
                _canvas.DrawString("Дерево пусто.", font, Brushes.SeaGreen, rectangle, stringFormat);
            }
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

        private void buttonFactor_Click(object sender, EventArgs e)
        {
            ChangeFactor?.Invoke(this, EventArgs.Empty);
        }

        private void buttonSortEven_Click(object sender, EventArgs e)
        {
            SortByEven?.Invoke(this, EventArgs.Empty);
        }

        private void buttonSortOdd_Click(object sender, EventArgs e)
        {
            SortByOdd?.Invoke(this, EventArgs.Empty);
        }

        private void buttonDataSet_Click(object sender, EventArgs e)
        {
            FillTestData?.Invoke(this, EventArgs.Empty);
        }

        private void buttonMakeImmutable_Click(object sender, EventArgs e)
        {
            MakeImmutable?.Invoke(this, EventArgs.Empty);
        }

        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            Reload?.Invoke(this, EventArgs.Empty);
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            string checkedName = ((RadioButton) sender).Name;
            if (checkedName == "radioLinked")
            {

                SelectLinked?.Invoke(this, EventArgs.Empty);
            }
            else if (checkedName == "radioArray")
            {
                SelectArray?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}