using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

namespace WinFormStringCnvClass
{
    static class WinFormStringCnv
    {
        /// <summary>
        /// Controls to String
        /// </summary>
        /// <param name="_form">winform object</param>
        /// <returns></returns>
        static public string ToString(Form _form)
        {

            Dictionary<string, Control> ControlDic = new Dictionary<string, Control>();
            CreateControlDictionary(_form, ControlDic);

            List<string> Lines = new List<string>();

            foreach (var d in ControlDic)
            {
                string Line = ControlToString(d.Value);
                if (Line.Length > 0) Lines.Add(Line);
            }

            return string.Join("\r\n", Lines);
        }

        /// <summary>
        /// setControlFromString
        /// </summary>
        /// <param name="_form">winform object</param>
        /// <param name="str">target control information list</param>
        static public void setControlFromString(Form _form, string strLines)
        {
            Dictionary<string, Control> ControlDic = new Dictionary<string, Control>();
            CreateControlDictionary(_form, ControlDic);

            string[] Lines = strLines.Replace("\r\n", "\n").Split('\n');

            foreach (string s in Lines)
            {
                string[] cols = s.Split('\t');

                if (cols[0].Length > 0 && ControlDic.ContainsKey(cols[0]))
                {
                    setControlFromString(ControlDic[cols[0]], s.Replace(cols[0] + "\t", ""));
                }
            }

            return;
        }

        /// <summary>
        /// CreateControlDictionary
        /// </summary>
        /// <param name="c">Control</param>
        /// <param name="ControlDic">Control information dictionary</param>
        static private void CreateControlDictionary(Control c, Dictionary<string, Control> ControlDic)
        {
            foreach (Control cc in c.Controls)
            {
                if (cc.Name.Length > 0)
                {
                    try
                    {
                        ControlDic.Add(cc.Name, cc);
                        if (cc.Controls.Count > 0)
                            CreateControlDictionary(cc, ControlDic);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + " " + ex.ToString());
                    }
                }
            }
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        static string ControlToString(Control c)
        {
            if (c is TextBox) return c.Name + "\t" + toEscape(((TextBox)c).Text);
            if (c is ListBox) return c.Name + "\t" + toEscape(((ListBox)c).Text);
            if (c is ComboBox) return c.Name + "\t" + toEscape(((ComboBox)c).Text);
            if (c is NumericUpDown) return c.Name + "\t" + ((NumericUpDown)c).Value.ToString();
            if (c is TrackBar) return c.Name + "\t" + ((TrackBar)c).Value.ToString();
            if (c is DataGridView) return DataGridViewToString((DataGridView)c);
            if (c is CheckBox) return c.Name + "\t" + ((CheckBox)c).Checked.ToString();
            if (c is RadioButton) return c.Name + "\t" + ((RadioButton)c).Checked.ToString();

            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="value"></param>
        static void setControlFromString(Control c, string value)
        {

            if (c is TextBox) ((TextBox)c).Text = deEscape(value);
            else if (c is ListBox) ((ListBox)c).Text = deEscape(value);
            else if (c is ComboBox) ((ComboBox)c).Text = deEscape(value);
            else if (c is NumericUpDown) ((NumericUpDown)c).Value = decimal.Parse(value);
            else if (c is TrackBar) ((TrackBar)c).Value = int.Parse(value);
            else if (c is DataGridView) setDataGridViewFromString((DataGridView)c, value);
            else if (c is CheckBox) ((CheckBox)c).Checked = bool.Parse(value);
            else if (c is RadioButton) ((RadioButton)c).Checked = bool.Parse(value);


            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        static private string DataGridViewToString(DataGridView c)
        {
            int ColCount = c.ColumnCount;
            int RowCount = c.Rows.Count;

            List<string> Lines = new List<string>();

            foreach (DataGridViewRow Row in c.Rows)
            {
                string Line = c.Name;
                string Value = "";
                foreach (DataGridViewColumn Col in c.Columns)
                {
                    try
                    {
                        if (c[Col.Index, Row.Index].Value == null)
                        {
                            if (c[Col.Index, Row.Index].OwningColumn is DataGridViewCheckBoxColumn)
                            {
                                Value = "False";
                            }
                            else
                            {
                                Value = "";
                            }
                        }
                        else
                        {
                            Value = toEscape(c[Col.Index, Row.Index].Value.ToString());
                        }

                        Line += "\t" + Value;

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + " " + ex.ToString());
                    }
                }

                if (Value.Length > 0) Lines.Add(Line);
            }

            return string.Join("\r\n", Lines);

        }

        /// <summary>
        /// set DataGridView Contetns From String
        /// </summary>
        /// <param name="c">Target DataGridView</param>
        /// <param name="Line">rows contents string</param>
        static private void setDataGridViewFromString(DataGridView c, string Line)
        {
            string[] cols = Line.Split('\t');

            for (int i = 0; i < cols.Length; i++)
            {
                cols[i] = deEscape(cols[i]);


            }

            c.Rows.Add(cols);

            return;
        }


        static private string toEscape(string text)
        {
            return text.Replace("\t", @"\\t\\").Replace("\r", @"\\r\\").Replace("\n", @"\\n\\");
        }


        static private string deEscape(string text)
        {
            return text.Replace(@"\\t\\", "\t").Replace(@"\\r\\", "\r").Replace(@"\\n\\", "\n");
        }


    }
}