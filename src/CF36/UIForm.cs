using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CF36
{
    public class UIForm
    {
        public static void ApplyFadeIn(Form form, int interval = 20, double step = 0.05)
        {
            form.Opacity = 0;
            var timer = new System.Windows.Forms.Timer { Interval = interval };
            timer.Tick += (s, e) =>
            {
                if (form.Opacity < 1)
                    form.Opacity += step;
                else
                    timer.Stop();
            };
            timer.Start();
        }
        public static void ApplyFadeOutAndClose(Form form, int interval = 20, double step = 0.05)
        {
            var timer = new System.Windows.Forms.Timer { Interval = interval };
            timer.Tick += (s, e) =>
            {
                if (form.Opacity > 0)
                    form.Opacity -= step;
                else
                {
                    timer.Stop();
                    form.Close();
                }
            };
            timer.Start();
        }

    }
}
