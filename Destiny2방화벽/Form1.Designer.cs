namespace Destiny2방화벽
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
            this.Exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.규칙추가 = new System.Windows.Forms.Button();
            this.규칙제거 = new System.Windows.Forms.Button();
            this.SH_B = new System.Windows.Forms.Button();
            this.주소텍스트 = new System.Windows.Forms.TextBox();
            this.주소추가 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.삭제 = new System.Windows.Forms.Button();
            this.초기화 = new System.Windows.Forms.Button();
            this.개인세션생성 = new System.Windows.Forms.Button();
            this.상태정보 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Red;
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Exit.Location = new System.Drawing.Point(627, -3);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(37, 32);
            this.Exit.TabIndex = 0;
            this.Exit.Text = "X";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "솔로모드 생성기";
            // 
            // 규칙추가
            // 
            this.규칙추가.Location = new System.Drawing.Point(15, 49);
            this.규칙추가.Name = "규칙추가";
            this.규칙추가.Size = new System.Drawing.Size(137, 74);
            this.규칙추가.TabIndex = 19;
            this.규칙추가.Text = "솔로모드 ON";
            this.규칙추가.UseVisualStyleBackColor = true;
            this.규칙추가.Click += new System.EventHandler(this.규칙추가_Click);
            // 
            // 규칙제거
            // 
            this.규칙제거.Location = new System.Drawing.Point(180, 49);
            this.규칙제거.Name = "규칙제거";
            this.규칙제거.Size = new System.Drawing.Size(137, 74);
            this.규칙제거.TabIndex = 20;
            this.규칙제거.Text = "솔로모드 OFF";
            this.규칙제거.UseVisualStyleBackColor = true;
            this.규칙제거.Click += new System.EventHandler(this.규칙제거_Click);
            // 
            // SH_B
            // 
            this.SH_B.BackColor = System.Drawing.Color.Red;
            this.SH_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SH_B.ForeColor = System.Drawing.Color.White;
            this.SH_B.Location = new System.Drawing.Point(19, 49);
            this.SH_B.Name = "SH_B";
            this.SH_B.Size = new System.Drawing.Size(298, 252);
            this.SH_B.TabIndex = 21;
            this.SH_B.Text = "솔로모드 꺼짐";
            this.SH_B.UseVisualStyleBackColor = false;
            this.SH_B.Click += new System.EventHandler(this.SH_B_Click);
            // 
            // 주소텍스트
            // 
            this.주소텍스트.Location = new System.Drawing.Point(334, 49);
            this.주소텍스트.Name = "주소텍스트";
            this.주소텍스트.Size = new System.Drawing.Size(223, 21);
            this.주소텍스트.TabIndex = 22;
            // 
            // 주소추가
            // 
            this.주소추가.Location = new System.Drawing.Point(563, 49);
            this.주소추가.Name = "주소추가";
            this.주소추가.Size = new System.Drawing.Size(68, 21);
            this.주소추가.TabIndex = 23;
            this.주소추가.Text = "IP추가";
            this.주소추가.UseVisualStyleBackColor = true;
            this.주소추가.Click += new System.EventHandler(this.주소추가_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(334, 91);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(297, 160);
            this.listBox1.TabIndex = 24;
            // 
            // 삭제
            // 
            this.삭제.Location = new System.Drawing.Point(337, 257);
            this.삭제.Name = "삭제";
            this.삭제.Size = new System.Drawing.Size(137, 44);
            this.삭제.TabIndex = 25;
            this.삭제.Text = "선택한 IP삭제";
            this.삭제.UseVisualStyleBackColor = true;
            this.삭제.Click += new System.EventHandler(this.삭제_Click);
            // 
            // 초기화
            // 
            this.초기화.Location = new System.Drawing.Point(498, 257);
            this.초기화.Name = "초기화";
            this.초기화.Size = new System.Drawing.Size(133, 44);
            this.초기화.TabIndex = 26;
            this.초기화.Text = "초기화";
            this.초기화.UseVisualStyleBackColor = true;
            this.초기화.Click += new System.EventHandler(this.초기화_Click);
            // 
            // 개인세션생성
            // 
            this.개인세션생성.Location = new System.Drawing.Point(19, 225);
            this.개인세션생성.Name = "개인세션생성";
            this.개인세션생성.Size = new System.Drawing.Size(298, 76);
            this.개인세션생성.TabIndex = 27;
            this.개인세션생성.Text = "1인공개세션만들기";
            this.개인세션생성.UseVisualStyleBackColor = true;
            this.개인세션생성.Click += new System.EventHandler(this.개인세션생성_Click);
            // 
            // 상태정보
            // 
            this.상태정보.AutoSize = true;
            this.상태정보.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.상태정보.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.상태정보.Location = new System.Drawing.Point(27, 282);
            this.상태정보.Name = "상태정보";
            this.상태정보.Size = new System.Drawing.Size(49, 19);
            this.상태정보.TabIndex = 28;
            this.상태정보.Text = "상태";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 329);
            this.Controls.Add(this.상태정보);
            this.Controls.Add(this.개인세션생성);
            this.Controls.Add(this.초기화);
            this.Controls.Add(this.삭제);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.주소추가);
            this.Controls.Add(this.주소텍스트);
            this.Controls.Add(this.SH_B);
            this.Controls.Add(this.규칙제거);
            this.Controls.Add(this.규칙추가);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button 규칙추가;
        private System.Windows.Forms.Button 규칙제거;
        private System.Windows.Forms.Button SH_B;
        private System.Windows.Forms.TextBox 주소텍스트;
        private System.Windows.Forms.Button 주소추가;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button 삭제;
        private System.Windows.Forms.Button 초기화;
        private System.Windows.Forms.Button 개인세션생성;
        private System.Windows.Forms.Label 상태정보;
        private System.Windows.Forms.Timer timer1;
    }
}

