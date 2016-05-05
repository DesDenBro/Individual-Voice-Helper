﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class ControlBookmarksForm : Form
    {
        private List<Bookmark> _bookmarks;

        private List<Bookmark> _bookmarksForAddInDB = new List<Bookmark>();
        private List<Bookmark> _bookmarksForUpdateInDB = new List<Bookmark>();
        private List<Bookmark> _bookmarksForDeleteFromDB = new List<Bookmark>();

        public List<Bookmark> Bookmarks { get { return _bookmarks; } }

        bool _smthChanged = false;

        public ControlBookmarksForm()
        {
            InitializeComponent();

            _bookmarks = VoiceAnalizer.getVoiceAnalizer().Bookmarks;

            for (int i = 0; i < _bookmarks.Count; i++)
                bookmarks_cb.Items.Add(_bookmarks[i].Name);

            if (bookmarks_cb.Items.Count > 0) bookmarks_cb.SelectedIndex = 0;
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            NoteForm nfname = new NoteForm("Name of new bookmark", "Write name of new bookmark", "Add", "Write bookmark name");
            nfname.ShowDialog();
            if (nfname.DialogResult == DialogResult.OK)
            {
                NoteForm nflink = new NoteForm("Link of new bookmark", "Write link of new bookmark", "Add", "Write bookmark link", "https://");
                nflink.ShowDialog();
                if (nflink.DialogResult == DialogResult.OK)
                {
                    _bookmarks.Add(new Bookmark(nfname.Note, string.Format("{0}{1}{2}", '"', nflink.Note, '"')));
                    _bookmarksForAddInDB.Add(_bookmarks[_bookmarks.Count - 1]);
                    bookmarks_cb.Items.Add(nfname.Note);
                    _smthChanged = true;

                    bookmarks_cb.SelectedIndex = bookmarks_cb.Items.Count - 1;
                }
            }
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            NoteForm nflink = new NoteForm("Link of bookmark", "Write link of new bookmark", "Add", "Write bookmark link", _bookmarks[bookmarks_cb.SelectedIndex].Link);
            nflink.ShowDialog();
            if (nflink.DialogResult == DialogResult.OK)
            {
                _bookmarks[bookmarks_cb.SelectedIndex].Link = nflink.Note;
                _bookmarksForUpdateInDB.Add(_bookmarks[bookmarks_cb.SelectedIndex]);
                link_tb.Text = _bookmarks[bookmarks_cb.SelectedIndex].Link;
                _smthChanged = true;
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you really want to delete this bookmark?", "Attention!", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                _bookmarksForDeleteFromDB.Add(_bookmarks[bookmarks_cb.SelectedIndex]);
                _bookmarks.Remove(_bookmarks[bookmarks_cb.SelectedIndex]);
                bookmarks_cb.Items.RemoveAt(bookmarks_cb.SelectedIndex);
                link_tb.Text = "";
                _smthChanged = true;

                if (bookmarks_cb.Items.Count > 0) bookmarks_cb.SelectedIndex = 0;
            }
        }

        private void bookmarks_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            link_tb.Text = _bookmarks[bookmarks_cb.SelectedIndex].Link;
        }

        private void ControlBookmarksForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_smthChanged)
            {
                DialogResult dr = MessageBox.Show("Do you want to save your changes?", "Attention!", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    // Сначала добавляем новые вкладки
                    Gateway.addNewBookmarksInDB(_bookmarksForAddInDB);

                    // Потом делаем для них апдейт в БД
                    foreach (var item in _bookmarksForUpdateInDB)
                        Gateway.updateBookmarkInDB(item);

                    // И удаляем нужные
                    foreach (var item in _bookmarksForDeleteFromDB)
                        Gateway.deleteBookmarkFromDB(item);

                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void importBM_btn_Click(object sender, EventArgs e)
        {
            AbstractBookmarkReader[] allChoises = new AbstractBookmarkReader[] { new BookmarksReaderChrome(), new BookmarksReaderYandexBrowser() };
            List<Bookmark> newBM = allChoises[browserChoice_cb.SelectedIndex].Parse();
            
            bool addOrNot; int newBMAdded = 0;
            for (int i = 0; i < newBM.Count; i++)
            {
                addOrNot = true;

                for (int j = 0; j < _bookmarks.Count; j++)
                {
                    if (newBM[i].Name == _bookmarks[j].Name)
                    {
                        addOrNot = false;
                        break;
                    }
                }

                if (addOrNot)
                {
                    _bookmarksForAddInDB.Add(newBM[i]);
                    _bookmarks.Add(newBM[i]);
                    bookmarks_cb.Items.Add(newBM[i].Name);
                    _smthChanged = true; newBMAdded++;
                }
            }

            if (_smthChanged) bookmarks_cb.SelectedIndex = 0;

            MessageBox.Show(string.Format("New bokmarks added: {0}", newBMAdded), "Attention!");
        }
    }
}
