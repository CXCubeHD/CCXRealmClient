using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static CCXRealmClient.Data;

namespace CCXRealmClient
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer SyncUI = new DispatcherTimer();
            SyncUI.Interval = new TimeSpan(0, 0, 0, 0, 20);
            SyncUI.Tick += new EventHandler(SyncUI_Tick);
            SyncUI.Start();

            OnMemoryUpdate.StartOnMemoryUpdate_CheckProcess();
            OnMemoryUpdate.StartOnMemoryUpdate();
            OnMemoryUpdate.StartModuleWorker();
            CCXRealmClient.Listener.StartListener();
        }



        private void WindowTopBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseRect_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        private void MinimizeRect_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }





        private void SyncUI_Tick(object sender, EventArgs e)
        {

            if (OnMemoryUpdate.Status_Process_Open)
            {
                this.label_gamestatus.Content = "Found";
                this.label_gamestatus.Foreground = Brushes.Lime;
            } else
            {
                this.label_gamestatus.Content = "NOT Found";
                this.label_gamestatus.Foreground = Brushes.Red;
            }

            this.label_positionX.Content = ((int)(OnMemoryUpdate.PosX)).ToString();
            this.label_positionY.Content = ((int)(OnMemoryUpdate.PosY)).ToString();
            this.label_positionZ.Content = ((int)(OnMemoryUpdate.PosZ)).ToString();

            if (this.checkbox_trigger_clientsettings_enabledevsettings.IsChecked == true)
            {
                Data.ClientSettings.EnableDevSettings = true;
            } else
            {
                Data.ClientSettings.EnableDevSettings = false;
            }

            this.label_value_module_speed.Content = "Speed Value: " + (this.slider_valueset_module_speed.Value / 100).ToString();
            Data.Module.Value.Speed = (float)(this.slider_valueset_module_speed.Value / 100);

            this.label_value_module_glide.Content = "Glide Value: " + (this.slider_valueset_module_glide.Value / 100).ToString();
            Data.Module.Value.GlideVelocityY = (float)(this.slider_valueset_module_glide.Value / 100);

            // Updating Colors
            UpdateGButtons();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnMemoryUpdate.Module_Trigger.Teleport(0f, 10f, 0f);
        }

        private void Button_trigger_module_selfdestruction_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (OnMemoryUpdate.Status_Process_Open == true)
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        OnMemoryUpdate.m.writeMemory(Data.Pointer.Nofall, "float", "255");
                    }
                    catch
                    {

                    }
                    Thread.Sleep(5);
                }
            } 
        }

        private void UpdateGButtons()
        {
            UpdateColorOfGButton(this.gbutton_module_airjump_b, Module.Status.Airjump, GButtonStatus.Locked.gbutton_module_airjump);
            UpdateColorOfGButton(this.gbutton_module_speed_b, Module.Status.Speed, GButtonStatus.Locked.gbutton_module_speed);
            UpdateColorOfGButton(this.gbutton_module_glide_b, Module.Status.Glide, GButtonStatus.Locked.gbutton_module_glide);
            UpdateColorOfGButton(this.gbutton_module_rapidhit_b, Module.Status.Rapidhit, GButtonStatus.Locked.gbutton_module_rapidhit);
            UpdateColorOfGButton(this.gbutton_module_nofall_b, Module.Status.Nofall, GButtonStatus.Locked.gbutton_module_nofall);
            UpdateColorOfGButton(this.gbutton_module_showcoordinates_b, Module.Status.ShowCoordinates, GButtonStatus.Locked.gbutton_module_showcoordinates);
            UpdateColorOfGButton(this.gbutton_module_fakegamemode_b, Module.Status.FakeGamemode, GButtonStatus.Locked.gbutton_module_fakegamemode);

            UpdateColorOfTriggerGButton(this.gbutton_trigger_module_fallfromhightplace_b, GButtonStatus.Locked.gbutton_module_fallfromhightplace);

            UpdateColorOfRadioButtons(new Border[] { this.gbutton_module_fakecreative_radiobutton_0_b, this.gbutton_module_fakecreative_radiobutton_1_b, this.gbutton_module_fakecreative_radiobutton_2_b }, Module.Value.FakeGamemode, GButtonStatus.Locked.gbutton_module_fakegamemode);
        }

        private void UpdateColorOfGButton(Border gbutton_b, bool Status, bool IsLocked)
        {
            var converter = new System.Windows.Media.BrushConverter();
            Brush brush;

            if (Status && !IsLocked)
            {
                brush = (Brush)converter.ConvertFromString(DefaultColors.gbutton.on);
            } else if (!IsLocked)
            {
                brush = (Brush)converter.ConvertFromString(DefaultColors.gbutton.off);
            } else
            {
                brush = (Brush)converter.ConvertFromString(DefaultColors.gbutton.locked);
            }

            gbutton_b.Background = brush;
        }

        private void UpdateColorOfTriggerGButton(Border gbutton_b, bool IsLocked)
        {
            var converter = new System.Windows.Media.BrushConverter();
            Brush brush;

            if (!IsLocked)
            {
                brush = (Brush)converter.ConvertFromString(DefaultColors.gbutton.trigger);
            } else
            {
                brush = (Brush)converter.ConvertFromString(DefaultColors.gbutton.locked);
            }

            gbutton_b.Background = brush;
        }

        private void UpdateColorOfRadioButtons(Border[] gbuttons_b, int activeIndex, bool IsLoocked)
        {
            var converter = new System.Windows.Media.BrushConverter();
            Brush brush;

            for (int i = 0; i < gbuttons_b.Length; i++)
            {
                if (i == activeIndex && !IsLoocked)
                {
                    brush = (Brush)converter.ConvertFromString(DefaultColors.gbutton_radio.active);
                } else if (!IsLoocked)
                {
                    brush = (Brush)converter.ConvertFromString(DefaultColors.gbutton_radio.inactive);
                } else
                {
                    brush = (Brush)converter.ConvertFromString(DefaultColors.gbutton.locked);
                }

                gbuttons_b[i].Background = brush;
            }
        }

        private void Gbutton_default_MouseUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Gbutton_module_airjump_b_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!GButtonStatus.Locked.gbutton_module_airjump)
            {
                Module.Status.Airjump = !Module.Status.Airjump;
            }
        }

        private void Gbutton_module_speed_b_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!GButtonStatus.Locked.gbutton_module_speed)
            {
                Module.Status.Speed = !Module.Status.Speed;
            }
        }

        private void Gbutton_module_glide_b_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!GButtonStatus.Locked.gbutton_module_glide)
            {
                Module.Status.Glide = !Module.Status.Glide;
            }
        }

        private void Gbutton_module_rapidhit_b_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!GButtonStatus.Locked.gbutton_module_rapidhit)
            {
                Module.Status.Rapidhit = !Module.Status.Rapidhit;
            }
        }

        private void Gbutton_module_nofall_b_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!GButtonStatus.Locked.gbutton_module_nofall)
            {
                Module.Status.Nofall = !Module.Status.Nofall;
            }
        }

        private void Gbutton_module_fallfromhightplace_b_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!GButtonStatus.Locked.gbutton_module_fallfromhightplace)
            {
                Button_trigger_module_selfdestruction_MouseUp(sender, e);
            }
        }

        private void Gbutton_module_showcoordinates_b_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!GButtonStatus.Locked.gbutton_module_showcoordinates)
            {
                Module.Status.ShowCoordinates = !Module.Status.ShowCoordinates;
            }
        }

        private void Gbutton_module_fakegamemode_b_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!GButtonStatus.Locked.gbutton_module_fakegamemode)
            {
                Module.Status.FakeGamemode = !Module.Status.FakeGamemode;
            }
        }

        private void Gbutton_module_fakegamemode_0_b_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!GButtonStatus.Locked.gbutton_module_fakegamemode)
            {
                Module.Value.FakeGamemode = 0;
            }
        }

        private void Gbutton_module_fakegamemode_1_b_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!GButtonStatus.Locked.gbutton_module_fakegamemode)
            {
                Module.Value.FakeGamemode = 1;
            }
        }

        private void Gbutton_module_fakegamemode_2_b_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!GButtonStatus.Locked.gbutton_module_fakegamemode)
            {
                Module.Value.FakeGamemode = 2;
            }
        }

        private void Gbutton_module_tp_b_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!GButtonStatus.Locked.gbutton_module_teleport)
            {
                OnMemoryUpdate.Module_Trigger.Teleport(float.Parse(textbox_module_teleport_x.Text), float.Parse(textbox_module_teleport_y.Text), float.Parse(textbox_module_teleport_z.Text));
                Console.WriteLine("Should work...");
            }
        }
    }
}
