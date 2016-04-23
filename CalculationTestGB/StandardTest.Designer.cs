namespace CalculationTestGB
{
    partial class StandardTest
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Test = new System.Windows.Forms.Button();
            this.button_LoadData = new System.Windows.Forms.Button();
            this.button_Comprehensive = new System.Windows.Forms.Button();
            this.button_LoadDataComprehensive = new System.Windows.Forms.Button();
            this.button_EnergyComsumptionWithFormula = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Test
            // 
            this.button_Test.Location = new System.Drawing.Point(338, 12);
            this.button_Test.Name = "button_Test";
            this.button_Test.Size = new System.Drawing.Size(111, 23);
            this.button_Test.TabIndex = 0;
            this.button_Test.Text = "测试全部";
            this.button_Test.UseVisualStyleBackColor = true;
            this.button_Test.Click += new System.EventHandler(this.button_Test_Click);
            // 
            // button_LoadData
            // 
            this.button_LoadData.Location = new System.Drawing.Point(12, 12);
            this.button_LoadData.Name = "button_LoadData";
            this.button_LoadData.Size = new System.Drawing.Size(104, 23);
            this.button_LoadData.TabIndex = 1;
            this.button_LoadData.Text = "初始化数据";
            this.button_LoadData.UseVisualStyleBackColor = true;
            this.button_LoadData.Click += new System.EventHandler(this.button_LoadData_Click);
            // 
            // button_Comprehensive
            // 
            this.button_Comprehensive.Location = new System.Drawing.Point(338, 41);
            this.button_Comprehensive.Name = "button_Comprehensive";
            this.button_Comprehensive.Size = new System.Drawing.Size(111, 23);
            this.button_Comprehensive.TabIndex = 2;
            this.button_Comprehensive.Text = "测试综合";
            this.button_Comprehensive.UseVisualStyleBackColor = true;
            this.button_Comprehensive.Click += new System.EventHandler(this.button_Comprehensive_Click);
            // 
            // button_LoadDataComprehensive
            // 
            this.button_LoadDataComprehensive.Location = new System.Drawing.Point(12, 41);
            this.button_LoadDataComprehensive.Name = "button_LoadDataComprehensive";
            this.button_LoadDataComprehensive.Size = new System.Drawing.Size(104, 23);
            this.button_LoadDataComprehensive.TabIndex = 3;
            this.button_LoadDataComprehensive.Text = "初始化综合数据";
            this.button_LoadDataComprehensive.UseVisualStyleBackColor = true;
            this.button_LoadDataComprehensive.Click += new System.EventHandler(this.button_LoadDataComprehensive_Click);
            // 
            // button_EnergyComsumptionWithFormula
            // 
            this.button_EnergyComsumptionWithFormula.Location = new System.Drawing.Point(338, 70);
            this.button_EnergyComsumptionWithFormula.Name = "button_EnergyComsumptionWithFormula";
            this.button_EnergyComsumptionWithFormula.Size = new System.Drawing.Size(111, 23);
            this.button_EnergyComsumptionWithFormula.TabIndex = 4;
            this.button_EnergyComsumptionWithFormula.Text = "测试带公式全部";
            this.button_EnergyComsumptionWithFormula.UseVisualStyleBackColor = true;
            this.button_EnergyComsumptionWithFormula.Click += new System.EventHandler(this.button_EnergyComsumptionWithFormula_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 254);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "测试自动计算综合电耗";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StandardTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 418);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_EnergyComsumptionWithFormula);
            this.Controls.Add(this.button_LoadDataComprehensive);
            this.Controls.Add(this.button_Comprehensive);
            this.Controls.Add(this.button_LoadData);
            this.Controls.Add(this.button_Test);
            this.Name = "StandardTest";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Test;
        private System.Windows.Forms.Button button_LoadData;
        private System.Windows.Forms.Button button_Comprehensive;
        private System.Windows.Forms.Button button_LoadDataComprehensive;
        private System.Windows.Forms.Button button_EnergyComsumptionWithFormula;
        private System.Windows.Forms.Button button1;
    }
}

