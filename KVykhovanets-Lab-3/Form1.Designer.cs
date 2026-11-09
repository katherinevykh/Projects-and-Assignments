namespace KVykhovanets_Lab_3
{
    partial class EmployeeDatabase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeDatabase));
            this.stateBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.stateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stateInfoDBDataSet = new KVykhovanets_Lab_3.StateInfoDBDataSet();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.stateBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.stateDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBoxStates = new System.Windows.Forms.ComboBox();
            this.btnShowDetails = new System.Windows.Forms.Button();
            this.btnSortData = new System.Windows.Forms.Button();
            this.gBoxSort = new System.Windows.Forms.GroupBox();
            this.rbtnJobPercSort = new System.Windows.Forms.RadioButton();
            this.rbtnIncomeSort = new System.Windows.Forms.RadioButton();
            this.rbtnPopSort = new System.Windows.Forms.RadioButton();
            this.rbtnStateSortDesc = new System.Windows.Forms.RadioButton();
            this.btnFilterData = new System.Windows.Forms.Button();
            this.gBoxFilter = new System.Windows.Forms.GroupBox();
            this.rbtnIncomeUnder = new System.Windows.Forms.RadioButton();
            this.rbtnIncomeOver = new System.Windows.Forms.RadioButton();
            this.rbtnNoColorFilter = new System.Windows.Forms.RadioButton();
            this.rbtnColorFilter = new System.Windows.Forms.RadioButton();
            this.stateTableAdapter = new KVykhovanets_Lab_3.StateInfoDBDataSetTableAdapters.StateTableAdapter();
            this.tableAdapterManager = new KVykhovanets_Lab_3.StateInfoDBDataSetTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.stateBindingNavigator)).BeginInit();
            this.stateBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateInfoDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateDataGridView)).BeginInit();
            this.gBoxSort.SuspendLayout();
            this.gBoxFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // stateBindingNavigator
            // 
            this.stateBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.stateBindingNavigator.BindingSource = this.stateBindingSource;
            this.stateBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.stateBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.stateBindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.stateBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.stateBindingNavigatorSaveItem});
            this.stateBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.stateBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.stateBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.stateBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.stateBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.stateBindingNavigator.Name = "stateBindingNavigator";
            this.stateBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.stateBindingNavigator.Size = new System.Drawing.Size(1213, 31);
            this.stateBindingNavigator.TabIndex = 6;
            this.stateBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // stateBindingSource
            // 
            this.stateBindingSource.DataMember = "State";
            this.stateBindingSource.DataSource = this.stateInfoDBDataSet;
            // 
            // stateInfoDBDataSet
            // 
            this.stateInfoDBDataSet.DataSetName = "StateInfoDBDataSet";
            this.stateInfoDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 28);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(28, 28);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // stateBindingNavigatorSaveItem
            // 
            this.stateBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stateBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("stateBindingNavigatorSaveItem.Image")));
            this.stateBindingNavigatorSaveItem.Name = "stateBindingNavigatorSaveItem";
            this.stateBindingNavigatorSaveItem.Size = new System.Drawing.Size(28, 28);
            this.stateBindingNavigatorSaveItem.Text = "Save Data";
            this.stateBindingNavigatorSaveItem.Click += new System.EventHandler(this.stateBindingNavigatorSaveItem_Click);
            // 
            // stateDataGridView
            // 
            this.stateDataGridView.AutoGenerateColumns = false;
            this.stateDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stateDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11});
            this.stateDataGridView.DataSource = this.stateBindingSource;
            this.stateDataGridView.Location = new System.Drawing.Point(38, 96);
            this.stateDataGridView.Name = "stateDataGridView";
            this.stateDataGridView.Size = new System.Drawing.Size(1142, 220);
            this.stateDataGridView.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "StateID";
            this.dataGridViewTextBoxColumn1.HeaderText = "StateID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "State";
            this.dataGridViewTextBoxColumn2.HeaderText = "State";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Capital";
            this.dataGridViewTextBoxColumn3.HeaderText = "Capital";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Population";
            this.dataGridViewTextBoxColumn4.HeaderText = "Population";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "FlagDescription";
            this.dataGridViewTextBoxColumn5.HeaderText = "FlagDescription";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Flower";
            this.dataGridViewTextBoxColumn6.HeaderText = "Flower";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Bird";
            this.dataGridViewTextBoxColumn7.HeaderText = "Bird";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Colors";
            this.dataGridViewTextBoxColumn8.HeaderText = "Colors";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "LargestCities";
            this.dataGridViewTextBoxColumn9.HeaderText = "LargestCities";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "MedianIncome";
            this.dataGridViewTextBoxColumn10.HeaderText = "MedianIncome";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "PercCompRelatedJobs";
            this.dataGridViewTextBoxColumn11.HeaderText = "PercCompRelatedJobs";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // cBoxStates
            // 
            this.cBoxStates.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxStates.FormattingEnabled = true;
            this.cBoxStates.Location = new System.Drawing.Point(193, 416);
            this.cBoxStates.Name = "cBoxStates";
            this.cBoxStates.Size = new System.Drawing.Size(132, 24);
            this.cBoxStates.TabIndex = 0;
            // 
            // btnShowDetails
            // 
            this.btnShowDetails.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnShowDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowDetails.Location = new System.Drawing.Point(202, 522);
            this.btnShowDetails.Name = "btnShowDetails";
            this.btnShowDetails.Size = new System.Drawing.Size(112, 53);
            this.btnShowDetails.TabIndex = 1;
            this.btnShowDetails.Text = "Show Details";
            this.btnShowDetails.UseVisualStyleBackColor = true;
            this.btnShowDetails.Click += new System.EventHandler(this.btnShowDetails_Click);
            // 
            // btnSortData
            // 
            this.btnSortData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSortData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSortData.Location = new System.Drawing.Point(532, 522);
            this.btnSortData.Name = "btnSortData";
            this.btnSortData.Size = new System.Drawing.Size(112, 53);
            this.btnSortData.TabIndex = 3;
            this.btnSortData.Text = "Sort Data";
            this.btnSortData.UseVisualStyleBackColor = true;
            this.btnSortData.Click += new System.EventHandler(this.btnSortData_Click);
            // 
            // gBoxSort
            // 
            this.gBoxSort.Controls.Add(this.rbtnJobPercSort);
            this.gBoxSort.Controls.Add(this.rbtnIncomeSort);
            this.gBoxSort.Controls.Add(this.rbtnPopSort);
            this.gBoxSort.Controls.Add(this.rbtnStateSortDesc);
            this.gBoxSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxSort.Location = new System.Drawing.Point(476, 363);
            this.gBoxSort.Name = "gBoxSort";
            this.gBoxSort.Size = new System.Drawing.Size(240, 133);
            this.gBoxSort.TabIndex = 2;
            this.gBoxSort.TabStop = false;
            this.gBoxSort.Text = "Sorting Options";
            // 
            // rbtnJobPercSort
            // 
            this.rbtnJobPercSort.AutoSize = true;
            this.rbtnJobPercSort.Location = new System.Drawing.Point(28, 102);
            this.rbtnJobPercSort.Name = "rbtnJobPercSort";
            this.rbtnJobPercSort.Size = new System.Drawing.Size(188, 20);
            this.rbtnJobPercSort.TabIndex = 3;
            this.rbtnJobPercSort.TabStop = true;
            this.rbtnJobPercSort.Text = "Sort by Job Percentage";
            this.rbtnJobPercSort.UseVisualStyleBackColor = true;
            // 
            // rbtnIncomeSort
            // 
            this.rbtnIncomeSort.AutoSize = true;
            this.rbtnIncomeSort.Location = new System.Drawing.Point(28, 76);
            this.rbtnIncomeSort.Name = "rbtnIncomeSort";
            this.rbtnIncomeSort.Size = new System.Drawing.Size(128, 20);
            this.rbtnIncomeSort.TabIndex = 2;
            this.rbtnIncomeSort.TabStop = true;
            this.rbtnIncomeSort.Text = "Sort by Income";
            this.rbtnIncomeSort.UseVisualStyleBackColor = true;
            // 
            // rbtnPopSort
            // 
            this.rbtnPopSort.AutoSize = true;
            this.rbtnPopSort.Location = new System.Drawing.Point(28, 50);
            this.rbtnPopSort.Name = "rbtnPopSort";
            this.rbtnPopSort.Size = new System.Drawing.Size(152, 20);
            this.rbtnPopSort.TabIndex = 1;
            this.rbtnPopSort.TabStop = true;
            this.rbtnPopSort.Text = "Sort by Population";
            this.rbtnPopSort.UseVisualStyleBackColor = true;
            // 
            // rbtnStateSortDesc
            // 
            this.rbtnStateSortDesc.AutoSize = true;
            this.rbtnStateSortDesc.Location = new System.Drawing.Point(28, 24);
            this.rbtnStateSortDesc.Name = "rbtnStateSortDesc";
            this.rbtnStateSortDesc.Size = new System.Drawing.Size(201, 20);
            this.rbtnStateSortDesc.TabIndex = 0;
            this.rbtnStateSortDesc.TabStop = true;
            this.rbtnStateSortDesc.Text = "Sort by State Descending";
            this.rbtnStateSortDesc.UseVisualStyleBackColor = true;
            // 
            // btnFilterData
            // 
            this.btnFilterData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFilterData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilterData.Location = new System.Drawing.Point(848, 522);
            this.btnFilterData.Name = "btnFilterData";
            this.btnFilterData.Size = new System.Drawing.Size(112, 53);
            this.btnFilterData.TabIndex = 5;
            this.btnFilterData.Text = "Filter Data";
            this.btnFilterData.UseVisualStyleBackColor = true;
            this.btnFilterData.Click += new System.EventHandler(this.btnFilterData_Click);
            // 
            // gBoxFilter
            // 
            this.gBoxFilter.Controls.Add(this.rbtnIncomeUnder);
            this.gBoxFilter.Controls.Add(this.rbtnIncomeOver);
            this.gBoxFilter.Controls.Add(this.rbtnNoColorFilter);
            this.gBoxFilter.Controls.Add(this.rbtnColorFilter);
            this.gBoxFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxFilter.Location = new System.Drawing.Point(792, 363);
            this.gBoxFilter.Name = "gBoxFilter";
            this.gBoxFilter.Size = new System.Drawing.Size(240, 133);
            this.gBoxFilter.TabIndex = 4;
            this.gBoxFilter.TabStop = false;
            this.gBoxFilter.Text = "Filtering Options";
            // 
            // rbtnIncomeUnder
            // 
            this.rbtnIncomeUnder.AutoSize = true;
            this.rbtnIncomeUnder.Location = new System.Drawing.Point(28, 105);
            this.rbtnIncomeUnder.Name = "rbtnIncomeUnder";
            this.rbtnIncomeUnder.Size = new System.Drawing.Size(143, 20);
            this.rbtnIncomeUnder.TabIndex = 3;
            this.rbtnIncomeUnder.TabStop = true;
            this.rbtnIncomeUnder.Text = "Income < $70,000";
            this.rbtnIncomeUnder.UseVisualStyleBackColor = true;
            // 
            // rbtnIncomeOver
            // 
            this.rbtnIncomeOver.AutoSize = true;
            this.rbtnIncomeOver.Location = new System.Drawing.Point(28, 79);
            this.rbtnIncomeOver.Name = "rbtnIncomeOver";
            this.rbtnIncomeOver.Size = new System.Drawing.Size(151, 20);
            this.rbtnIncomeOver.TabIndex = 2;
            this.rbtnIncomeOver.TabStop = true;
            this.rbtnIncomeOver.Text = "Income >= $70,000";
            this.rbtnIncomeOver.UseVisualStyleBackColor = true;
            // 
            // rbtnNoColorFilter
            // 
            this.rbtnNoColorFilter.AutoSize = true;
            this.rbtnNoColorFilter.Location = new System.Drawing.Point(28, 53);
            this.rbtnNoColorFilter.Name = "rbtnNoColorFilter";
            this.rbtnNoColorFilter.Size = new System.Drawing.Size(169, 20);
            this.rbtnNoColorFilter.TabIndex = 1;
            this.rbtnNoColorFilter.TabStop = true;
            this.rbtnNoColorFilter.Text = "States without Colors";
            this.rbtnNoColorFilter.UseVisualStyleBackColor = true;
            // 
            // rbtnColorFilter
            // 
            this.rbtnColorFilter.AutoSize = true;
            this.rbtnColorFilter.Location = new System.Drawing.Point(28, 27);
            this.rbtnColorFilter.Name = "rbtnColorFilter";
            this.rbtnColorFilter.Size = new System.Drawing.Size(148, 20);
            this.rbtnColorFilter.TabIndex = 0;
            this.rbtnColorFilter.TabStop = true;
            this.rbtnColorFilter.Text = "States with Colors";
            this.rbtnColorFilter.UseVisualStyleBackColor = true;
            // 
            // stateTableAdapter
            // 
            this.stateTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.StateTableAdapter = this.stateTableAdapter;
            this.tableAdapterManager.UpdateOrder = KVykhovanets_Lab_3.StateInfoDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // EmployeeDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1213, 643);
            this.Controls.Add(this.btnFilterData);
            this.Controls.Add(this.gBoxFilter);
            this.Controls.Add(this.btnSortData);
            this.Controls.Add(this.gBoxSort);
            this.Controls.Add(this.btnShowDetails);
            this.Controls.Add(this.cBoxStates);
            this.Controls.Add(this.stateDataGridView);
            this.Controls.Add(this.stateBindingNavigator);
            this.Name = "EmployeeDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Database                             ";
            this.Load += new System.EventHandler(this.EmployeeDatabase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stateBindingNavigator)).EndInit();
            this.stateBindingNavigator.ResumeLayout(false);
            this.stateBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateInfoDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateDataGridView)).EndInit();
            this.gBoxSort.ResumeLayout(false);
            this.gBoxSort.PerformLayout();
            this.gBoxFilter.ResumeLayout(false);
            this.gBoxFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StateInfoDBDataSet stateInfoDBDataSet;
        private System.Windows.Forms.BindingSource stateBindingSource;
        private StateInfoDBDataSetTableAdapters.StateTableAdapter stateTableAdapter;
        private StateInfoDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator stateBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton stateBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView stateDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.ComboBox cBoxStates;
        private System.Windows.Forms.Button btnShowDetails;
        private System.Windows.Forms.Button btnSortData;
        private System.Windows.Forms.GroupBox gBoxSort;
        private System.Windows.Forms.RadioButton rbtnPopSort;
        private System.Windows.Forms.RadioButton rbtnStateSortDesc;
        private System.Windows.Forms.Button btnFilterData;
        private System.Windows.Forms.GroupBox gBoxFilter;
        private System.Windows.Forms.RadioButton rbtnColorFilter;
        private System.Windows.Forms.RadioButton rbtnJobPercSort;
        private System.Windows.Forms.RadioButton rbtnIncomeSort;
        private System.Windows.Forms.RadioButton rbtnNoColorFilter;
        private System.Windows.Forms.RadioButton rbtnIncomeOver;
        private System.Windows.Forms.RadioButton rbtnIncomeUnder;
    }
}

