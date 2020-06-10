using System;
using System.Threading;
using System.Windows.Forms;

namespace Modeling
{
    public partial class View : Form, IView
    {
        public SynchronizationContext Context { get; set; }

        public View()
        {
            InitializeComponent();
        }

        private void View_Load(object sender, EventArgs e)
        {
            Context = SynchronizationContext.Current;
        }
    }
}
