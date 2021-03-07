using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    public struct Slider
    {
        private int IdSlider;
        private int SliderX;


        public int GetIdSlider()
        {
            return this.IdSlider;
        }
        public void SetIdSlider(int IdSlider)
        {
            this.IdSlider = IdSlider;
        }
        public int GetSliderX()
        {
            return this.SliderX;
        }
        public void SetSliderX(int SliderX)
        {
            this.SliderX = SliderX;
        }

    }
}
