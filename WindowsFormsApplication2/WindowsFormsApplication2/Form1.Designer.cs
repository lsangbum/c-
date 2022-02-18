namespace WindowsFormsApplication2
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.id = new DevExpress.XtraEditors.LabelControl();
            this.pw = new DevExpress.XtraEditors.LabelControl();
            this.userId = new DevExpress.XtraEditors.TextEdit();
            this.userPw = new DevExpress.XtraEditors.TextEdit();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.btnJoin = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.userId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPw.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 24F);
            this.labelControl1.Location = new System.Drawing.Point(103, 22);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 39);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "로그인";
            // 
            // id
            // 
            this.id.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.id.Location = new System.Drawing.Point(35, 86);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(51, 27);
            this.id.TabIndex = 1;
            this.id.Text = "아이디";
            // 
            // pw
            // 
            this.pw.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.pw.Location = new System.Drawing.Point(18, 136);
            this.pw.Name = "pw";
            this.pw.Size = new System.Drawing.Size(68, 27);
            this.pw.TabIndex = 2;
            this.pw.Text = "비밀번호";
            // 
            // userId
            // 
            this.userId.Location = new System.Drawing.Point(103, 83);
            this.userId.Name = "userId";
            this.userId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.userId.Properties.Appearance.Options.UseFont = true;
            this.userId.Size = new System.Drawing.Size(145, 32);
            this.userId.TabIndex = 3;
            // 
            // userPw
            // 
            this.userPw.Location = new System.Drawing.Point(103, 133);
            this.userPw.Name = "userPw";
            this.userPw.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.userPw.Properties.Appearance.Options.UseFont = true;
            this.userPw.Size = new System.Drawing.Size(145, 32);
            this.userPw.TabIndex = 4;
            // 
            // btnLogin
            // 
            this.btnLogin.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btnLogin.Appearance.Options.UseFont = true;
            this.btnLogin.Location = new System.Drawing.Point(103, 171);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(84, 38);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "로그인";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnJoin
            // 
            this.btnJoin.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.btnJoin.Appearance.Options.UseFont = true;
            this.btnJoin.Location = new System.Drawing.Point(103, 215);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(84, 34);
            this.btnJoin.TabIndex = 6;
            this.btnJoin.Text = "회원가입";
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.userPw);
            this.Controls.Add(this.userId);
            this.Controls.Add(this.pw);
            this.Controls.Add(this.id);
            this.Controls.Add(this.labelControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.userId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPw.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl id;
        private DevExpress.XtraEditors.LabelControl pw;
        private DevExpress.XtraEditors.TextEdit userId;
        private DevExpress.XtraEditors.TextEdit userPw;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.SimpleButton btnJoin;
    }
}

