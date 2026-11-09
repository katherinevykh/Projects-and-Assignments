using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KVykhovanets_Lab_3
{
    public partial class StateDetails : Form
    {
        int indexNum;
        EmployeeDatabase currentForm;

        //the drop down item that was selected in the main form is moved into this form too (initialize the indexNum and currentForm)
        public StateDetails(int indexNum, EmployeeDatabase currentForm)
        {
            InitializeComponent();
            this.indexNum = indexNum;
            this.currentForm = currentForm;
        }

        private void stateBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.stateBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.stateInfoDBDataSet);
        }
        //on load, the details are filled in based on the state that was selected in the drop down (the position of the selected item in the drop down which equals variable indexNum)
        private void StateDetails_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stateInfoDBDataSet.State' table. You can move, or remove it, as needed.
            this.stateTableAdapter.Fill(this.stateInfoDBDataSet.State);
            stateBindingSource.Position = indexNum;
        }
        //exit button that closes the state details form and goes back to main form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
