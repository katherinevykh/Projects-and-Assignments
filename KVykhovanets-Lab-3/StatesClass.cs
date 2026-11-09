using KVykhovanets_Lab_3.StateInfoDBDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KVykhovanets_Lab_3
{
    public class State_Class:StateInfoDBDataSet
    {
        public string State { get; set; }
        public string Capital { get; set; }
        public int Population { get; set; }
        public string Flag { get; set; }
        public string Flower { get; set; }
        public string Bird { get; set; }
        public string Colors { get; set; }
        public string Cities { get; set; }
        public decimal MedIncome { get; set; }
        public decimal PercCompJobs { get; set; }

        public State_Class(string state, string capital, int population, string flag, string flower, string bird, string colors, string cities, decimal medIncome, decimal percCompJobs)
        {
            State = state;
            Capital = capital;
            Population = population;
            Flag = flag;
            Flower = flower;
            Bird = bird;
            Colors = colors;
            Cities = cities;
            MedIncome = medIncome;
            PercCompJobs = percCompJobs;
        }

        public static StateDetails stateDetails;


        public static void SortData(StateInfoDBDataSet stateTable,
                             RadioButton rbtnStateSortDesc,
                             RadioButton rbtnPopSort,
                             RadioButton rbtnIncomeSort,
                             RadioButton rbtnJobPercSort,
                             StateTableAdapter stateTableAdapter)
        {
            if (rbtnStateSortDesc.Checked)
            {
                stateTableAdapter.FillByStateDesc(stateTable.State);
            }
            else if (rbtnPopSort.Checked)
            {
                stateTableAdapter.FillByPopDesc(stateTable.State);
            }
            else if (rbtnIncomeSort.Checked)
            {
                stateTableAdapter.FillByIncome(stateTable.State);
            }
            else if (rbtnJobPercSort.Checked)
            {
                stateTableAdapter.FillByJobPerc(stateTable.State);
            }
            else //if none of the above selections was made, give the user an error message
            {
                MessageBox.Show("Please select one of the sorting options above to sort the data.");
            }
        }

        public static void FilterData(StateInfoDBDataSet stateTable,
                             RadioButton rbtnNoColorFilter,
                             RadioButton rbtnColorFilter,
                             RadioButton rbtnIncomeOver,
                             RadioButton rbtnIncomeUnder,
                             StateTableAdapter stateTableAdapter)
        {
            if (rbtnNoColorFilter.Checked)
            {
                stateTableAdapter.FillByStatesWithoutColors(stateTable.State);
            }
            else if (rbtnColorFilter.Checked)
            {
                stateTableAdapter.FillByStatesWithColors(stateTable.State);
            }
            else if (rbtnIncomeOver.Checked)
            {
                stateTableAdapter.FillByIncomeOver70(stateTable.State);
            }
            else if (rbtnIncomeUnder.Checked)
            {
                stateTableAdapter.FillByIncomeUnder70(stateTable.State);
            }
            else//if none of the above selections was made, give the user an error message
            {
                MessageBox.Show("Please select one of the sorting options above to sort the data.");
            }
        }
    }

    

}
