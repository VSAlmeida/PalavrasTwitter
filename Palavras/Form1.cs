using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tweetinvi;
using MinhaBibli;

namespace Palavras
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            TwitterBLL.conectar();
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMens());
                Application.Exit();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Twitter.setUser(textBox1.Text);
            Twitter.setQtd(textBox2.Text);
            TwitterBLL.validaDados();
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMens());
            }
            else
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                Twitter.clearPalavras();
                foreach (var timelineTweet in Twitter.getTweets())
                {
                    listBox1.Items.Add(timelineTweet);
                    Twitter.setPalavras(" " + timelineTweet);
                }
                Twitter.setPalavrasList();
                var resultado =
                from p in Twitter.getPalavraList()
                group p by p into g
                select new { palavra = g.Key, contador = g.Count() };

                foreach (var registro in resultado)
                {
                    if (registro.palavra != "")
                        listBox2.Items.Add(String.Format("{0} - {1}", registro.palavra, registro.contador));
                }

            } 
        }
    }
}
