// ReSharper disable CommentTypo

using System;
using Tree;

namespace Tree_GUI
{
    class Presenter
    {
        private readonly IView _view;
        private LinkedTree<int> _tree = new LinkedTree<int>(2);

        public Presenter(IView view)
        {
            _view = view;
            _view.AddNode += OnAddNode;
            _view.DeleteNode += OnDeleteNode;
            _view.Clear += OnClear;
            // _tree.Add(1);
            // _tree.Add(2);
            // _tree.Add(3);
            // _tree.Add(4);
            // _tree.Add(5);
            // _tree.Add(6);
            // _tree.Add(7);
            // _tree.Add(8);
            // _tree.Add(9);
            // _tree.Add(10);
            RefreshView();
        }

        private void OnAddNode(object sender, EventArgs e)
        {
            if (Int32.TryParse(_view.InputAdd, out int result))
            {
                _tree.Add(result);
                RefreshView();
            }
        }

        private void OnDeleteNode(object sender, EventArgs e)
        {
            if (Int32.TryParse(_view.InputDelete, out int result))
            {
                _tree.Remove(result);
                RefreshView();
            }
        }

        private void OnClear(object sender, EventArgs e)
        {
            _tree.Clear();
            // RefreshView();

            _tree.Add(1);
            _tree.Add(2);
            _tree.Add(3);
            _tree.Add(4);
            _tree.Add(5);
            _tree.Add(6);
            _tree.Add(7);
            _tree.Add(8);
            _tree.Add(9);
            _tree.Add(10);
            _tree.Remove(10);
            _tree.Remove(9);
            _tree.Remove(1);
            _tree.Remove(2);
            _tree.Remove(3);
            _tree.Remove(6);
            // _tree.Remove(8);
            RefreshView();
        }


        private void RefreshView()
        {
            _view.DrawTree(_tree.Draw);
        }
    }
}