﻿using AdminApp.SystemClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AdminApp.Elements;

namespace AdminApp.SupportClasses
{
    public static class Handlers
    {
        public static void RowPersonalRole_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGridRow row)
            {
                if (Guid.Parse(((DataRowView) row.Item).Row.ItemArray[0].ToString()) ==
                    SystemSingleton.CurrentSession.ID)
                {
                    EnvironmentHelper.SendDialogBox(
                        (string)SystemSingleton.Configuration.mainWindow.FindResource("m_CantEditMySelf"),
                        "Attention"
                    );
                    return;
                }
                var temp = PersonalRoleCardFactory.CreateTab(Guid.Parse(((DataRowView)row.Item).Row.ItemArray[0].ToString()));
                if (temp != null)
                {
                    if (SystemSingleton.CurrentSession.TabCards.ContainsKey(((PersonalRoleCard)temp.Card).ID.Value))
                    {
                        EnvironmentHelper.SendDialogBox(
                            (string)SystemSingleton.Configuration.mainWindow.FindResource("m_AlreadyOpened"),
                            "Attention"
                        );
                    }
                    else
                    {
                        if (((PersonalRoleCard)temp.Card).isEditingNow)
                        {
                            EnvironmentHelper.SendDialogBox(
                                (string)SystemSingleton.Configuration.mainWindow.FindResource("m_AlreadyEditing"),
                                "Attention"
                            );
                        }
                        else
                        {
                            try
                            {
                                using (var con = new SqlConnection(SystemSingleton.Configuration.ConnectionString))
                                {
                                    SystemSingleton.Configuration.SqlConnections.Add(con);
                                    using (var command = new SqlCommand(SqlCommands.SetEditingToPersonalRole, con))
                                    {
                                        command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier);
                                        command.Parameters["@ID"].Value = ((PersonalRoleCard)temp.Card).ID.Value;
                                        EnvironmentHelper.SendLogSQL(command.CommandText);
                                        con.Open();
                                        int colms = command.ExecuteNonQuery();
                                        con.Close();
                                        if (colms == 0)
                                        {
                                            EnvironmentHelper.SendDialogBox(
                                                (string)SystemSingleton.Configuration.mainWindow.FindResource(
                                                    "m_CantSetEditing") + "\n\n" + ((PersonalRoleCard)temp.Card).ID.Value.ToString(),
                                                "SQL Error"
                                            );
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                EnvironmentHelper.SendErrorDialogBox(ex.Message, "SQL Error", ex.StackTrace);
                            }
                        }
                        SystemSingleton.CurrentSession.TabCards.Add(((PersonalRoleCard)temp.Card).ID.Value, temp);
                        SystemSingleton.Configuration.tabControl.Items.Add(temp.TabItem);
                    }
                }
            }
        }
        public static void RowPersonalRoleView_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGridRow row)
            {
                SystemSingleton.CurrentSession.ChosenIDForStaticRole =
                    Guid.Parse(((DataRowView) row.Item).Row.ItemArray[0].ToString());
                SystemSingleton.CurrentSession.ViewChoose.Close();
            }
        }
        public static void RowStaticRole_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGridRow row)
            {
                var temp = StaticRoleCardFactory.CreateTab(Guid.Parse(((DataRowView)row.Item).Row.ItemArray[0].ToString()));
                if (temp != null)
                {
                    if (SystemSingleton.CurrentSession.TabCards.ContainsKey(((StaticRoleCard)temp.Card).ID.Value))
                    {
                        EnvironmentHelper.SendDialogBox(
                            (string)SystemSingleton.Configuration.mainWindow.FindResource("m_AlreadyOpened"),
                            "Attention"
                        );
                    }
                    else
                    {
                        if (((StaticRoleCard)temp.Card).isEditingNow)
                        {
                            EnvironmentHelper.SendDialogBox(
                                (string)SystemSingleton.Configuration.mainWindow.FindResource("m_AlreadyEditing"),
                                "Attention"
                            );
                        }
                        else
                        {
                            try
                            {
                                using (var con = new SqlConnection(SystemSingleton.Configuration.ConnectionString))
                                {
                                    SystemSingleton.Configuration.SqlConnections.Add(con);
                                    using (var command = new SqlCommand(SqlCommands.SetEditingToStaticRole, con))
                                    {
                                        command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier);
                                        command.Parameters["@ID"].Value = ((StaticRoleCard)temp.Card).ID.Value;
                                        EnvironmentHelper.SendLogSQL(command.CommandText);
                                        con.Open();
                                        int colms = command.ExecuteNonQuery();
                                        con.Close();
                                        if (colms == 0)
                                        {
                                            EnvironmentHelper.SendDialogBox(
                                                (string)SystemSingleton.Configuration.mainWindow.FindResource(
                                                    "m_CantSetEditing") + "\n\n" + ((StaticRoleCard)temp.Card).ID.Value.ToString(),
                                                "SQL Error"
                                            );
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                EnvironmentHelper.SendErrorDialogBox(ex.Message, "SQL Error", ex.StackTrace);
                            }
                        }
                        SystemSingleton.CurrentSession.TabCards.Add(((StaticRoleCard)temp.Card).ID.Value, temp);
                        SystemSingleton.Configuration.tabControl.Items.Add(temp.TabItem);
                    }
                }
            }
        }
        public static void RowDocType_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("DT");
            //if (sender is DataGridRow row)
            //{
            //    var temp = CardPersonalRoleFactory.CreateTab(Guid.Parse(((DataRowView)row.Item).Row.ItemArray[0].ToString()));
            //    if (temp != null)
            //    {
            //        if (SystemSingleton.CurrentSession.TabCards.ContainsKey(temp.Card.Task.Number))
            //        {
            //            EnvironmentHelper.SendDialogBox(
            //                (string)SystemSingleton.Configuration.mainWindow.FindResource("m_AlreadyOpened"),
            //                "Attention"
            //            );
            //        }
            //        else
            //        {
            //            if (temp.Card.Task.StateID == new Guid("6a52791d-7e42-42d6-a521-4252f276bb6c"))
            //            {
            //                if (temp.Card.Task.isEditingNow)
            //                {
            //                    EnvironmentHelper.SendDialogBox(
            //                        (string)SystemSingleton.Configuration.mainWindow.FindResource("m_AlreadyEditing"),
            //                        "Attention"
            //                    );
            //                }
            //                else
            //                {
            //                    try
            //                    {
            //                        using (var con = new SqlConnection(SystemSingleton.Configuration.ConnectionString))
            //                        {
            //                            using (var command = new SqlCommand(SqlCommands.SetEditingToPersonalRole, con))
            //                            {
            //                                command.Parameters.Add("@TaskID", SqlDbType.UniqueIdentifier);
            //                                command.Parameters["@TaskID"].Value = temp.Card.Task.ID.Value;
            //                                EnvironmentHelper.SendLogSQL(command.CommandText);
            //                                con.Open();
            //                                int colms = command.ExecuteNonQuery();
            //                                con.Close();
            //                                if (colms == 0)
            //                                {
            //                                    EnvironmentHelper.SendDialogBox(
            //                                        (string)SystemSingleton.Configuration.mainWindow.FindResource(
            //                                            "m_CantSetEditing") + "\n\n" + temp.Card.Task.ID.Value.ToString(),
            //                                        "SQL Error"
            //                                    );
            //                                }
            //                            }
            //                        }
            //                    }
            //                    catch (Exception ex)
            //                    {
            //                        EnvironmentHelper.SendErrorDialogBox(ex.Message, "SQL Error", ex.StackTrace);
            //                    }
            //                }
            //            }
            //            SystemSingleton.CurrentSession.TabCards.Add(temp.Card.Task.Number, temp);
            //            SystemSingleton.Configuration.tabControl.Items.Add(temp.TabItem);
            //        }
            //    }
            //}
        }
        public static void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SystemSingleton.Configuration.mainWindow.Update.Visibility =
                SystemSingleton.Configuration.tabControl.SelectedIndex == 1 ?
                    Visibility.Visible : Visibility.Collapsed;
            SystemSingleton.Configuration.mainWindow.CreateNew.Visibility =
                SystemSingleton.Configuration.tabControl.SelectedIndex == 1 ?
                    Visibility.Visible : Visibility.Collapsed;
        }
    }
}
