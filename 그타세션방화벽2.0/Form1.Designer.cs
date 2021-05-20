namespace 그타세션방화벽2._0
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.상태정보 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.개인세션생성 = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.SH_B = new System.Windows.Forms.Button();
            this.삭제 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.주소추가 = new System.Windows.Forms.Button();
            this.주소텍스트 = new System.Windows.Forms.TextBox();
            this.초기화 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // 상태정보
            // 
            this.상태정보.AutoSize = true;
            this.상태정보.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.상태정보.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.상태정보.Location = new System.Drawing.Point(22, 384);
            this.상태정보.Name = "상태정보";
            this.상태정보.Size = new System.Drawing.Size(49, 19);
            this.상태정보.TabIndex = 12;
            this.상태정보.Text = "상태";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // 개인세션생성
            // 
            this.개인세션생성.Location = new System.Drawing.Point(38, 47);
            this.개인세션생성.Name = "개인세션생성";
            this.개인세션생성.Size = new System.Drawing.Size(293, 75);
            this.개인세션생성.TabIndex = 13;
            this.개인세션생성.Text = "1인공개세션만들기";
            this.개인세션생성.UseVisualStyleBackColor = true;
            this.개인세션생성.Click += new System.EventHandler(this.개인세션생성_Click);
            // 
            // Exit
            // 
            this.Exit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Exit.BackColor = System.Drawing.Color.Red;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Exit.Location = new System.Drawing.Point(674, 0);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(42, 29);
            this.Exit.TabIndex = 14;
            this.Exit.Text = "X";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // SH_B
            // 
            this.SH_B.BackColor = System.Drawing.Color.Red;
            this.SH_B.Font = new System.Drawing.Font("나눔고딕", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SH_B.ForeColor = System.Drawing.Color.White;
            this.SH_B.Location = new System.Drawing.Point(38, 147);
            this.SH_B.Name = "SH_B";
            this.SH_B.Size = new System.Drawing.Size(294, 218);
            this.SH_B.TabIndex = 15;
            this.SH_B.Text = "방화벽 꺼짐";
            this.SH_B.UseVisualStyleBackColor = false;
            this.SH_B.Click += new System.EventHandler(this.SH_B_Click);
            // 
            // 삭제
            // 
            this.삭제.Location = new System.Drawing.Point(366, 371);
            this.삭제.Name = "삭제";
            this.삭제.Size = new System.Drawing.Size(149, 48);
            this.삭제.TabIndex = 19;
            this.삭제.Text = "선택한IP삭제";
            this.삭제.UseVisualStyleBackColor = true;
            this.삭제.Click += new System.EventHandler(this.삭제_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(366, 89);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(307, 268);
            this.listBox1.TabIndex = 18;
            // 
            // 주소추가
            // 
            this.주소추가.Location = new System.Drawing.Point(604, 49);
            this.주소추가.Name = "주소추가";
            this.주소추가.Size = new System.Drawing.Size(68, 21);
            this.주소추가.TabIndex = 17;
            this.주소추가.Text = "IP추가";
            this.주소추가.UseVisualStyleBackColor = true;
            this.주소추가.Click += new System.EventHandler(this.주소추가_Click);
            // 
            // 주소텍스트
            // 
            this.주소텍스트.Location = new System.Drawing.Point(365, 49);
            this.주소텍스트.Name = "주소텍스트";
            this.주소텍스트.Size = new System.Drawing.Size(223, 21);
            this.주소텍스트.TabIndex = 16;
            this.주소텍스트.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.주소텍스트_KeyPress);
            // 
            // 초기화
            // 
            this.초기화.Location = new System.Drawing.Point(521, 372);
            this.초기화.Name = "초기화";
            this.초기화.Size = new System.Drawing.Size(151, 48);
            this.초기화.TabIndex = 20;
            this.초기화.Text = "초기화";
            this.초기화.UseVisualStyleBackColor = true;
            this.초기화.Click += new System.EventHandler(this.초기화_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(715, 443);
            this.Controls.Add(this.초기화);
            this.Controls.Add(this.삭제);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.주소추가);
            this.Controls.Add(this.주소텍스트);
            this.Controls.Add(this.SH_B);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.개인세션생성);
            this.Controls.Add(this.상태정보);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label 상태정보;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button 개인세션생성;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button SH_B;
        private System.Windows.Forms.Button 삭제;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button 주소추가;
        private System.Windows.Forms.TextBox 주소텍스트;
        private System.Windows.Forms.Button 초기화;
    }
}

