﻿using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using ConfigLib;
using DeckEditor.Constant;
using StringLib;

namespace DeckEditor.Utils
{
    public class SqliteUtils : SqliteConst
    {
        /// <summary>数据填充至DataSet</summary>
        public static bool FillDataToDataSet(string sql, DataSet dts)
        {
            var password = StringUtils.Decrypt(ConfigUtils.Get(DatabasePassword));
            using (var con = new SQLiteConnection(DatabasePath))
            {
                try
                {
                    con.SetPassword(password);
                    con.Open();
                    var cmd = new SQLiteCommand(sql, con);
                    var dap = new SQLiteDataAdapter(cmd);
                    dts.Clear();
                    dap.Fill(dts, TableName);
                    con.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    return false;
                }
            }
            return true;
        }

        public static bool Execute(string sql)
        {
            var pwd = StringUtils.Decrypt(ConfigUtils.Get(DatabasePassword));
            using (var con = new SQLiteConnection(DatabasePath))
            {
                try
                {
                    con.SetPassword(pwd);
                    con.Open();
                    var cmd = new SQLiteCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        ///     加密数据库
        /// </summary>
        public static bool Encrypt(DataSet ds)
        {
            try
            {
                var pwdF = ConfigUtils.Get(DatabasePassword);
                var pwdT = StringUtils.Decrypt(pwdF);
                using (var con = new SQLiteConnection(DatabasePath))
                {
                    con.Open();
                    con.ChangePassword(pwdT);
                    con.Close();
                }
                FillDataToDataSet(QueryAllSql, ds); // 加密完数据库后，重新读取数据
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        /// <summary>
        ///     解密数据库
        /// </summary>
        public static bool Decrypt()
        {
            try
            {
                var pwdF = ConfigUtils.Get(DatabasePassword);
                var pwdT = StringUtils.Decrypt(pwdF);
                using (var con = new SQLiteConnection(DatabasePath))
                {
                    con.SetPassword(pwdT);
                    con.Open();
                    con.ChangePassword(string.Empty);
                    con.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
    }
}