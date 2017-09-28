﻿using System.Windows;

namespace Dialog
{
    /// <summary>
    ///     DlgOK.xaml 的交互逻辑
    /// </summary>
    public partial class DialogOk
    {
        public DialogOk(string message)
        {
            InitializeComponent();
            DataContext = new DialogOkVm(message);
        }
    }
}