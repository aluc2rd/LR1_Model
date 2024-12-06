
namespace LR1_Model
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputText = new System.Windows.Forms.TextBox();
            this.tmpText = new System.Windows.Forms.TextBox();
            this.outputText = new System.Windows.Forms.TextBox();
            this.buttonBegin = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tableStack = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tableStack)).BeginInit();
            this.SuspendLayout();
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(22, 65);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(267, 22);
            this.inputText.TabIndex = 0;
            // 
            // tmpText
            // 
            this.tmpText.Location = new System.Drawing.Point(22, 266);
            this.tmpText.Name = "tmpText";
            this.tmpText.Size = new System.Drawing.Size(267, 22);
            this.tmpText.TabIndex = 1;
            // 
            // outputText
            // 
            this.outputText.Location = new System.Drawing.Point(23, 332);
            this.outputText.Name = "outputText";
            this.outputText.Size = new System.Drawing.Size(267, 22);
            this.outputText.TabIndex = 2;
            // 
            // buttonBegin
            // 
            this.buttonBegin.Location = new System.Drawing.Point(22, 174);
            this.buttonBegin.Name = "buttonBegin";
            this.buttonBegin.Size = new System.Drawing.Size(127, 28);
            this.buttonBegin.TabIndex = 3;
            this.buttonBegin.Tag = "1";
            this.buttonBegin.Text = "Преобразовать";
            this.buttonBegin.UseVisualStyleBackColor = true;
            this.buttonBegin.Click += new System.EventHandler(this.button_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(23, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(267, 28);
            this.button2.TabIndex = 4;
            this.button2.Tag = "3";
            this.button2.Text = "Ввести выражение";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(23, 140);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(127, 28);
            this.button3.TabIndex = 5;
            this.button3.Tag = "2";
            this.button3.Text = "Очистить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(22, 208);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(149, 21);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "пошаговый режим";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tableStack
            // 
            this.tableStack.AllowUserToDeleteRows = false;
            this.tableStack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableStack.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.tableStack.Location = new System.Drawing.Point(468, 12);
            this.tableStack.MultiSelect = false;
            this.tableStack.Name = "tableStack";
            this.tableStack.RowHeadersVisible = false;
            this.tableStack.RowHeadersWidth = 51;
            this.tableStack.RowTemplate.Height = 24;
            this.tableStack.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tableStack.Size = new System.Drawing.Size(320, 299);
            this.tableStack.TabIndex = 7;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Стек";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Указатель";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 371);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 17);
            this.label6.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Промежуточное вычисление";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(268, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Выходная строка (в инфиксной форме)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(272, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Входная строка (в постфиксной форме)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tableStack);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonBegin);
            this.Controls.Add(this.outputText);
            this.Controls.Add(this.tmpText);
            this.Controls.Add(this.inputText);
            this.Name = "Form1";
            this.Text = "Преобразование выражения из постфиксной формы в инфиксную";
            ((System.ComponentModel.ISupportInitialize)(this.tableStack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox inputText;
        public System.Windows.Forms.TextBox tmpText;
        public System.Windows.Forms.TextBox outputText;
        private System.Windows.Forms.Button buttonBegin;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.DataGridView tableStack;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

