using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX.DirectInput;
using System.Threading;


/*  Turns out a dance mat can be detected! The buttons are weird as heck though. 
 *  Here is a mapping
 *  
 *  Top left (x) is "Buttons6"
 *  Up is "Buttons2"
 *  Top right (o) is "Buttons7"
 *  Left is  "Buttons0"
 *  Middle is "Y"
 *  Right is "Buttons3"
 *  Down Left (Triangle) is "Buttons4"
 *  Down is "Buttons1"
 *  Down Right is "Buttons5"
 *  Select is "Buttons8"
 *  Start is "Buttons9"
 *  Middle Area is "Y"
 *  
 *  
 *  
 *  For each button, the state "128" means it is pressed
 *  The state "0" means it is not pressed
 *  However, the middle button has it's own state (I fugure this is actually recognised as a stick tbh)
 *  65535 is pressed and 32511 is not pressed
 */



namespace GamePad_Demo
{
    public partial class Form1 : Form
    {
        
       
        public Form1()
        {
            InitializeComponent();
        }


        void pollController()
        {
            Joystick TheMat;
            string text = "";

            var directInput = new DirectInput();
            var joystickGuid = Guid.Empty;

            //Find Gamepad
            foreach (var deviceInstance in directInput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices))
            {
                joystickGuid = deviceInstance.InstanceGuid;
            }

            // If Gamepad not found, look for a Joystick
            if (joystickGuid == Guid.Empty)
            {
                foreach (var deviceInstance in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices))
                {
                    joystickGuid = deviceInstance.InstanceGuid;
                }
            }
            // If Joystick not found, throws an error
            if (joystickGuid == Guid.Empty)
            {
                text = "No joystick/Gamepad found.\n";
                OutputArea.Text = OutputArea.Text + text + "\n";
                return;
            }

            // Instantiate the joystick

            TheMat = new Joystick(directInput, joystickGuid);
            text = "Found Joystick/Gamepad with GUID: " + joystickGuid + "\n";

            // Query all suported ForceFeedback effects
            var allEffects = TheMat.GetEffects();
            if (allEffects.Count == 0)
            {
                text = text + "No effects available for this controller.\n";
            }
            foreach (var effectInfo in allEffects)
            {
                text = text + "Effect available: " + effectInfo.Name + "\n";
            }


            //Capabilities
            text = text + "Axe Count: " + TheMat.Capabilities.AxeCount.ToString() + "\n";

            text = text + "Button Count: " + TheMat.Capabilities.ButtonCount.ToString() + "\n";

            text = text + "Driver Version: " + TheMat.Capabilities.DriverVersion.ToString() + "\n";

            text = text + "Firmware Revision: " + TheMat.Capabilities.FirmwareRevision.ToString() + "\n";

            text = text + "Force Feedback Minimum Time Resolution: " + TheMat.Capabilities.ForceFeedbackMinimumTimeResolution.ToString() + "\n";

            text = text + "Force Feedback Sample Period: " + TheMat.Capabilities.ForceFeedbackSamplePeriod.ToString() + "\n";

            text = text + "Hardware Revision: " + TheMat.Capabilities.HardwareRevision.ToString() + "\n";

            text = text + "Pov Count: " + TheMat.Capabilities.PovCount.ToString() + "\n";

            text = text + "Is Human Interface Device: " + TheMat.Capabilities.IsHumanInterfaceDevice.ToString() + "\n";

            text = text + "Sub-Type: " + TheMat.Capabilities.Subtype.ToString() + "\n";


            //Properies

            text = text + "Axis Mode: " + TheMat.Properties.AxisMode.ToString() + "\n";

            text = text + "Buffer Size: " + TheMat.Properties.BufferSize.ToString() + "\n";

            text = text + "Class GUID: " + TheMat.Properties.ClassGuid.ToString() + "\n";

            text = text + "Force Feedback Gain: " + TheMat.Properties.ForceFeedbackGain.ToString() + "\n";

            text = text + "Interface Path: " + TheMat.Properties.InterfacePath.ToString() + "\n";

            text = text + "Product name: " + TheMat.Properties.ProductName.ToString() + "\n";

            text = text + "Joystick ID: " + TheMat.Properties.JoystickId.ToString() + "\n";

            text = text + "Product ID: " + TheMat.Properties.ProductId.ToString() + "\n";

            text = text + "Vendor ID: " + TheMat.Properties.VendorId.ToString() + "\n";


            text = text + "Created Effects Count: " + TheMat.CreatedEffects.Count.ToString() + "\n";


            text = text + "Usage: " + TheMat.Information.Usage.ToString() + "\n";

            OutputArea.Text = OutputArea.Text + text + "\n";

            // Set BufferSize in order to use buffered data.
            TheMat.Properties.BufferSize = 128;
            //TheMat.SetDataFormat(DeviceDataFormat.Joystick);

            // Acquire the joystick
            TheMat.Acquire();
            //TheMat.SetCooperativeLevel(Handle, CooperativeLevel.Background | CooperativeLevel.NonExclusive);


            while (1 == 1)
            {
                try
                {
                    TheMat.Poll();
                    var stateData = TheMat.GetCurrentState();
                    


                    bool[] ButtonState = stateData.Buttons;

                    for (int i = 0; i <= ButtonState.Length-1; i++)
                    {
                        if(ButtonState[i] == true)
                        {
                            OutputArea2.Text = OutputArea2.Text + "Button " + i + " pressed\n";
                        }
                    }


                    //var bufferedData = TheMat.GetBufferedData();


                    //This is totally useless, lol.
                    //OutputArea2.Text = OutputArea2.Text + bData.ToString() + "\n";


                    /*
                     * This gets the raw buffered data. I do not want to mess around sorting through the string data returned, just the change in state will be fine thanks.
                    foreach (var rawbuffereddata in bufferedData)
                    {
                        OutputArea2.Text = OutputArea2.Text + rawbuffereddata.ToString() + "\n";
                    }
                    */

                }
                catch
                {

                    OutputArea2.Text = OutputArea2.Text + "Disconnected. Attempting graceful controller exit.\n";
                    TheMat.Dispose();
                    OutputArea2.Text = OutputArea2.Text + "Disposed controller successfully, graceful disconnect achieved!\n";
                    break;
                }
            }
        }

        public void JoystickInputThread()
        {
            try
            {
                pollController();
            }
            catch (Exception ex)
            {
                // log errors
                OutputArea2.Text = OutputArea2.Text + ex.Message.ToString() + "\n";
            }
        }


        private void PollForInputBtn_Click(object sender, EventArgs e)
        {
            //pollController();
            Thread thread = new Thread(new ThreadStart(JoystickInputThread));
            thread.Start();
        }

        private void OutputArea2_TextChanged(object sender, EventArgs e)
        {
            OutputArea2.SelectionStart = OutputArea2.Text.Length;
            // scroll it automatically
            OutputArea2.ScrollToCaret();
        }
    }
}
