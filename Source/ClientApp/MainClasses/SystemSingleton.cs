﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using ClientApp.SupportClasses;

namespace ClientApp.MainClasses
{
    public static class SystemSingleton
    {
        public static class CurrentSession
        {
            public static void CloseSession()
            {
                Login = "";
                ID = Guid.Empty;
                TelegramID = 0;
                FirstName = "";
                LastName = "";
                FullName = "";
                UserRoles = new List<Role>();
                TabItems = new Dictionary<string,STabItem>();
            }
            public static string Login;
            public static Guid ID;
            public static int TelegramID;
            public static string FirstName;
            public static string LastName;
            public static string FullName;
            public static List<Role> UserRoles = new List<Role>();
            public static Dictionary<string,STabItem> TabItems = new Dictionary<string, STabItem>();

            public static bool SetCaptionToGrid(Window window, KeyValuePair<string, STabItem> item)
            {
                try
                {
                    item.Value.DataGrid.Columns[1].Header =
                        (String) window.FindResource("m_column_Date");
                    item.Value.DataGrid.Columns[2].Header =
                        (String) window.FindResource("m_column_DocType");
                    item.Value.DataGrid.Columns[3].Header =
                        (String) window.FindResource("m_column_FromPersonalName");
                    if (item.Key == StaticTypes.CompletedWorkTab || item.Key == StaticTypes.CurrentWorkTab)
                    {
                        item.Value.DataGrid.Columns[4].Header =
                            (String) window.FindResource("m_column_ToRoleName");
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static class Configuration
        {
            public static string ConnectionString { get; set; }
            public static bool SQLLog { get; set; }
        }

        public static class BotomTab
        {
            public static string CurrentBottomBarLabelContent { get; set; }
            public static Brush CurrentBottomBarLabelBrush { get; set; }
        }
    }
}