using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace LogViewer
{
    public partial class Form1 : Form
    {
        private string[] _fileCheck = { "vrmonitor.txt", "vrmonitor.previous.txt", "vrcompositor.txt",
            "vrcompositor.previous.txt", "vrclient_vrcompositor.txt", "vrclient_vrmonitor.txt",
            "vrserver.txt", "vrserver.previous.txt",
            "vrclient_CurseofDavyJones.txt", "vrclient_DeadwoodMansion.txt"};
        private string _selectedPath = "";
        private ArrayList _fileCache = new ArrayList();
        private ArrayList _libLog = new ArrayList();        

        public Form1()
        {
            InitializeComponent();
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res =  fbDia.ShowDialog();
            if(res == DialogResult.OK)
            {
                resetList();
                
                //string _fold = fbDia.SelectedPath;
                _selectedPath = fbDia.SelectedPath;

                this.Text = "Working Folder : " +_selectedPath;

                for (int vi  = 0; vi < _fileCheck.Length; ++vi)
                {
                    string _file = _fileCheck[vi];
                    string _chk = "OK";
                    if (!File.Exists(_selectedPath + "\\" + _file))
                    {
                        _chk = "Failed";
                    }
                    lstFile.Items.Add(_file + " : " + _chk);
                }
                Console.WriteLine(fbDia.SelectedPath);
            }
        }

        private void lstFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFile.SelectedIndex == -1) return;

            string _filePath = _selectedPath + "\\" + _fileCheck[lstFile.SelectedIndex];
            
            if(File.Exists(_filePath))
            {
                string line;
                lstSec.Items.Clear();
                lstWarn.Items.Clear();
                grpBox.Controls.Clear();

                _fileCache.Clear();
                StreamReader _sr = new StreamReader(_filePath);
                while((line = _sr.ReadLine()) != null){
                    if (readSecSt(line))
                    {
                        if(_fileCache.Count == 0) {
                            _fileCache.Add(new ArrayList());
                            string[] lineStr = line.Split('-');
                            lstSec.Items.Add("Section " + _fileCache.Count + " (" + lineStr[0] + ")");
                        }
                        else
                        {
                            ArrayList _secList = (ArrayList)_fileCache[(_fileCache.Count - 1)];
                            if(_secList.Count > 0) {
                                _fileCache.Add(new ArrayList());
                                string[] lineStr = line.Split('-');
                                lstSec.Items.Add("Section " + _fileCache.Count + " ("+ lineStr[0] +")");
                            }
                            
                        }                       
                    }
                    else
                    {
                        if (_fileCache.Count > 0)
                        {
                            ArrayList _secList = (ArrayList)_fileCache[(_fileCache.Count - 1)];
                            _secList.Add(catLogString(line));
                        }
                    }
                }
            }            
        }

        private bool readSecSt(string lineStr)
        {
            if (lineStr.Contains("==========="))
            {
                return true;
            }
            return false;
        }

        private void lstSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSec.SelectedIndex == -1) return;

            lstWarn.Items.Clear();
            _libLog.Clear();

            ArrayList _secContent = (ArrayList)_fileCache[lstSec.SelectedIndex];

            foreach( string _line in _secContent)
            {
                lstWarn.Items.Add(_line);
                string tag = checkHashTab(_line);
                if(tag != "")
                {
                    int _in = findLibIndex(tag);
                    KeyValuePair<string, ArrayList> _lstLog;
                    if(_in >= 0)
                    {
                        _lstLog = (KeyValuePair<string, ArrayList>)_libLog[_in];
                    }
                    else
                    {
                        _lstLog = new KeyValuePair<string, ArrayList>(tag, new ArrayList());
                        _libLog.Add(_lstLog);
                    }
                    _lstLog.Value.Add(_line);
                }
            }

            showButtonByTag();
            //lstWarn.Items.AddRange(_secContent.ToArray());

            
        }

        private int findLibIndex(string tag)
        {
            for(int vi = 0; vi < _libLog.Count; ++vi)
            {
                KeyValuePair<string, ArrayList> _lib = (KeyValuePair<string, ArrayList>)_libLog[vi];
                if (_lib.Key.Equals(tag))
                {
                    return vi;
                }
            }
            return -1;
        }

        private void showButtonByTag()
        {
            Point pt = new Point(6, 14);           
            grpBox.Controls.Clear();

            foreach(KeyValuePair<string, ArrayList> _libKey in _libLog)
            {
                Button btn = new Button();
                btn.Text = _libKey.Key;
                btn.Left = pt.X + grpBox.Controls.Count * btn.Size.Width ;
                btn.Top = pt.Y;
                btn.Tag = grpBox.Controls.Count;
                btn.Click += Btn_Click;
                grpBox.Controls.Add(btn);              
            }

            //for All Button
            Button btnAll = new Button();
            btnAll.Text = "All";
            btnAll.Left = pt.X + grpBox.Controls.Count * btnAll.Size.Width;
            btnAll.Top = pt.Y;
            btnAll.Tag = grpBox.Controls.Count;
            btnAll.Click += BtnAll_Click; ;
            grpBox.Controls.Add(btnAll);
        }

        private void BtnAll_Click(object sender, EventArgs e)
        {
            lstWarn.Items.Clear();

            ArrayList _lst = (ArrayList)_fileCache[lstSec.SelectedIndex];
            lstWarn.Items.AddRange(_lst.ToArray());
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            lstWarn.Items.Clear();

            KeyValuePair<string, ArrayList> _lib = (KeyValuePair<string, ArrayList>)_libLog[(int)btn.Tag];
            lstWarn.Items.AddRange(_lib.Value.ToArray());
        }

        private string checkHashTab(string line)
        {
            string res = "";
            if(line.Length > 0 && line[0].Equals('['))
            {
                int _end = line.IndexOf(']')-1;
                res = line.Substring(1, _end);
            }
            return res;
        }
        
        private string catLogString(string logLine)
        {
            string res = "";
            string[] lineStr = logLine.Split('-');
            for (int vi = 1; vi < lineStr.Length; ++vi)
            {
                res += lineStr[vi];
            }

            res = res.TrimStart(' ');
            return res;
        }

        private void resetList()
        {
            lstSec.Items.Clear();
            lstFile.Items.Clear();
            lstWarn.Items.Clear();
            _fileCache.Clear();
            _libLog.Clear();
        }
    }
    
}
