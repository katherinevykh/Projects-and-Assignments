namespace KVykhovanets_Lab_3
{
    partial class StateDetails
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
            System.Windows.Forms.Label stateIDLabel;
            System.Windows.Forms.Label stateLabel;
            System.Windows.Forms.Label capitalLabel;
            System.Windows.Forms.Label populationLabel;
            System.Windows.Forms.Label flagDescriptionLabel;
            System.Windows.Forms.Label flowerLabel;
            System.Windows.Forms.Label birdLabel;
            System.Windows.Forms.Label colorsLabel;
            System.Windows.Forms.Label largestCitiesLabel;
            System.Windows.Forms.Label medianIncomeLabel;
            System.Windows.Forms.Label percCompRelatedJobsLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StateDetails));
            this.stateInfoDBDataSet = new KVykhovanets_Lab_3.StateInfoDBDataSet();
            this.stateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stateTableAdapter = new KVykhovanets_Lab_3.StateInfoDBDataSetTableAdapters.StateTableAdapter();
            this.tableAdapterManager = new KVykhovanets_Lab_3.StateInfoDBDataSetTableAdapters.TableAdapterManager();
            this.stateBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
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
            this.stateIDTextBox = new System.Windows.Forms.TextBox();
            this.stateTextBox = new System.Windows.Forms.TextBox();
            this.capitalTextBox = new System.Windows.Forms.TextBox();
            this.populationTextBox = new System.Windows.Forms.TextBox();
            this.flagDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.flowerTextBox = new System.Windows.Forms.TextBox();
            this.birdTextBox = new System.Windows.Forms.TextBox();
            this.colorsTextBox = new System.Windows.Forms.TextBox();
            this.largestCitiesTextBox = new System.Windows.Forms.TextBox();
            this.medianIncomeTextBox = new System.Windows.Forms.TextBox();
            this.percCompRelatedJobsTextBox = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            stateIDLabel = new System.Windows.Forms.Label();
            stateLabel = new System.Windows.Forms.Label();
            capitalLabel = new System.Windows.Forms.Label();
            populationLabel = new System.Windows.Forms.Label();
            flagDescriptionLabel = new System.Windows.Forms.Label();
            flowerLabel = new System.Windows.Forms.Label();
            birdLabel = new System.Windows.Forms.Label();
            colorsLabel = new System.Windows.Forms.Label();
            largestCitiesLabel = new System.Windows.Forms.Label();
            medianIncomeLabel = new System.Windows.Forms.Label();
            percCompRelatedJobsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.stateInfoDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateBindingNavigator)).BeginInit();
            this.stateBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // stateIDLabel
            // 
            stateIDLabel.AutoSize = true;
            stateIDLabel.Location = new System.Drawing.Point(68, 84);
            stateIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            stateIDLabel.Name = "stateIDLabel";
            stateIDLabel.Size = new System.Drawing.Size(66, 16);
            stateIDLabel.TabIndex = 1;
            stateIDLabel.Text = "State ID:";
            // 
            // stateLabel
            // 
            stateLabel.AutoSize = true;
            stateLabel.Location = new System.Drawing.Point(68, 111);
            stateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            stateLabel.Name = "stateLabel";
            stateLabel.Size = new System.Drawing.Size(47, 16);
            stateLabel.TabIndex = 3;
            stateLabel.Text = "State:";
            // 
            // capitalLabel
            // 
            capitalLabel.AutoSize = true;
            capitalLabel.Location = new System.Drawing.Point(68, 139);
            capitalLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            capitalLabel.Name = "capitalLabel";
            capitalLabel.Size = new System.Drawing.Size(60, 16);
            capitalLabel.TabIndex = 5;
            capitalLabel.Text = "Capital:";
            // 
            // populationLabel
            // 
            populationLabel.AutoSize = true;
            populationLabel.Location = new System.Drawing.Point(68, 165);
            populationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            populationLabel.Name = "populationLabel";
            populationLabel.Size = new System.Drawing.Size(85, 16);
            populationLabel.TabIndex = 7;
            populationLabel.Text = "Population:";
            // 
            // flagDescriptionLabel
            // 
            flagDescriptionLabel.AutoSize = true;
            flagDescriptionLabel.Location = new System.Drawing.Point(68, 225);
            flagDescriptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            flagDescriptionLabel.Name = "flagDescriptionLabel";
            flagDescriptionLabel.Size = new System.Drawing.Size(125, 16);
            flagDescriptionLabel.TabIndex = 9;
            flagDescriptionLabel.Text = "Flag Description:";
            // 
            // flowerLabel
            // 
            flowerLabel.AutoSize = true;
            flowerLabel.Location = new System.Drawing.Point(405, 81);
            flowerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            flowerLabel.Name = "flowerLabel";
            flowerLabel.Size = new System.Drawing.Size(57, 16);
            flowerLabel.TabIndex = 11;
            flowerLabel.Text = "Flower:";
            // 
            // birdLabel
            // 
            birdLabel.AutoSize = true;
            birdLabel.Location = new System.Drawing.Point(405, 108);
            birdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            birdLabel.Name = "birdLabel";
            birdLabel.Size = new System.Drawing.Size(39, 16);
            birdLabel.TabIndex = 13;
            birdLabel.Text = "Bird:";
            // 
            // colorsLabel
            // 
            colorsLabel.AutoSize = true;
            colorsLabel.Location = new System.Drawing.Point(405, 136);
            colorsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            colorsLabel.Name = "colorsLabel";
            colorsLabel.Size = new System.Drawing.Size(56, 16);
            colorsLabel.TabIndex = 15;
            colorsLabel.Text = "Colors:";
            // 
            // largestCitiesLabel
            // 
            largestCitiesLabel.AutoSize = true;
            largestCitiesLabel.Location = new System.Drawing.Point(68, 193);
            largestCitiesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            largestCitiesLabel.Name = "largestCitiesLabel";
            largestCitiesLabel.Size = new System.Drawing.Size(106, 16);
            largestCitiesLabel.TabIndex = 17;
            largestCitiesLabel.Text = "Largest Cities:";
            // 
            // medianIncomeLabel
            // 
            medianIncomeLabel.AutoSize = true;
            medianIncomeLabel.Location = new System.Drawing.Point(405, 165);
            medianIncomeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            medianIncomeLabel.Name = "medianIncomeLabel";
            medianIncomeLabel.Size = new System.Drawing.Size(116, 16);
            medianIncomeLabel.TabIndex = 19;
            medianIncomeLabel.Text = "Median Income:";
            // 
            // percCompRelatedJobsLabel
            // 
            percCompRelatedJobsLabel.AutoSize = true;
            percCompRelatedJobsLabel.Location = new System.Drawing.Point(405, 193);
            percCompRelatedJobsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            percCompRelatedJobsLabel.Name = "percCompRelatedJobsLabel";
            percCompRelatedJobsLabel.Size = new System.Drawing.Size(132, 16);
            percCompRelatedJobsLabel.TabIndex = 21;
            percCompRelatedJobsLabel.Text = "% Computer Jobs:";
            // 
            // stateInfoDBDataSet
            // 
            this.stateInfoDBDataSet.DataSetName = "StateInfoDBDataSet";
            this.stateInfoDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stateBindingSource
            // 
            this.stateBindingSource.DataMember = "State";
            this.stateBindingSource.DataSource = this.stateInfoDBDataSet;
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
            this.stateBindingNavigator.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.stateBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.stateBindingNavigator.Size = new System.Drawing.Size(768, 31);
            this.stateBindingNavigator.TabIndex = 0;
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
            // stateIDTextBox
            // 
            this.stateIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stateBindingSource, "StateID", true));
            this.stateIDTextBox.Location = new System.Drawing.Point(201, 81);
            this.stateIDTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.stateIDTextBox.Name = "stateIDTextBox";
            this.stateIDTextBox.Size = new System.Drawing.Size(167, 22);
            this.stateIDTextBox.TabIndex = 2;
            // 
            // stateTextBox
            // 
            this.stateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stateBindingSource, "State", true));
            this.stateTextBox.Location = new System.Drawing.Point(201, 109);
            this.stateTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.stateTextBox.Name = "stateTextBox";
            this.stateTextBox.Size = new System.Drawing.Size(167, 22);
            this.stateTextBox.TabIndex = 4;
            // 
            // capitalTextBox
            // 
            this.capitalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stateBindingSource, "Capital", true));
            this.capitalTextBox.Location = new System.Drawing.Point(201, 136);
            this.capitalTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.capitalTextBox.Name = "capitalTextBox";
            this.capitalTextBox.Size = new System.Drawing.Size(167, 22);
            this.capitalTextBox.TabIndex = 6;
            // 
            // populationTextBox
            // 
            this.populationTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stateBindingSource, "Population", true));
            this.populationTextBox.Location = new System.Drawing.Point(201, 163);
            this.populationTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.populationTextBox.Name = "populationTextBox";
            this.populationTextBox.Size = new System.Drawing.Size(167, 22);
            this.populationTextBox.TabIndex = 8;
            // 
            // flagDescriptionTextBox
            // 
            this.flagDescriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stateBindingSource, "FlagDescription", true));
            this.flagDescriptionTextBox.Location = new System.Drawing.Point(201, 222);
            this.flagDescriptionTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flagDescriptionTextBox.Name = "flagDescriptionTextBox";
            this.flagDescriptionTextBox.Size = new System.Drawing.Size(504, 22);
            this.flagDescriptionTextBox.TabIndex = 10;
            // 
            // flowerTextBox
            // 
            this.flowerTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stateBindingSource, "Flower", true));
            this.flowerTextBox.Location = new System.Drawing.Point(538, 78);
            this.flowerTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowerTextBox.Name = "flowerTextBox";
            this.flowerTextBox.Size = new System.Drawing.Size(167, 22);
            this.flowerTextBox.TabIndex = 12;
            // 
            // birdTextBox
            // 
            this.birdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stateBindingSource, "Bird", true));
            this.birdTextBox.Location = new System.Drawing.Point(538, 105);
            this.birdTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.birdTextBox.Name = "birdTextBox";
            this.birdTextBox.Size = new System.Drawing.Size(167, 22);
            this.birdTextBox.TabIndex = 14;
            // 
            // colorsTextBox
            // 
            this.colorsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stateBindingSource, "Colors", true));
            this.colorsTextBox.Location = new System.Drawing.Point(538, 133);
            this.colorsTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.colorsTextBox.Name = "colorsTextBox";
            this.colorsTextBox.Size = new System.Drawing.Size(167, 22);
            this.colorsTextBox.TabIndex = 16;
            // 
            // largestCitiesTextBox
            // 
            this.largestCitiesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stateBindingSource, "LargestCities", true));
            this.largestCitiesTextBox.Location = new System.Drawing.Point(201, 190);
            this.largestCitiesTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.largestCitiesTextBox.Name = "largestCitiesTextBox";
            this.largestCitiesTextBox.Size = new System.Drawing.Size(167, 22);
            this.largestCitiesTextBox.TabIndex = 18;
            // 
            // medianIncomeTextBox
            // 
            this.medianIncomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stateBindingSource, "MedianIncome", true));
            this.medianIncomeTextBox.Location = new System.Drawing.Point(538, 163);
            this.medianIncomeTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.medianIncomeTextBox.Name = "medianIncomeTextBox";
            this.medianIncomeTextBox.Size = new System.Drawing.Size(167, 22);
            this.medianIncomeTextBox.TabIndex = 20;
            // 
            // percCompRelatedJobsTextBox
            // 
            this.percCompRelatedJobsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stateBindingSource, "PercCompRelatedJobs", true));
            this.percCompRelatedJobsTextBox.Location = new System.Drawing.Point(538, 190);
            this.percCompRelatedJobsTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.percCompRelatedJobsTextBox.Name = "percCompRelatedJobsTextBox";
            this.percCompRelatedJobsTextBox.Size = new System.Drawing.Size(167, 22);
            this.percCompRelatedJobsTextBox.TabIndex = 22;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(338, 313);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 38);
            this.btnExit.TabIndex = 24;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // StateDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(768, 428);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(stateIDLabel);
            this.Controls.Add(this.stateIDTextBox);
            this.Controls.Add(stateLabel);
            this.Controls.Add(this.stateTextBox);
            this.Controls.Add(capitalLabel);
            this.Controls.Add(this.capitalTextBox);
            this.Controls.Add(populationLabel);
            this.Controls.Add(this.populationTextBox);
            this.Controls.Add(flagDescriptionLabel);
            this.Controls.Add(this.flagDescriptionTextBox);
            this.Controls.Add(flowerLabel);
            this.Controls.Add(this.flowerTextBox);
            this.Controls.Add(birdLabel);
            this.Controls.Add(this.birdTextBox);
            this.Controls.Add(colorsLabel);
            this.Controls.Add(this.colorsTextBox);
            this.Controls.Add(largestCitiesLabel);
            this.Controls.Add(this.largestCitiesTextBox);
            this.Controls.Add(medianIncomeLabel);
            this.Controls.Add(this.medianIncomeTextBox);
            this.Controls.Add(percCompRelatedJobsLabel);
            this.Controls.Add(this.percCompRelatedJobsTextBox);
            this.Controls.Add(this.stateBindingNavigator);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "StateDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StateDetails";
            this.Load += new System.EventHandler(this.StateDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stateInfoDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateBindingNavigator)).EndInit();
            this.stateBindingNavigator.ResumeLayout(false);
            this.stateBindingNavigator.PerformLayout();
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
        private System.Windows.Forms.TextBox stateIDTextBox;
        private System.Windows.Forms.TextBox stateTextBox;
        private System.Windows.Forms.TextBox capitalTextBox;
        private System.Windows.Forms.TextBox populationTextBox;
        private System.Windows.Forms.TextBox flagDescriptionTextBox;
        private System.Windows.Forms.TextBox flowerTextBox;
        private System.Windows.Forms.TextBox birdTextBox;
        private System.Windows.Forms.TextBox colorsTextBox;
        private System.Windows.Forms.TextBox largestCitiesTextBox;
        private System.Windows.Forms.TextBox medianIncomeTextBox;
        private System.Windows.Forms.TextBox percCompRelatedJobsTextBox;
        private System.Windows.Forms.Button btnExit;
    }
}