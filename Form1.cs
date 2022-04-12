using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NotesApp
{
    public partial class Form1 : Form
    {
        List<Note> _notes = new List<Note>();
        
        //Cada método debe hacer lo mínimo e indispensable

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNote.Text) && !string.IsNullOrEmpty(txtTitle.Text))
            {
                var note = new Note();
                note.note = txtNote.Text;
                note.title = txtTitle.Text;
                _notes.Add(note);
            }
            PopulateNotes();
            AvoidComponents();

        }

        private void AvoidComponents() 
        {
            txtTitle.Text = string.Empty;
            txtNote.Text = string.Empty;
        }

        private void PopulateNotes()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = _notes;
            grdNotes.DataSource = bs;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AvoidComponents();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (grdNotes.SelectedRows != null) 
            {
                var title = grdNotes.SelectedCells[0].Value.ToString();
                var note = GetNotesByTitle(title);

                txtNote.Text = note;
                txtTitle.Text = title;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grdNotes.SelectedRows != null)
            {
                var title = grdNotes.SelectedCells[0].Value.ToString();
                DeleteByTitle(title);
            }
            PopulateNotes();
        }

        private string GetNotesByTitle(string title) 
        {
            var notes = string.Empty;

            foreach (var note in _notes)
            {
                if (note.title == title)
                {
                    notes = note.note;
                }
            }
            return notes;
        }

        private void DeleteByTitle(string title) 
        {
            Note noteToDelete = null;
            
            foreach (var note in _notes)
            {
                if (note.title == title)
                {
                    noteToDelete = note;
                }
            }
            if (noteToDelete != null) 
            { 
                _notes.Remove(noteToDelete);
            }
        }
    }
}
