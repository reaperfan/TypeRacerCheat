
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WindowsInput.Native;
using WindowsInput;
using System.Runtime.InteropServices;


namespace TypeWriter
{
	
	
	public partial class MainForm : Form
	{
		IntPtr Chr;
		
		[DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
		[DllImport("USER32.DLL")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);
    
		public MainForm()
		{
			
			InitializeComponent();
			try 
			{
				string Browser = "Chrome_WidgetWin_1";
				string Tab = "TypeRacer - Test your typing speed and learn to type faster. Free typing game and competition. Way more fun than a typing tutor! - Google Chrome";
				Chr = FindWindow(Browser,Tab);
			
			}	
			catch (Exception exp)
			{
				MessageBox.Show(exp.ToString() + " Nyisd meg a typreracert!");
				Application.Exit();
			}
			
		}
		void Button1Click(object sender, EventArgs e)
		{
			try 
			{
				String text = textBox1.Text.ToString();
				char[] chars = szoveg.ToCharArray();
				SetForegroundWindow(Chr);
				foreach (var element in chars)
				{
				SendKeys.Send(element.ToString());
				System.Threading.Thread.Sleep((int)numericUpDown1.Value);
				}
				textBox1.Text ="";
					
			 } 
			catch (Exception exp) 
			{
				
				MessageBox.Show(exp.ToString());
			}
			
		}
	}
}
