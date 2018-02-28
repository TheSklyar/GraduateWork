﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ClientApp.SupportClasses
{
    public static class Handlers
    {
        public static void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGridRow row) MessageBox.Show(((DataRowView) row.Item).Row.ItemArray[0].ToString());
        }
    }
}