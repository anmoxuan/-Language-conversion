using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baosight.iSuperframe.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : FormBase
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //设置combobox的值
                string language = Properties.Settings.Default.DefaultLanguage;

                if (language == "zh-CN")
                {
                    comboBox1.Text = "简体中文(默认)";
                }
                else if (language == "en-US")
                {
                    comboBox1.Text = "English";
                }
            }
            catch (Exception ex) { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // comboBox1.Enabled = false;
                if (comboBox1.Text == "简体中文[默认]")
                {
                    //修改默认语言
                    MultiLanguage.SetDefaultLanguage("zh-CN");
                    //对所有打开的窗口重新加载语言
                    foreach (Form form in Application.OpenForms)
                    {
                        LoadAll(form);
                    }
                }
                else if (comboBox1.Text == "English")
                {
                    //修改默认语言
                    MultiLanguage.SetDefaultLanguage("en-US");
                    //对所有打开的窗口重新加载语言
                    foreach (Form form in Application.OpenForms)
                    {
                        LoadAll(form);
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void LoadAll(Form form)
        {
            if (form.Name == "Form1")
            {
                MultiLanguage.LoadLanguage(form, typeof(Form1));
            }
            //else if (form.Name == "PasswordForm")
            //{
            //    MultiLanguage.LoadLanguage(form, typeof(Form1));
            //}
        }
    }
}
