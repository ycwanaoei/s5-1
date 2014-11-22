
using System;
using System.Windows.Forms;
namespace S5_1
{
    public partial class AddTest : Form
    {
        int NumCount = 0;//出题总数
        int CorrectNum = 0;//做对的题数
        int add1, add2, result;//加数1、加数2、结果
        Random rand = new Random();//随机数
        bool ButtonStartState = false;//在已经点击开始后不允许再次点击,必须等到结束
        public AddTest()
        {
            InitializeComponent();
        }
        //点击开始键开始计时
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (ButtonStartState == false)
            {
                ButtonStartState = true;
                timerCount.Enabled = true;//启动计数器
                labelInfo.Enabled = true;
                labelInfo.Text = "计时已开始!按Enter键计算";
                add1 = rand.Next(0, 101);//产生[0,101)之间的随机整数
                add2 = rand.Next(0, 101);
                textBoxNum1.Text = add1.ToString();
                textBoxNum2.Text = add2.ToString();
                textBoxResult.Focus();//设置TextBoxResult输入焦点
            }
        }
        //点击结束键退出程序
        private void buttonEnd_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //1分钟计时结束
        private void timerCount_Tick(object sender, EventArgs e)
        {
            labelInfo.Text = "计时已结束!";
            MessageBox.Show(string.Format("出题总数为{0},做对题数为{1}.", NumCount, CorrectNum), "答题结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            NumCount = 0;//计数清0
            CorrectNum = 0;//计数清0
            ButtonStartState = false;
            timerCount.Enabled = false;//只计时一次
        }
        private void textBoxResult_TextChanged(object sender, EventArgs e)
        {
            if (timerCount.Enabled == false)//当计时器未计时时,自动清除输入框中的输入
            {
                textBoxResult.Text = "";
            }
        }
        private void textBoxResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && timerCount.Enabled == true)//回车
            {
                NumCount++;
                result = add1 + add2;
                if (textBoxResult.Text.ToString() == result.ToString())
                {
                    CorrectNum++;
                }
                add1 = rand.Next(0, 101);
                add2 = rand.Next(0, 101);
                textBoxNum1.Text = add1.ToString();
                textBoxNum2.Text = add2.ToString();
            }
        }

        private void AddTest_Load(object sender, EventArgs e)
        {

        }
    }
}