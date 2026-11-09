using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KVykhovanets_Lab_3.StateInfoDBDataSet;

namespace KVykhovanets_Lab_3
{
    //Katherine Vykhovanets
    //CPT 206
    //Lab 3
    public partial class EmployeeDatabase : Form
    {
        private StateDataTable stateTable;
        //private State_Class State_Class = new State_Class();

        //StateDetails stateDetails = new StateDetails(state);
        //public static StateDetails stateDetails;
        public EmployeeDatabase()
        {
            InitializeComponent();
        }

        private void stateBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.stateBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.stateInfoDBDataSet);

        }
        //Fill table with data from database
        private void EmployeeDatabase_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stateInfoDBDataSet.State' table. You can move, or remove it, as needed.
            this.stateTableAdapter.Fill(this.stateInfoDBDataSet.State);
            
            //when the form loads, this ensures that it also loads each state from the state database into the dropdown box so the user can make a selection
            foreach (StateInfoDBDataSet.StateRow StateColumn in stateInfoDBDataSet.State)
            {
                cBoxStates.Items.Add(StateColumn.State.ToString());
            }
        }
        //the button the user selects after choosing a state in the drop down box
        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            //if a state is selected... (if not it is -1)
            if (cBoxStates.SelectedIndex != -1)
            {
                //the stateDetails = the state record that matches the state selected
                StateDetails stateDetails = new StateDetails(cBoxStates.SelectedIndex, this);
                stateDetails.ShowDialog(); //opens the state record in the state details form
            }
            else //if no state is selected (exception)
            {
                MessageBox.Show("Please select a state.");
            }
        }

        
        //button the user selects to sort the data with whichever sorting option they selected (radio box)
        private void btnSortData_Click(object sender, EventArgs e)
        {
            try
            {
                bool sortByStateDesc = rbtnStateSortDesc.Checked;
                bool sortByPop = rbtnPopSort.Checked;
                bool sortByIncome = rbtnIncomeSort.Checked;
                bool sortByJobPerc = rbtnJobPercSort.Checked;

                State_Class.SortData(stateInfoDBDataSet, rbtnStateSortDesc, rbtnPopSort, rbtnIncomeSort, rbtnJobPercSort, stateTableAdapter);

            }
            catch (Exception ex)
            {
                // Show the error message
                MessageBox.Show(ex.Message);
            }

        }
        //button the user selects to sort the data with whichever filtering option they selected (radio box)
        private void btnFilterData_Click(object sender, EventArgs e)
        {
            try
            {
                bool noColorFilter = rbtnNoColorFilter.Checked;
                bool colorFilter = rbtnColorFilter.Checked;
                bool incomeOver = rbtnIncomeOver.Checked;
                bool incomeUnder = rbtnIncomeUnder.Checked;

                State_Class.FilterData(stateInfoDBDataSet, rbtnNoColorFilter, rbtnColorFilter, rbtnIncomeOver, rbtnIncomeUnder, stateTableAdapter);

            }
            catch (Exception ex)
            {
                // Show the error message
                MessageBox.Show(ex.Message);
            }

        }
    }
}
